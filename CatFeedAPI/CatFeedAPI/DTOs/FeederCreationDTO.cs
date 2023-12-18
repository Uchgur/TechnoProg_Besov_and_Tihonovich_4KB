using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MoviesAPI.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CatFeedAPI.DTOs
{
    public class FeederCreationDTO
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public int FoodWeight { get; set; }
        public string? Tag { get; set; }
        [Required]
        public int FoodAtATime { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int TimesCatShouldEat { get; set; }
        [Required]
        public DateTime Interval { get; set; }
        public bool FeedPresence { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int UserId { get; set; }
    }
}
