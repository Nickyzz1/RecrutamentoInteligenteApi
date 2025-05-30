using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class VacancyRepository(DaredeDbContext context)
    : BaseRepository<Vacancy>(context), IVacancyRepository
{
    
}
