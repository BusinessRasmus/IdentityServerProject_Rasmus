namespace IdentityServerProject_Rasmus.Shared.Interfaces;

public interface IService<T, TE> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> GetByIdAsync(TE id);

    public Task<bool> CreateAsync(T entity);

    public Task<T> UpdateAsync(T entity);

    public Task<bool> DeleteByIdAsync(Guid id);
}