using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class LinkRepository(DaredeDbContext context)
    : BaseRepository<Link>(context), ILinkRepository
{
    
}
