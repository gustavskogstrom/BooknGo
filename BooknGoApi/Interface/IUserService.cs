using BooknGoApi.Dtos;

namespace BooknGoApi.Interface
{
    public interface IUserService
    {
        Task<IList<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
    }

    
}
