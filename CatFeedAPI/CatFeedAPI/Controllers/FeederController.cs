using AutoMapper;
using CatFeedAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatFeedAPI.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CatFeedAPI.Controllers
{
    [Route("api/feeders")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FeederController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeederController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FeederDTO>> Get(int id)
        {
            var feeder = await _context.Feeders.FirstOrDefaultAsync(x => x.Id == id);

            if (feeder == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<FeederDTO>(feeder);

            return dto;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<FeederDTO>>> Get()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email");

            if (claim == null)
            {
                return new List<FeederDTO>();
            }

            var email = claim.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var feeders = await _context.Feeders.Where(x => x.FeederUserId == userId).OrderBy(x => x.Id).ToListAsync();

            return _mapper.Map<List<FeederDTO>>(feeders);
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<List<FeederDTO>>> AdminGet()
        {
            var feeders = await _context.Feeders.OrderBy(x => x.Id).ToListAsync();

            return _mapper.Map<List<FeederDTO>>(feeders);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromForm] FeederCreationDTO feederCreationDTO)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var feeder = _mapper.Map<Feeder>(feederCreationDTO);
            feeder.FeederUserId = userId;
            _context.Add(feeder);
            await _context.SaveChangesAsync();

            string stringLog = "Feeder created. " + ParseForLogs(_mapper.Map<FeederDTO>(feeder));
            var log = new LogCreationDTO(DateTime.Now, stringLog, userId);
            var mappedLog = _mapper.Map<Log>(log);
            _context.Add(mappedLog);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(int id, [FromForm] FeederCreationDTO feederCreationDTO)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var feeder = await _context.Feeders.Include(x => x.FeederUser).FirstOrDefaultAsync(x => x.Id == id);

            if (feeder == null)
            {
                return NotFound();
            }

            feeder = _mapper.Map(feederCreationDTO, feeder);
            await _context.SaveChangesAsync();

            string stringLog = "Feeder edited. " + ParseForLogs(_mapper.Map<FeederDTO>(feeder));
            var log = new LogCreationDTO(DateTime.Now, stringLog, userId);
            var mappedLog = _mapper.Map<Log>(log);
            _context.Add(mappedLog);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var feeder = await _context.Feeders.FirstOrDefaultAsync(x => x.Id == id);

            if (feeder == null)
            {
                return NotFound();
            }

            _context.Remove(feeder);
            await _context.SaveChangesAsync();

            string stringLog = "Feeder deleted. " + ParseForLogs(_mapper.Map<FeederDTO>(feeder));
            var log = new LogCreationDTO(DateTime.Now, stringLog, userId);
            var mappedLog = _mapper.Map<Log>(log);
            _context.Add(mappedLog);
            await _context.SaveChangesAsync();

            return Ok();
        }

        public string ParseForLogs(FeederDTO feeder)
        {
            string logStringified = string.Empty;

            logStringified += "Id: " + feeder.Id.ToString() + ", ";
            logStringified += "Type: " + feeder.Type + ", ";
            logStringified += "Food Weight: " + feeder.FoodWeight.ToString() + ", ";
            if (!string.IsNullOrWhiteSpace(feeder.Tag))
            {
                logStringified += "Tag: " + feeder.Tag + ", ";
            }
            if (feeder.FoodAtATime != 0)
            {
                logStringified += "Food At A Time: " + feeder.FoodAtATime.ToString() + ", ";
            }
            logStringified += "Start Time: " + feeder.StartTime.ToString() + ", ";
            logStringified += "End Time: " + feeder.EndTime.ToString() + ", ";
            logStringified += "Times Cat Should Eat: " + feeder.TimesCatShouldEat.ToString() + ", ";
            logStringified += "Interval: " + feeder.Interval.ToString() + ", ";

            return logStringified;
        }
    }
}