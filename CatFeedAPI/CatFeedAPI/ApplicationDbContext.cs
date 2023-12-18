using CatFeedAPI.Entities;
using CatFeedAPI.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CatFeedAPI
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Feeder> Feeders { get; set; }
        public DbSet<Log> ActionLogs { get; set; }
    }
}
