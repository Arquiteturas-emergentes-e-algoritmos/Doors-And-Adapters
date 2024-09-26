using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context.Config;
using Microsoft.EntityFrameworkCore;

namespace DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfig());

        //
        // https://stackoverflow.com/questions/76865106/net-entity-framework-dbcontext-use-same-model-class-for-multiple-tables
        //
    }
}
