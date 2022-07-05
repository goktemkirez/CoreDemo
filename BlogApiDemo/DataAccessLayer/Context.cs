using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=goktemkirez.database.windows.net,1433;database=TestDB;" +
            //    "user id=goktemkirez; password=Pujz5lpvg1; " +
            //    "integrated security=false;");

            optionsBuilder.UseSqlServer("server=GOKTEMKIREZ-PC;database=CoreBlogApiDb; " +
                "integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
