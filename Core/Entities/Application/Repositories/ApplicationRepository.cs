using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class ApplicationRepository(DaredeDbContext context)
    : BaseRepository<Application>(context), IApplicationRepository
{
    
}
