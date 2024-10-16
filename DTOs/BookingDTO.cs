namespace BooknGo.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
    }
}
