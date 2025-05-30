using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class ExperienceService(BaseRepository<Experience> repository)
    : BaseService<Experience>(repository), IExperienceService
{

}
