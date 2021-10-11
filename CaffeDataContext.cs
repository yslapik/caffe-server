using caffeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace caffeServer
{
    public class CaffeDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"");
        }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<DailyResidues> DailyResidues { get; set; } 
        public DbSet<DailySales> DailySales { get; set; }
        public DbSet<Residues> Residues { get; set; }
    }
}