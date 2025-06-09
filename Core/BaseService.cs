using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Api.Domain;

namespace Api.Core;

public class BaseService<T>(BaseRepository<T> repository) : IService<T>
    where T : IEntity
{
    protected readonly IRepository<T> Repository = repository;

    public virtual T? Add(T entity)
    {
        var obj = Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefault(item => item.Id == entity.Id);

        if(obj != null)
        {
            return null;
        }

        obj = Repository.Add(entity);
        Repository.Save();
        return obj;
    }

    public virtual async Task<T?> AddAsync(T entity)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefaultAsync(item => item.Id == entity.Id);

        if(obj != null)
        {
            return null;
        }

        obj = Repository.Add(entity);
        await Repository.SaveAsync();
        return obj;
    }

    public virtual T? Get(int id)
    {
        var obj = Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefault(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        return obj;
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefaultAsync(item => item.Id == id);

        if(obj is null)
        {
            return null;
        }

        return obj;
    }

    public virtual async Task<T?> GetAsync(int id, string include)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .Include(include)
            .SingleOrDefaultAsync(item => item.Id == id);

        if(obj is null)
        {
            return null;
        }

        return obj;
    }

    public virtual async Task<T?> GetAsync(int id, List<string> include)
    {
        var query = Repository.Get();

        foreach(var item in include)
        {
            query.Include(item);
        }
        
        var obj = await query.SingleOrDefaultAsync(item => item.Id == id);

        if(obj is null)
        {
            return null;
        }

        return obj;
    }

    public IEnumerable<T> GetAll()
    {
        return Repository.Get().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Repository.Get().ToListAsync();
    }

    public IEnumerable<T> GetAll(int page, int limit)
    {
        return Repository.Get().Skip(page * limit).Take(limit).ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync(int page, int limit)
    {
        return await Repository.Get().Skip(page * limit).Take(limit).ToListAsync();
    }

    public virtual T? Update(int id, T entity)
    {
        var obj = Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefault(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        var updated = Repository.Update(entity);
        Repository.Save();
        Repository.Detach(updated);
        return updated;
    }   

    public virtual async Task<T?> UpdateAsync(int id, T entity)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefaultAsync(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        var updated = Repository.Update(entity);

        await Repository.SaveAsync();
        Repository.Detach(updated);
        return updated;
    }
    
    public virtual T? Delete(int id)
    {
        var obj = Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefault(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        Repository.Remove(obj);
        Repository.Save();
        return obj;
    }

    public virtual async Task<T?> DeleteAsync(int id)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefaultAsync(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        Repository.Remove(obj);
        await Repository.SaveAsync();
        return obj;
    }
    public virtual async Task<T?> SoftDeleteAsync(int id)
    {
        var obj = await Repository
            .Get()
            .Where(obj => obj.IsActive)
            .SingleOrDefaultAsync(item => item.Id == id);

        if(obj == null)
        {
            return null;
        }

        obj.IsActive = false;

        Repository.Update(obj);
        await Repository.SaveAsync();
        return obj;
    }
}