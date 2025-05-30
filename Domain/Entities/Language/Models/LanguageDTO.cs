namespace Api.Domain.Models;

public record LanguageDTO(
    int Id,
    string Name,
    EProficiencyLevel Level
)
{
    public static LanguageDTO Map(Language obj)
    {
        return new LanguageDTO(
            obj.Id,
            obj.Name,
            obj.Level
        );
    }
}
