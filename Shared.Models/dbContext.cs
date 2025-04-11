using Microsoft.EntityFrameworkCore;

namespace Shared.Models
{
    public class dbContext : DbContext
    {
        public DbSet<LineInfo> LineInfo { get; set; }
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<LineInfo>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd(); 
        }
    }

    public class LineInfo
    {
        public int Id { get; set; }
        public string Line { get; set; }
        public string CF { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
    public class Request
    {
        public int Id { get; set; }
    }

}
