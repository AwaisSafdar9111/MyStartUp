using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeProgram.Models.Entity;

namespace PracticeProgram.Migrations
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly DbConfiguration _configuration;
        public ApplicationDbContext(DbConfiguration configuration,
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.ConnectionString);
        }
    }

}
