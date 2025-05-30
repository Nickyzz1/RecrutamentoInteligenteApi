using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class InterestService(BaseRepository<Interest> repository)
    : BaseService<Interest>(repository), IInterestService
{

}
