namespace PasswordGenerator.DAL
{
    public interface IUnitOfWork
    {
        public IRepository<Model.PasswordGenerator> PasswordGeneratorRepository { get; }
        public void Save();
        public void Dispose(bool disposing);
    }
}
