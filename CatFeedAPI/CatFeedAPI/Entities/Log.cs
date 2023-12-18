using Microsoft.AspNetCore.Identity;

namespace CatFeedAPI.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string Message { get; set; }
        public string FeederUserId { get; set; }
        public ApplicationUser FeederUser { get; set; }
    }
}
