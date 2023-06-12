using Microsoft.EntityFrameworkCore;
using PracticeProgram.Migrations;
using PracticeProgram.Models.Entity;
using PracticeProgram.Repository.IRepository;

namespace PracticeProgram.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserReposity
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        private readonly ApplicationDbContext dbContext;

        public async Task<User> GetLoginUserInfo(int userId)
        {
            return await (from user in dbContext.Users
                        where Convert.ToInt32(user.Id) == userId
                        select user).FirstOrDefaultAsync();
        }
    }
}
