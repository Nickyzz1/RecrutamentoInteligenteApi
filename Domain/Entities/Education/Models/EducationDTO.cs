namespace Api.Domain.Models;

public record EducationDTO(
    int Id,
    string Institution,
    string Course,
    EEducationStatus Status,
    DateTime StartDate,
    DateTime? EndDate,
    EEducationType Type
)
{
    public static EducationDTO Map(Education obj)
    {
        return new EducationDTO(
            obj.Id,
            obj.Institution,
            obj.Course,
            obj.Status,
            obj.StartDate,
            obj.EndDate,
            obj.Type
        );
    }
}
