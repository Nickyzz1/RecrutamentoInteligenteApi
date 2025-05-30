using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class VacancyAttributeService(BaseRepository<VacancyAttribute> repository)
    : BaseService<VacancyAttribute>(repository), IVacancyAttributeService
{

}
