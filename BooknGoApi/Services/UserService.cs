using AutoMapper;
using BooknGoApi.Dtos;
using BooknGoApi.Interface;

namespace BooknGoApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly List<UserDto> _users;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            _users = new List<UserDto>(); // Mocked in-memory data store
        }

        public async Task<IList<UserDto>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            userDto.Id = Guid.NewGuid();
            _users.Add(userDto);
            return await Task.FromResult(userDto);
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, UserDto userDto)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.PasswordHash = userDto.PasswordHash;
            existingUser.Role = userDto.Role;

            return await Task.FromResult(existingUser);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return await Task.FromResult(false);
            }

            _users.Remove(user);
            return await Task.FromResult(true);
        }
    }
}
