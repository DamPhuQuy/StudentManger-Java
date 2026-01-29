using StudentManagement.Interfaces;

namespace StudentManagement.Repositories;

// Generic Repository Implementation - DRY Principle
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly List<T> _data;
    protected readonly Func<T, string> _idSelector;

    public Repository(Func<T, string> idSelector)
    {
        _data = new List<T>();
        _idSelector = idSelector;
    }

    public virtual void Add(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _data.Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _data.AddRange(entities);
    }

    public virtual void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var id = _idSelector(entity);
        var existingEntity = GetById(id);

        if (existingEntity != null)
        {
            _data.Remove(existingEntity);
            _data.Add(entity);
        }
    }

    public virtual void Delete(string id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _data.Remove(entity);
        }
    }

    public virtual T? GetById(string id)
    {
        return _data.FirstOrDefault(e => _idSelector(e) == id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _data.AsEnumerable();
    }

    public virtual IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _data.Where(predicate);
    }

    public virtual bool Exists(string id)
    {
        return _data.Any(e => _idSelector(e) == id);
    }

    public virtual int Count()
    {
        return _data.Count;
    }

    public virtual void SaveChanges()
    {
        // In a real application, this would persist to database
        // For now, data is kept in memory
    }
}
