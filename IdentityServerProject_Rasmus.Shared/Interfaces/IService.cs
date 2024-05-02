namespace IdentityServerProject_Rasmus.Shared.Interfaces;

public interface IService<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> GetByIdAsync(Guid id);

    public Task<T> CreateAsync(T entity);

    public Task<T> UpdateAsync(T entity);

    public Task<T> DeleteByIdAsync(Guid id);
}