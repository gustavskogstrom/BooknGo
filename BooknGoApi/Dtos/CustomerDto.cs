namespace BooknGoApi.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<BookingDto> Bookings { get; set; } = new List<BookingDto>();
    }
}
