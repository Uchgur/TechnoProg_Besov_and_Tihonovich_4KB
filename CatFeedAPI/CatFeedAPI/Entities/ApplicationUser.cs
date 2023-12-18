using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace CatFeedAPI.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [DefaultValue(false)]
        public bool Confirmed { get; set; }
    }
}
