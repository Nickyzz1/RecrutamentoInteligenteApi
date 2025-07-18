using Api.Domain.Models;

namespace Api.Domain.Services;

public interface IVacancyService : IService<Vacancy>
{
    public Task<IEnumerable<Vacancy>> GetVacancies(System.Linq.Expressions.Expression<Func<Vacancy, bool>> filter, int page, int limit);
}
