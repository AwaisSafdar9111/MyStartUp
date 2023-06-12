using PracticeProgram.Migrations;
using PracticeProgram.Repository.IRepository;
using PracticeProgram.Repository.Repository;

namespace PracticeProgram.Repository.UnitOfWork
{
    public class UnitOfWork<TEntity> where TEntity : class,IUnitOfWork<TEntity>
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _additionalRepositories;
        private IRepository<TEntity> _genericRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _additionalRepositories = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GenericRepository
        {
            get { return _genericRepository ??= new Repository<TEntity>(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var repositoryType = typeof(TRepository);

            if (_additionalRepositories.ContainsKey(repositoryType))
                return (TRepository)_additionalRepositories[repositoryType];

            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
            _additionalRepositories.Add(repositoryType, repositoryInstance);

            return (TRepository)repositoryInstance;
        }
    }
}
