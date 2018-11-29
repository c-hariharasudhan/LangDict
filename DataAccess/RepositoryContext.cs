using Microsoft.EntityFrameworkCore;
using NewDictionary.Entity;

namespace NewDictionary.DataAccess {
public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }
 
        public DbSet<Note> Notes { get; set; }
        // public DbSet<Account> Accounts { get; set; }
    }
}