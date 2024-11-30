using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Database;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Customize the model creating logic for your application
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Call the base method to apply Identity's default model configuration
        base.OnModelCreating(builder);

        // Customize your User entity's properties
        builder.Entity<User>(entity =>
        {
            // Example of configuring the Initials property
            entity.Property(u => u.Initials)
                .HasMaxLength(5)
                .IsRequired(false); // Example: Mark it as optional
        });

        // Optional: If you're using a custom schema for Identity tables
        builder.HasDefaultSchema("identity");

        // You can also configure any additional entities or relationships here
    }

    // Add additional DbSets if necessary, for example:
    // public DbSet<SomeOtherEntity> SomeOtherEntities { get; set; }
}
