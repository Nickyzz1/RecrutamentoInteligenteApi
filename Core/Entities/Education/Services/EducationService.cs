using Api.Core.Repositories;
using Api.Domain.Models;
using Api.Domain.Services;

namespace Api.Core.Services;

public class EducationService(BaseRepository<Education> repository)
    : BaseService<Education>(repository), IEducationService
{

}
