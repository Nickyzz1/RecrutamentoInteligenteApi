using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class VacancyAttributeCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Name {get;set;}
}