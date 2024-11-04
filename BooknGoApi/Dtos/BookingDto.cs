namespace BooknGoApi.Dtos
{
    public class BookingDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Guid CustomerId { get; set; }
    }
}
