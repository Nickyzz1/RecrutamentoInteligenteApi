namespace Api.Domain.Models;

public class VacancyAttribute : IEntity
{
    public required Vacancy Vacancy;
    public required string Name;
    public required EAttributeType Type;
}
