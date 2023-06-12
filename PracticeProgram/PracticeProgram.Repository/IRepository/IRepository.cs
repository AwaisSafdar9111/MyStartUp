using System;

namespace PracticeProgram.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync<TKey>(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllListAsync();

        Task<bool> AddAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> AddRangeAsync(List<TEntity> entities);


        Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
