using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValetaxTest.Domain.Models;

namespace ValetaxTest.Infrastructure.Data.Configurations;

public class TreeConfiguration : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Nodes)
            .WithOne(x => x.Tree)
            .HasForeignKey(x => x.TreeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}