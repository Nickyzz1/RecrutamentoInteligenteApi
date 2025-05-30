namespace Api.Domain.Models;

public class Application : IEntity
{
    public required User Candidate {get;set;}
    public required Vacancy Vacancy {get;set;}
    public required EApplicationStatus Status {get;set;} = EApplicationStatus.Pending;
    public required string Note {get;set;} = "";
    public Stage? DismissalStage {get;set;}
}
