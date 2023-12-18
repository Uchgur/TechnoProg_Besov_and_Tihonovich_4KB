using AutoMapper;
using CatFeedAPI.DTOs;
using CatFeedAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatFeedAPI.Controllers
{
    [Route("/api/logs")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public LogController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<LogDTO>>> Get()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email");

            if (claim == null)
            {
                return new List<LogDTO>();
            }

            var email = claim.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var userId = user.Id;

            var logs = await _context.ActionLogs.Where(x => x.FeederUserId == userId).OrderBy(x => x.LogTime).ToListAsync();

            return _mapper.Map<List<LogDTO>>(logs);
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<List<LogDTO>>> GetAdmin()
        {
            var logs = await _context.ActionLogs.OrderBy(x => x.LogTime).ToListAsync();

            return _mapper.Map<List<LogDTO>>(logs);
        }
    }
}
