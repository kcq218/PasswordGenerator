
namespace PasswordGenerator.Services
{
    public abstract class AbstractOption
    {
        public abstract int Length { get; set; }
        public abstract bool Included { get; set; }
        public abstract string Characters();
    }
}