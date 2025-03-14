using PasswordGenerator.Model;

namespace PasswordGenerator.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbAll01ProdUswest001Context _context = new DbAll01ProdUswest001Context();

        public IRepository<Model.PasswordGenerator> UserBucketRepository => new Repository<Model.PasswordGenerator>(_context);

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
