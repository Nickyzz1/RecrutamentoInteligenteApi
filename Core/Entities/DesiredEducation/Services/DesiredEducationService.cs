using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class DesiredEducationService(BaseRepository<DesiredEducation> repository)
    : BaseService<DesiredEducation>(repository), IDesiredEducationService
{

}
