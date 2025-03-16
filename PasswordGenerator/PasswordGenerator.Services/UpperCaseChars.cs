namespace PasswordGenerator.Services
{
    public class UpperCaseChars : AbstractOption
    {
        public override int Length { get; set; }
        public override bool Included { get; set; }
        public override string Characters()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
    }
}