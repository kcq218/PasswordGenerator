using Microsoft.EntityFrameworkCore;

namespace PasswordGenerator.Model;

public partial class DbAll01ProdUswest001Context : DbContext, IDbContext
{
    private readonly string? _connectionString;

    public DbAll01ProdUswest001Context()
    {
        _connectionString = Environment.GetEnvironmentVariable("connString") ?? throw new InvalidOperationException("Connection string not found.");
    }

    public DbAll01ProdUswest001Context(DbContextOptions<DbAll01ProdUswest001Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PasswordGenerator> PasswordGenerators { get; set; }


    public DbContext Context => this;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PasswordGenerator>(entity =>
        {
            entity.ToTable("PasswordGenerator");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_date");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
