namespace PasswordGenerator.Services
{
    public interface IPasswordService
    {
        public Task<string> Generate(int passwordLength, List<AbstractOption> options);

        public void GetLengthOfCharacters(List<AbstractOption> options);

        public Task<string> SetPassword(List<string> characters);
    }
}
