using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileManagementAPI.Database
{
  
        public class DBFileContext : DbContext
        {
            public DbSet<FileDB> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql("Host=localhost;Database=FilesDatabase;Username=postgres;Password=1234");
        }

}
