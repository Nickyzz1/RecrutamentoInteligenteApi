using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class DesiredEducationRepository(DaredeDbContext context)
    : BaseRepository<DesiredEducation>(context), IDesiredEducationRepository
{
    
}
