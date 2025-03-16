namespace PasswordGenerator.Services
{
    public interface IPasswordService
    {
        public Task<string> Generate(int passwordLength, List<AbstractOption> options);

        public void SetLengthOfCharacters(List<AbstractOption> options);

        public string SetCharacters(List<AbstractOption> options, int passwordLength);

        public Task<bool> PasswordExists(string password);

        public string Shuffle(string characters, int length);
        public string ShuffleWithoutRepeat(string characters, int length);

    }
}
