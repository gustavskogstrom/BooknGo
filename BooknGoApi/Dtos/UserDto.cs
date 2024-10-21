namespace BooknGoApi.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
