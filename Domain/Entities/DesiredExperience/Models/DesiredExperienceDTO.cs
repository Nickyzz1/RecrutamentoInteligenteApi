namespace Api.Domain.Models;

public record DesiredExperienceDTO(
    int Id,
    string Name,
    int Time,
    bool Required
)
{
    public static DesiredExperienceDTO Map(DesiredExperience obj)
    {
        return new DesiredExperienceDTO(
            obj.Id,
            obj.Name,
            obj.Time,
            obj.Required
        );
    }
}
