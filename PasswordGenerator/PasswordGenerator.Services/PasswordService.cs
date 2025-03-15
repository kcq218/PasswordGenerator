
namespace PasswordGenerator.Services
{
    public class PasswordService : IPasswordService
    {
        private int _passwordLength;
        private int _rulesSelected = 0;

        public async Task<string> Generate(int passwordLength, List<AbstractOption> options)
        {
            _passwordLength = passwordLength;
            GetLengthOfCharacters(options);
            return "";
        }

        public async void GetLengthOfCharacters(List<AbstractOption> options)
        {
            var lengthOfCharacters = new LengthOfCharacters();

            if (_passwordLength > 4)
            {
                foreach (var option in options)
                {
                    if (option.Included)
                    {
                        ++_rulesSelected;
                    }
                }

                var lengthOfEachRule = _passwordLength / _rulesSelected;
                var remainder = _passwordLength % _rulesSelected;

                foreach (var option in options)
                {
                    if (option.Included)
                    {
                        option.Length = lengthOfEachRule;
                    }
                }

                while (remainder > 0)
                {
                    foreach (var option in options)
                    {
                        if (option.Included)
                        {
                            ++option.Length;
                            --remainder;
                        }
                    }
                }
            }
        }

        public async Task<string> SetPassword(List<string> characters)
        {
            throw new NotImplementedException();
        }
    }
}
