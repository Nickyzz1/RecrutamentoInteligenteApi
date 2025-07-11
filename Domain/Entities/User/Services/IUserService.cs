using Api.Domain.Models;

namespace Api.Domain.Services;

public interface IUserService : IService<User>
{
    public Task<User?> Auth(string email, string password);
    public Task<bool> Register(UserRegisterPayload data);
}
