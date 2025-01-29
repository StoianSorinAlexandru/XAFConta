using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace XAFContaApp.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891/core-prerequisites-for-design-time-model-editor-with-entity-framework-core-data-model.
public class XAFContaAppContextInitializer : DbContextTypesInfoInitializerBase {
    protected override DbContext CreateDbContext() {
        var optionsBuilder = new DbContextOptionsBuilder<XAFContaAppEFCoreDbContext>()
            .UseSqlServer("Data Source=DESKTOP-VRT8UFH;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")//.UseSqlite(";") wrong for a solution with SqLite, see https://isc.devexpress.com/internal/ticket/details/t1240173
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new XAFContaAppEFCoreDbContext(optionsBuilder.Options);
    }
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class XAFContaAppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<XAFContaAppEFCoreDbContext> {
    public XAFContaAppEFCoreDbContext CreateDbContext(string[] args) {
        //throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        //var optionsBuilder = new DbContextOptionsBuilder<XAFContaAppEFCoreDbContext>();
        //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=XAFContaApp");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
        //return new XAFContaAppEFCoreDbContext(optionsBuilder.Options);
        var optionsBuilder = new DbContextOptionsBuilder<XAFContaAppEFCoreDbContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-VRT8UFH;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
        return new XAFContaAppEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(XAFContaAppContextInitializer))]
public class XAFContaAppEFCoreDbContext : DbContext {
    public XAFContaAppEFCoreDbContext(DbContextOptions<XAFContaAppEFCoreDbContext> options) : base(options) {
    }

    public DbSet<Gestion> Gestions { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Exit> Exits { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<DetailedEntry> DetailedEntries { get; set; }
    public DbSet<DetailedExit> DetailedExits { get; set; }
    public DbSet<ReportDataV2> ReportData { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseDeferredDeletion(this);
        modelBuilder.SetOneToManyAssociationDeleteBehavior(DeleteBehavior.SetNull, DeleteBehavior.Cascade);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
