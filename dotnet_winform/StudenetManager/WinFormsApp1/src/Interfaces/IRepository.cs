namespace StudentManagement.Interfaces;

// Generic Repository Interface - Interface Segregation Principle
public interface IRepository<T> where T : class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(string id);
    T? GetById(string id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Func<T, bool> predicate);
    bool Exists(string id);
    int Count();
    void SaveChanges();
}
