namespace Api.Domain.Models;

public record DesiredEducationDTO(
    int Id,
    string Name,
    EEducationType Type,
    bool Required
)
{
    public static DesiredEducationDTO Map(DesiredEducation obj)
    {
        return new DesiredEducationDTO(
            obj.Id,
            obj.Name,
            obj.Type,
            obj.Required
        );
    }
}
