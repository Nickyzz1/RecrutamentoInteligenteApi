using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class InterestRepository(DaredeDbContext context)
    : BaseRepository<Interest>(context), IInterestRepository
{
    
}
