namespace Api.Domain.Models;

public record ApplicationDTO(
    int Id,
    int CandidateId,
    int VacancyId,
    EApplicationStatus Status,
    string Note,
    int? DismissalStageId
)
{
    public static ApplicationDTO Map(Application obj)
    {
        return new ApplicationDTO(
            obj.Id,
            obj.Candidate.Id,
            obj.Vacancy.Id,
            obj.Status,
            obj.Note,
            obj.DismissalStage?.Id
        );
    }
}

public record ApplicationFullDTO(
    int Id,
    UserDTO Candidate,
    EApplicationStatus Status,
    string Note,
    StageDTO? DismissalStage
)
{
    public static ApplicationFullDTO Map(Application obj)
    {
        return new ApplicationFullDTO(
            obj.Id,
            UserDTO.Map(obj.Candidate),
            obj.Status,
            obj.Note,
            obj.DismissalStage != null ? StageDTO.Map(obj.DismissalStage) : null
        );
    }
}
