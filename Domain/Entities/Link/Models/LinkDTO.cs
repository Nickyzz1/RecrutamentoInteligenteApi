namespace Api.Domain.Models;

public record LinkDTO(
    int Id,
    string Url,
    string Description
)
{
    public static LinkDTO Map(Link obj)
    {
        return new LinkDTO(
            obj.Id,
            obj.Url,
            obj.Description
        );
    }
}
