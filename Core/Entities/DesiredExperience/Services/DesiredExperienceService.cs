using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class DesiredExperienceService(BaseRepository<DesiredExperience> repository)
    : BaseService<DesiredExperience>(repository), IDesiredExperienceService
{

}
