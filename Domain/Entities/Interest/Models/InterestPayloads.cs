using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class InterestCreatePayload
{
    [Required]
    public required string Name {get;set;}
    [Required]
    public required int UserId {get;set;}
}

public class InterestUpdatePayload
{
    public string? Name {get;set;}
    public int? UserId {get;set;}

}
