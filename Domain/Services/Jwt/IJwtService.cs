using Api.Domain.Models;

namespace Api.Domain.Services;

public class LocalUser(int Id, string Name, bool Admin)
{
    private int _id = Id;
    private string _name = Name;
    private bool _admin = Admin;

    public int Id => _id;
    public string Name => _name;
    public bool Admin => _admin;

    public void Set(LocalUser localUser)
    {
        this._id = localUser.Id;
        this._name = localUser.Name;
        this._admin = localUser.Admin;
    }
}

public record JwtSettings(string SecretKey);

public interface IJwtService
{
    public string GenerateToken(UserDTO user);
    public LocalUser? ValidateToken(string jwt);
}