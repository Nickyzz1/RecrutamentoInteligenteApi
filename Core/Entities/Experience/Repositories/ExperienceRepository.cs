using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class ExperienceRepository(DaredeDbContext context)
    : BaseRepository<Experience>(context), IExperienceRepository
{
    
}
