namespace Api.Domain.Models;

public record UserDTO(
    int Id,
    string Name,
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

public record UserSimplifiedDTO(
    int Id,
    string Name,
    string Email,
    string? Phone
)
{
    public static UserSimplifiedDTO Map(User obj)
    {
        return new UserSimplifiedDTO(
            obj.Id,
            obj.Name,
            obj.Email,
            obj.Phone
        );
    }
}

public record UserProfileDTO(
    int Id,
    string Name,
    string Email,
    string? Phone,
    string? Address,
    string? Bio
)
{
    public static UserProfileDTO Map(User obj)
    {
        return new UserProfileDTO(
            obj.Id,
            obj.Name,
            obj.Email,
            obj.Phone,
            obj.Address,
            obj.Bio
        );
    }
}