using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models;

public class ApplicationCreatePayload
{
    [Required]
    public required int VacancyId {get;set;}
    [Required]
    public required string Note {get;set;}
}

public class ApplicationUpdatePayload
{
    public string? Note {get;set;}
}

public class ApplicationStatusUpdatePayload
{

    public NullableUpdatePayload<int>? DismissalStageId;
}