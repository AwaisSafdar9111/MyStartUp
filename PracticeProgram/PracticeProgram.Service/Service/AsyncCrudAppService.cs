using PracticeProgram.Repository.UnitOfWork;
using PracticeProgram.Service.IService;

namespace PracticeProgram.Service.Service
{
    public class AsyncCrudAppService<TEntity, TPrimaryKey, TCreateOrUpdateViewModel, TDisplayViewModel> : IAsyncCrudAppService<TEntity, TPrimaryKey, TCreateOrUpdateViewModel, TDisplayViewModel>
    where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;

        public AsyncCrudAppService(IUnitOfWork<TEntity> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //public async Task<TDisplayViewModel> GetAsync(TPrimaryKey id)
        //{
        //    TEntity entity = await _unitOfWork.GenericRepository.GetByIdAsync(id);
        //   // TDisplayViewModel viewModel = MapEntityToDisplayViewModel(entity);
        //    return viewModel;
        //}

        //public async Task<TPrimaryKey> CreateAsync(TCreateOrUpdateViewModel viewModel, TEntity entity)
        //{
        //    // await _unitOfWork.GenericRepository.AddAsync(MapCreateOrUpdateViewModelToEntity(viewModel, entity));
        //    //return GetPrimaryKeyValue(entity);
        //    return new TPrimaryKey();
        //}

        //public async Task<bool> UpdateAsync(TPrimaryKey id, TCreateOrUpdateViewModel viewModel)
        //{
        //    TEntity entity =  await _unitOfWork.GenericRepository.GetByIdAsync(id);
        //    if (entity == null)
        //    {
        //        return false;
        //    }

        //   // MapCreateOrUpdateViewModelToEntity(viewModel, entity);
        //    return true;
        //}

        //public async Task<bool> DeleteAsync(TPrimaryKey id)
        //{
        //    TEntity entity = await _unitOfWork.GenericRepository.GetByIdAsync(id);
        //    if (entity == null)
        //    {
        //        return false;
        //    }

        //    await _unitOfWork.GenericRepository.DeleteAsync(entity);
           
        //    return true;
        //}

        //private TDisplayViewModel MapEntityToDisplayViewModel(TEntity entity)
        //{
        //    return null;
        //}

        //private TEntity MapCreateOrUpdateViewModelToEntity(TCreateOrUpdateViewModel viewModel,TEntity entity)
        //{
        //}

        //private TPrimaryKey GetPrimaryKeyValue(TEntity entity)
        //{
        //}
    }
}
