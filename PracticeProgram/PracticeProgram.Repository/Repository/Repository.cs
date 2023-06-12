using Microsoft.EntityFrameworkCore;
using PracticeProgram.Migrations;
using PracticeProgram.Repository.IRepository;

namespace PracticeProgram.Repository.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
        {
            var entity =await dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
          await  dbContext.Set<TEntity>().AddAsync(entity);
          var isSave = await dbContext.SaveChangesAsync();
            return isSave > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            var isSave = await dbContext.SaveChangesAsync();
            return isSave > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            var isSave = await dbContext.SaveChangesAsync();
            return isSave > 0;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
            var rowsAffected = await dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
            var rowsAffected = await dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

    }

}
