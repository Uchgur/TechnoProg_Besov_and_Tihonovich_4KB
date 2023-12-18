using CatFeedAPI.Entities;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Noding;
using System.ComponentModel.DataAnnotations;

namespace CatFeedAPI.DTOs
{
    public class FeederDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int FoodWeight { get; set; }
        public string? Tag { get; set; }
        public int FoodAtATime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimesCatShouldEat { get; set; }
        public DateTime Interval { get; set; }
        public bool FeedPresence { get; set; }
        public string FeederUserId { get; set; }
    }
}
