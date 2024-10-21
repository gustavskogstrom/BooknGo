namespace BooknGoApi.Dtos
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }
        public Guid ResourceId { get; set; }
    }
}
