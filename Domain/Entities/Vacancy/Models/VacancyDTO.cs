namespace Api.Domain.Models;

public record VacancyFullDTO(
    int Id,
    string Title,
    string Description,
    int WorkDays,
    DateTime WorkStart,
    DateTime WorkEnd,
    DateTime CreatedAt,
    bool CanApply,
    IEnumerable<NoTypeAttributeDTO> Requirements,
    IEnumerable<NoTypeAttributeDTO> Benefits,
    IEnumerable<NoTypeAttributeDTO> Assignments,
    IEnumerable<StageDTO> Stages,
    IEnumerable<DesiredExperienceDTO> DesiredExperiences,
    IEnumerable<DesiredEducationDTO> DesiredEducations,
    IEnumerable<DesiredSkillDTO> DesiredSkills,
    IEnumerable<DesiredLanguageDTO> DesiredLanguages
)
{
    public static VacancyFullDTO Map(Vacancy obj)
    {
        return new VacancyFullDTO(
            obj.Id,
            obj.Title,
            obj.Description,
            (int)obj.WorkDays,
            obj.WorkStart,
            obj.WorkEnd,
            obj.CreatedAt,
            obj.CanApply,
            obj.Attributes.Where(item => item.Type == EAttributeType.Requirement).Select(item => NoTypeAttributeDTO.Map(item)),
            obj.Attributes.Where(item => item.Type == EAttributeType.Benefit).Select(item => NoTypeAttributeDTO.Map(item)),
            obj.Attributes.Where(item => item.Type == EAttributeType.Assignment).Select(item => NoTypeAttributeDTO.Map(item)),
            obj.Stages.Select(item => StageDTO.Map(item)),
            obj.DesiredExperiences.Select(item => DesiredExperienceDTO.Map(item)),
            obj.DesiredEducations.Select(item => DesiredEducationDTO.Map(item)),
            obj.DesiredSkills.Select(item => DesiredSkillDTO.Map(item)),
            obj.DesiredLanguages.Select(item => DesiredLanguageDTO.Map(item))
        );
    }
}

public record VacancyStatsDTO(
    int TotalVacancies,
    int TotalActiveVacancies,
    int TotalApplications,
    int AverageApplications
){}

public record VacancyDTO(
    int Id,
    string Title,
    string Description,
    int WorkDays,
    DateTime WorkStart,
    DateTime WorkEnd,
    DateTime CreatedAt,
    bool CanApply,
    IEnumerable<string> Requirements,
    IEnumerable<string> Benefits,
    IEnumerable<string> Assignments,
    IEnumerable<string> Skills,
    IEnumerable<StageDTO> Stages
)
{
    public static VacancyDTO Map(Vacancy obj)
    {
        return new VacancyDTO(
            obj.Id,
            obj.Title,
            obj.Description,
            (int)obj.WorkDays,
            obj.WorkStart,
            obj.WorkEnd,
            obj.CreatedAt,
            obj.CanApply,
            obj.Attributes.Where(item => item.Type == EAttributeType.Requirement).Select(item => item.Name),
            obj.Attributes.Where(item => item.Type == EAttributeType.Benefit).Select(item => item.Name),
            obj.Attributes.Where(item => item.Type == EAttributeType.Assignment).Select(item => item.Name),
            obj.DesiredSkills.Select(item => item.Name),
            obj.Stages.Select(item => StageDTO.Map(item))
        );
    }
}

public record VacancySimplifiedDTO(
    int Id,
    string Title,
    string Description,
    bool CanApply,
    DateTime CreatedAt,
    IEnumerable<string> Skills
)
{
    public static VacancySimplifiedDTO Map(Vacancy obj)
    {
        return new VacancySimplifiedDTO(
            obj.Id,
            obj.Title,
            obj.Description,
            obj.CanApply,
            obj.CreatedAt,
            obj.DesiredSkills.Select(skill => skill.Name)
        );
    }
}

public record NoDetailsVacancyDTO(
    int Id,
    string Title,
    string Description,
    bool CanApply,
    int WorkDays,
    DateTime WorkStart,
    DateTime WorkEnd,
    DateTime CreatedAt
)
{
    public static NoDetailsVacancyDTO Map(Vacancy obj)
    {
        return new NoDetailsVacancyDTO(
            obj.Id,
            obj.Title,
            obj.Description,
            obj.CanApply,
            (int)obj.WorkDays,
            obj.WorkStart,
            obj.WorkEnd,
            obj.CreatedAt
        );
    }
}

public record EvenSimplerVacancyDTO(
    int IdVacancy,
    string Title,
    string Stage
)
{
    public static EvenSimplerVacancyDTO Map(Vacancy obj)
    {
        return new EvenSimplerVacancyDTO(
            obj.Id,
            obj.Title,
            obj.Stages
                .TakeWhile(stage => stage.StartDate < DateTime.Now)
                .Select(stage => stage.Description)
                .LastOrDefault(obj.Stages.Select(stage => stage.Description).FirstOrDefault("Nenhuma etapa disponível"))
        );
    }
}