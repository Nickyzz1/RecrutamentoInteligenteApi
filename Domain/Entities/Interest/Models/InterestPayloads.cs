using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class InterestCreatePayload
{
    [Required]
    [MaxLength(50)]
    public required string Name {get;set;}
}

public class InterestUpdatePayload
{
    public string? Name {get;set;}

}
