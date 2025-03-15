namespace PasswordGenerator.Services
{
    public interface IGenerateCharacters
    {
        public string GenerateUpperCaseLetters(int length);
        public string GenerateLowerCaseLetters(int length);
        public string GenerateNumbers(int length);
        public string GenerateSymbols(int length);
    }
}
