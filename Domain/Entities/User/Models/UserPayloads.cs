using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class UserRegisterPayload
{
    [Required]
    [MaxLength(50)]
    public required string Name {get;set;}
    [Required]
    [MaxLength(100)]
    public required string Password {get;set;}
    [Required]
    [MaxLength(100)]
    public required string PasswordRepeat {get;set;}
    [Required]
    [MaxLength(100)]
    public required string Email {get;set;}
    [MaxLength(20)]
    public string? Phone {get;set;}
}

public class UserProfileUpdatePayload
{
    [MaxLength(50)]
    public string? Name {get;set;}
    [MaxLength(100)]
    public string? Email {get;set;}
    [MaxLength(20)]
    public string? Phone {get;set;}
    [MaxLength(255)]
    public string? Address {get;set;}
    public string? Bio {get;set;}
    [MaxLength(100)]
    public string? Password {get;set;}
    [MaxLength(100)]
    public string? PasswordRepeat {get;set;}
    [MaxLength(100)]
    public string? OldPassword {get;set;}
}

public class UserAuthPayload
{
    [Required]
    [MaxLength(100)]
    public required string Email {get;set;}
    [Required]
    [MaxLength(100)]
    public required string Password {get;set;}
}

