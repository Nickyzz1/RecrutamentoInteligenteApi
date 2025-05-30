using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class StageService(BaseRepository<Stage> repository)
    : BaseService<Stage>(repository), IStageService
{

}
