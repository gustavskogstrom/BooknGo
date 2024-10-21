using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<UserDto>> GetAllUsersAsync()
        {
            // Implementation for retrieving all users
            var users = new List<UserDto>();
            return await Task.FromResult(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            // Implementation for retrieving a user by ID
            var user = new UserDto();
            return await Task.FromResult(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            // Implementation for creating a new user
            var user = _mapper.Map<UserDto>(userDto);
            return await Task.FromResult(user);
        }
    }
}
