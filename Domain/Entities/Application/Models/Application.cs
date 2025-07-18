namespace Api.Domain.Models;

public class Application : IEntity
{
    public required User Candidate {get;set;}
    public required Vacancy Vacancy {get;set;}
    public EApplicationStatus Status {get;set;} = EApplicationStatus.Analysis;
    public required string Note {get;set;} = "";
    public DateTime AppliedAt {get;set;} = DateTime.Now;
    public Stage? DismissalStage {get;set;}
}
