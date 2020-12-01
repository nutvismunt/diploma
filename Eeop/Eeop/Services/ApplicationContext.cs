using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eeop.Models
{
    class ApplicationContext : DbContext
    {
        private string _dbPath;
        public DbSet <ClientProfile> ClientProfiles { get; set; }
        public DbSet<NoteElement> NoteElements { get; set; }
        public ApplicationContext (string dbPath)
        {
            _dbPath = dbPath;
        }

        
      
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
