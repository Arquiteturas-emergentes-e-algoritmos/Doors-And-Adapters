using DoorsAndAdapters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(u => u.Glucometer, g =>
        {
            g.OwnsMany(t => t.GlucoseTests);
        });
        builder.OwnsOne(u => u.MedicationPlan, m =>
        {
            m.OwnsMany(h => h.Medications);
        });
    }
}
