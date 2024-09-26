using DoorsAndAdapters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        const string tableName = "Users";

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Glucometer, t =>
        {
            t.OwnsMany(p => p.GlucoseTests);
        });
        builder.OwnsOne(x => x.MedicationPlan, t =>
        {
            t.OwnsMany(p => p.Medications);
        });
    }
}
