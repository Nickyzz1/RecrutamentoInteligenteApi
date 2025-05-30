namespace Api.Domain.Models;

public record ExperienceDTO(
    int Id,
    string Company,
    string Role,
    string Description,
    string Location,
    DateTime StartDate,
    DateTime? EndDate
)
{
    public static ExperienceDTO Map(Experience obj)
    {
        return new ExperienceDTO(
            obj.Id,
            obj.Company,
            obj.Role,
            obj.Description,
            obj.Location,
            obj.StartDate,
            obj.EndDate
        );
    }
}
