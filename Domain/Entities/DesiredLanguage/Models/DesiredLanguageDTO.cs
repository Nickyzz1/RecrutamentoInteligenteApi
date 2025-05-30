namespace Api.Domain.Models;

public record DesiredLanguageDTO(
    int Id,
    string Name,
    EProficiencyLevel Level,
    bool Required
)
{
    public static DesiredLanguageDTO Map(DesiredLanguage obj)
    {
        return new DesiredLanguageDTO(
            obj.Id,
            obj.Name,
            obj.Level,
            obj.Required
        );
    }
}
