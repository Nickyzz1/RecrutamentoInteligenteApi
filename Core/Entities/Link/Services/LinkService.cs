using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class LinkService(BaseRepository<Link> repository)
    : BaseService<Link>(repository), ILinkService
{

}
