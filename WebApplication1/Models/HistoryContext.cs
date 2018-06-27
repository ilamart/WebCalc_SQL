using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class HistoryContext : DbContext
    {
        public DbSet<Note> History { get; set; }
        public HistoryContext(DbContextOptions<HistoryContext> options)
            : base(options)
        {
        }
    }
}