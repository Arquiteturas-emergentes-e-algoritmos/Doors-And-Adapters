using Microsoft.EntityFrameworkCore;

namespace DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //
        // https://stackoverflow.com/questions/76865106/net-entity-framework-dbcontext-use-same-model-class-for-multiple-tables
        //
    }
}
