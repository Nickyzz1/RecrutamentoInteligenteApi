namespace Api.Domain.Models;

public record VacancyAttributeDTO(
    int Id,
    string Name,
    EAttributeType Type
)
{
    public static VacancyAttributeDTO Map(VacancyAttribute obj)
    {
        return new VacancyAttributeDTO(
            obj.Id,
            obj.Name,
            obj.Type
        );
    }
}

public record NoTypeAttributeDTO(
    int Id,
    string Name
)
{
    public static NoTypeAttributeDTO Map(VacancyAttribute obj)
    {
        return new NoTypeAttributeDTO(
            obj.Id,
            obj.Name
        );
    }
}
