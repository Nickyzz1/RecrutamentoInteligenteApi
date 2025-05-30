namespace Api.Domain.Models;

public record DesiredSkillDTO(
    int Id,
    string Name,
    bool Required
)
{
    public static DesiredSkillDTO Map(DesiredSkill obj)
    {
        return new DesiredSkillDTO(
            obj.Id,
            obj.Name,
            obj.Required
        );
    }
}
