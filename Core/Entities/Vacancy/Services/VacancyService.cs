using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Api.Core.Services;

public class VacancyService(BaseRepository<Vacancy> repository)
    : BaseService<Vacancy>(repository), IVacancyService
{
    public BaseRepository<Vacancy> repository = repository;
    public async Task<IEnumerable<Vacancy>> GetVacancies(System.Linq.Expressions.Expression<Func<Vacancy, bool>> filter, int page, int limit)
    {
        return await repository.Get().Include(obj => obj.DesiredSkills).Where(filter).Skip(page * limit).Take(limit).ToListAsync();
    }
}
