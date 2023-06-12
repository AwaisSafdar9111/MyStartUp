using PracticeProgram.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProgram.Repository.IRepository
{
    public interface IUserReposity:IRepository<User>
    {
        Task<User> GetLoginUserInfo(int userId);
    }
}
