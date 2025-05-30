using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class DesiredLanguageService(BaseRepository<DesiredLanguage> repository)
    : BaseService<DesiredLanguage>(repository), IDesiredLanguageService
{

}
