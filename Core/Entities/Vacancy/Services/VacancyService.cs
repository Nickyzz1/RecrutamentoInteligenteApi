using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class VacancyService(BaseRepository<Vacancy> repository)
    : BaseService<Vacancy>(repository), IVacancyService
{

}
