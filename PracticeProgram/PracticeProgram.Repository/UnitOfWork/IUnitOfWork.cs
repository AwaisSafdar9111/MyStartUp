using PracticeProgram.Repository;
using PracticeProgram.Repository.IRepository;
using System;

namespace PracticeProgram.Repository.UnitOfWork
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        public IRepository<TEntity> GenericRepository { get; }

        TRepository GetRepository<TRepository>();
    }
}
