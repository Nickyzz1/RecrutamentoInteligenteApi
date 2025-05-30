using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class SkillRepository(DaredeDbContext context)
    : BaseRepository<Skill>(context), ISkillRepository
{
    
}
