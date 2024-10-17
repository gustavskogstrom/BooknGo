namespace BooknGo.DTOs
{
    public class FeedbackDTO
    {
        public Guid FeedbackId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Guid BookingId { get; set; }
    }
}
