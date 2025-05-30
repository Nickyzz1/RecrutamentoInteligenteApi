using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class DesiredSkillRepository(DaredeDbContext context)
    : BaseRepository<DesiredSkill>(context), IDesiredSkillRepository
{
    
}
