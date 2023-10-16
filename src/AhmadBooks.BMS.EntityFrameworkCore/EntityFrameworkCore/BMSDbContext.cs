using AhmadBooks.BMS.Books;
using AhmadBooks.BMS.Groups;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace AhmadBooks.BMS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("Default")]
public class BMSDbContext :
    AbpDbContext<BMSDbContext>,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    #endregion

    public DbSet<Book> Books { get; set; }
    public DbSet<Group> Groups { get; set; }

    public BMSDbContext(DbContextOptions<BMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Group>(b =>
        {
            b.ToTable(BMSConsts.DbTablePrefix + "Groups", BMSConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(BookConsts.MaxNameLength);

            b.HasIndex(g => g.Name);

            b.HasMany(g => g.Members)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "GroupMember",
                j => j
                    .HasOne<IdentityUser>()
                    .WithMany()
                    .HasForeignKey("MemberId"),
                j => j
                    .HasOne<Group>()
                    .WithMany()
                    .HasForeignKey("GroupId"),
                j =>
                {
                    j.HasKey("GroupId", "MemberId");
                    j.ToTable(BMSConsts.DbTablePrefix + "GroupMembers", BMSConsts.DbSchema);
                });
        });

        builder.Entity<Book>(b =>
        {
            b.ToTable(BMSConsts.DbTablePrefix + "Books", BMSConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(b => b.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            b.HasMany(b => b.AssignedGroups)
            .WithMany(g => g.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookGroup",
                j => j.HasOne<Group>()
                        .WithMany()
                        .HasForeignKey("GroupId"),
                j => j.HasOne<Book>()
                        .WithMany()
                        .HasForeignKey("BookId"),
                j =>
                {
                    j.HasKey("BookId", "GroupId");
                    j.ToTable(BMSConsts.DbTablePrefix + "BooksAssignedGroups", BMSConsts.DbSchema);
                });
        });

    }
}
