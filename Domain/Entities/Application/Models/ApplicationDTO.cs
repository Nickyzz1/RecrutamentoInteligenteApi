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
