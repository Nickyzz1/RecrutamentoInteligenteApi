using System.Threading.Tasks;
using Api.Domain.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Core.Services;

public class UserService(BaseRepository<User> repository, PasswordHasher<User> hasher)
    : BaseService<User>(repository), IUserService
{
    private readonly BaseRepository<User> userRepository = repository;
    private readonly PasswordHasher<User> hasher = hasher; 
    public async Task<User?> Auth(string email, string password)
    {
        User? user = await userRepository.Get()
            .Where(user => user.IsActive)
            .Where(user => user.Email == email)
            .FirstOrDefaultAsync();

        if(user == null){return null;}
        
        if(hasher.VerifyHashedPassword(user, user.Password, password) != PasswordVerificationResult.Success)
        {
            return null;
        }

        return user;
    }

    public async Task<bool> Register(UserRegisterPayload data)
    {
        User? existingUser = await userRepository.Get()
            .Where(user => user.Email == data.Email)
            .FirstOrDefaultAsync();

        if(existingUser != null)
        {
            return false;
        }

        User user = new User(){
            Name=data.Name,
            Email=data.Email,
            Password="",
            Admin=false
        };

        user.Password = hasher.HashPassword(user, data.Password);

        await this.AddAsync(user);

        return true;
    }
}
