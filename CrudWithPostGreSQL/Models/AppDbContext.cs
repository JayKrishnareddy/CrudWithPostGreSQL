using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CrudWithPostGreSQL.Models
{
    public interface IDataContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
    public class AppDbContext : DbContext,IDataContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
