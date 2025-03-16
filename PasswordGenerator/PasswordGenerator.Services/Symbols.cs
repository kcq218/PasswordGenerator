namespace PasswordGenerator.Services
{
    public class Symbols : AbstractOption
    {
        public override int Length { get; set; }
        public override bool Included { get; set; }
        public override string Characters()
        {
            return "!@#$%^&*()_+=-`~<>{}[]";
        }
    }
}