namespace Api.Domain.Models;

public record InterestDTO(
    int Id,
    string Name
)
{
    public static InterestDTO Map(Interest obj)
    {
        return new InterestDTO(
            obj.Id,
            obj.Name
        );
    }
}
