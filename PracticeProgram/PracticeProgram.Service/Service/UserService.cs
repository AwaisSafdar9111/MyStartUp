using PracticeProgram.Models.Entity;
using PracticeProgram.Repository.Repository;
using PracticeProgram.Repository.UnitOfWork;
using PracticeProgram.Service.IService;

namespace PracticeProgram.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<User> _unitOfWork;
        public UserService(IUnitOfWork<User> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private async void GetUserLogin(int userId)
        {
            try
            {
                var userRepository = _unitOfWork.GetRepository<UserRepository>();
                var loginUserInfo = await userRepository.GetLoginUserInfo(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
