using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class ApplicationService(BaseRepository<Application> repository)
    : BaseService<Application>(repository), IApplicationService
{

}
