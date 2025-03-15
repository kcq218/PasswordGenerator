using Microsoft.EntityFrameworkCore;

namespace PasswordGenerator.Model;

public interface IDbContext : IDisposable
{
    DbContext Context { get; }
    DbSet<PasswordGenerator> PasswordGenerators { get; set; }

    DbSet<T> Set<T>() where T : class;
    public int SaveChanges();
}