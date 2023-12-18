using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CatFeedAPI.Entities
{
    public class Feeder
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(1, 2000)]
        public int FoodWeight { get; set; }
        public string? Tag { get; set; }
        [Range(1, 250)]
        public int FoodAtATime { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int TimesCatShouldEat { get; set; }
        [Required]
        public DateTime Interval { get; set; }
        public bool? FeedPresence { get; set; }
        public string FeederUserId { get; set; }
        public ApplicationUser FeederUser { get; set; }
    }
}
