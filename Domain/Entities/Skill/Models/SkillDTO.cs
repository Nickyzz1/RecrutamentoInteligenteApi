namespace Api.Domain.Models;

public record SkillDTO(
    int Id,
    string Name
)
{
    public static SkillDTO Map(Skill obj)
    {
        return new SkillDTO(
            obj.Id,
            obj.Name
        );
    }
}
