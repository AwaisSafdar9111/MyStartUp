using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProgram.Service.IService
{
    public interface IAsyncCrudAppService<TEntity, TPrimaryKey, TCreateOrUpdateViewModel, TDisplayViewModel>
    where TEntity : class
    {
        //Task<TDisplayViewModel> GetAsync(TPrimaryKey id);
        //Task<TPrimaryKey> CreateAsync(TCreateOrUpdateViewModel viewModel,TEntity entity);
        //Task<bool> UpdateAsync(TPrimaryKey id, TCreateOrUpdateViewModel viewModel);
        //Task<bool> DeleteAsync(TPrimaryKey id);
    }
}
