namespace Api.Domain.Models;

public record UserDTO(
    int Id,
    string Name,
    string Password,
    string Email,
    string? Phone,
    string? Address,
    string? Bio,
    bool Admin,
    IEnumerable<InterestDTO> Interests,
    IEnumerable<EducationDTO> Educations,
    IEnumerable<ExperienceDTO> Experiences,
    IEnumerable<LanguageDTO> Languages,
    IEnumerable<SkillDTO> Skills,
    IEnumerable<LinkDTO> Links
)
{
    public static UserDTO Map(User obj)
    {
        return new UserDTO(
            obj.Id,
            obj.Name,
            obj.Password,
            obj.Email,
            obj.Phone,
            obj.Address,
            obj.Bio,
            obj.Admin,
            obj.Interests.Select(item => InterestDTO.Map(item)),
            obj.Educations.Select(item => EducationDTO.Map(item)),
            obj.Experiences.Select(item => ExperienceDTO.Map(item)),
            obj.Languages.Select(item => LanguageDTO.Map(item)),
            obj.Skills.Select(item => SkillDTO.Map(item)),
            obj.Links.Select(item => LinkDTO.Map(item))
        );
    }
}
