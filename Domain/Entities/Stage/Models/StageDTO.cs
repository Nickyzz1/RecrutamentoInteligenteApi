namespace Api.Domain.Models;

public record StageDTO(
    int Id,
    string Description,
    DateTime StartDate,
    DateTime EndDate
)
{
    public static StageDTO Map(Stage obj)
    {
        return new StageDTO(
            obj.Id,
            obj.Description,
            obj.StartDate,
            obj.EndDate
        );
    }
}
