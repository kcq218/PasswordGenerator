using PasswordGenerator.DAL;
using System.Text;

namespace PasswordGenerator.Services
{
    public class PasswordService : IPasswordService
    {
        private int _passwordLength;
        private int _rulesSelected = 0;
        private readonly IUnitOfWork _unitofWork;
        private string _password;
        private int _iterations;

        public PasswordService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<string> Generate(int passwordLength, List<AbstractOption> options)
        {
            _passwordLength = passwordLength;
            SetLengthOfCharacters(options);
            _password = SetCharacters(options, passwordLength);
            _iterations = 0;

            while (await PasswordExists(_password) && _iterations < Model.Constants.MaxIterations)
            {
                _password = SetCharacters(options, passwordLength);
                ++_iterations;
            }

            if (_iterations == Model.Constants.MaxIterations)
            {
                _password = "try new combination, input is not unique";
            }

            return _password;
        }

        public void SetLengthOfCharacters(List<AbstractOption> options)
        {
            if (_passwordLength >= Model.Constants.NumberOfRules && _passwordLength <= Model.Constants.MaxLength)
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

        public string SetCharacters(List<AbstractOption> options, int passwordLength)
        {
            var stringBuilder = new StringBuilder();

            foreach (var option in options)
            {
                stringBuilder.Append(Shuffle(option.Characters(), option.Length));
            }

            return ShuffleWithoutRepeat(stringBuilder.ToString(), passwordLength);
        }

        public async Task<bool> PasswordExists(string password)
        {
            var existingPassword = await _unitofWork.PasswordGeneratorRepository.FindAsync(m => m.Password == password);

            if (existingPassword != null && existingPassword.Any())
            {
                return true;
            }
            else
            {
                await _unitofWork.PasswordGeneratorRepository.AddAsync(new Model.PasswordGenerator
                { Password = password, CreatedBy = Model.Constants.SystemUser, UpdatedBy = Model.Constants.SystemUser });
                _unitofWork.Save();
            }

            return false;
        }

        public string Shuffle(string characters, int length)
        {
            var random = new Random();
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public string ShuffleWithoutRepeat(string characters, int length)
        {
            var random = new Random();
            var set = new HashSet<int>();
            var sb = new StringBuilder();

            while (sb.Length < length)
            {
                var randomIndex = random.Next(characters.Length);

                if (!set.Contains(randomIndex))
                {
                    sb.Append(characters[randomIndex]);
                    set.Add(randomIndex);
                }
            }

            return sb.ToString();
        }
    }
}
