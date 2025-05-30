using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class DesiredLanguageRepository(DaredeDbContext context)
    : BaseRepository<DesiredLanguage>(context), IDesiredLanguageRepository
{
    
}
