using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class VacancyAttributeRepository(DaredeDbContext context)
    : BaseRepository<VacancyAttribute>(context), IVacancyAttributeRepository
{
    
}
