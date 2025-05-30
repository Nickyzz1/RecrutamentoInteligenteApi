using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class LanguageService(BaseRepository<Language> repository)
    : BaseService<Language>(repository), ILanguageService
{

}
