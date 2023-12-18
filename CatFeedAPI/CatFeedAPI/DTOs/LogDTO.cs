namespace CatFeedAPI.DTOs
{
    public class LogDTO
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string Message { get; set; }
        public string FeederUserId { get; set; }
    }
}
