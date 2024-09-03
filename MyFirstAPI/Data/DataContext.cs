
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFirstAPI.Entities;
using System.Security.Cryptography.X509Certificates;



namespace MyFirstAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        
    }
}
