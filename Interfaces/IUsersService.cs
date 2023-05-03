using UsersManager.Models;

namespace UsersManager.Interfaces;

public interface IUsersService
{
    Task<User> GetUserDataAsync(int userId);
    Task<List<User>> GetAllUsersDataAsync();
}
