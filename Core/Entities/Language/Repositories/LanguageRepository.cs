using Api.Domain.Models;
using Api.Domain.Repositories;

namespace Api.Core.Repositories;

public class LanguageRepository(DaredeDbContext context)
    : BaseRepository<Language>(context), ILanguageRepository
{
    
}
