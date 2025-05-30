using Api.Domain.Models;

namespace Api.Domain.Services;

public class LocalUser
{
    private int _id;
    private string _name = "";
    private bool _admin;

    public int Id => _id;
    public string Name => _name;
    public bool Admin => _admin;

    public void Set(LocalUser localUser)
    {
        this._id = localUser.Id;
        this._name = localUser.Name;
        this._admin = localUser.Admin;
    }
    public void Set(int id, string name, bool admin)
    {
        this._id = id;
        this._name = name;
        this._admin = admin;
    }
}

public record JwtSettings(string SecretKey);

public interface IJwtService
{
    public string GenerateToken(UserDTO user);
    public LocalUser? ValidateToken(string jwt);
}