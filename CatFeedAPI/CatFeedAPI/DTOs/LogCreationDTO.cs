using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helpers;

namespace CatFeedAPI.DTOs
{
    public class LogCreationDTO
    {
        public DateTime LogTime { get; set; }
        public string Message { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public string FeederUserId { get; set; }


        public LogCreationDTO(DateTime LogTime, string Message, string UserId)
        {
            this.LogTime = LogTime;
            this.Message = Message;
            this.FeederUserId = UserId;
        }
    }
}
