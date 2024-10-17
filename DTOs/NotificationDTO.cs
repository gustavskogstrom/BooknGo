namespace BooknGo.DTOs
{
    public class NotificationDTO
    {
        public Guid NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? BookingId { get; set; }
    }
}
