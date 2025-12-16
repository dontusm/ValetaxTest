using Microsoft.EntityFrameworkCore;
using ValetaxTest.Domain.Models;
using ValetaxTest.Infrastructure.Data.Configurations;

namespace ValetaxTest.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Tree> Trees { get; set; }
    
    public DbSet<Node> Nodes { get; set; }
    
    public DbSet<JournalEntry> JournalEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TreeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}