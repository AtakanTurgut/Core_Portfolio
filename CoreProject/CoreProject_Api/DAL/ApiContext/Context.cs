using CoreProject_Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreProject_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R6K64T9\\SQLEXPRESS;database=CoreProjectApiDb;integrated security=true");
        }

        public DbSet<TodoListApi> TodoLists { get; set; }
    }
}
