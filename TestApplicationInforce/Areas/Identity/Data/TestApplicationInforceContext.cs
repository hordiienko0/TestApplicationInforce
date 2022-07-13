using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApplicationInforce.Areas.Identity.Data;
using TestApplicationInforce.Models;

namespace TestApplicationInforce.Data;

public class TestApplicationInforceContext : IdentityDbContext<TestApplicationInforceUser>
{
    public TestApplicationInforceContext(DbContextOptions<TestApplicationInforceContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<UserUrlModel>()
            .HasKey(sc => new
            {
                sc.UserId,
                sc.UrlId
            });

        builder.Entity<UserUrlModel>()
               .HasOne<TestApplicationInforceUser>(sc => sc.User)
               .WithMany(s => s.UserUrls)
               .HasForeignKey(sc => sc.UserId);

        builder.Entity<UserUrlModel>()
            .HasOne<UrlModel>(sc => sc.Url)
            .WithMany(s => s.UserUrl)
             .HasForeignKey(sc => sc.UrlId);

        base.OnModelCreating(builder);

    }

    public DbSet<UrlModel> Urls { get; set; }
}
