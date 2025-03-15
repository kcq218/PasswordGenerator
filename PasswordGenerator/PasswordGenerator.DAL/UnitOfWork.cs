using PasswordGenerator.Model;

namespace PasswordGenerator.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context)
        {

            _context = context;
        }

        public IRepository<Model.PasswordGenerator> PasswordGeneratorRepository => new Repository<Model.PasswordGenerator>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
