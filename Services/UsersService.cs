using UsersManager.Interfaces;
using UsersManager.Models;

namespace UsersManager.Services;

public class UsersService : IUsersService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string url = "https://jsonplaceholder.typicode.com/users";

    public UsersService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<User> GetUserDataAsync(int userId) =>
        await _httpClientFactory.CreateClient().GetFromJsonAsync<User>($"{url}/{userId}");

    public async Task<List<User>> GetAllUsersDataAsync() =>
        await _httpClientFactory.CreateClient().GetFromJsonAsync<List<User>>(url);
}
