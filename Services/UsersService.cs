using Newtonsoft.Json;
using UsersManager.Interfaces;
using UsersManager.Models;

namespace UsersManager.Services;

public class UsersService : IUsersService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public UsersService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<User> GetUserDataAsync(int userId)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }

        return null;
    }

    public async Task<List<User>> GetAllUsersDataAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        return null;
    }
}
