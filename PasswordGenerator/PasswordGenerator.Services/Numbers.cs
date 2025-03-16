namespace PasswordGenerator.Services
{
    public class Numbers : AbstractOption
    {
        public override int Length { get; set; }
        public override bool Included { get; set; }
        public override string Characters()
        {
            return "0123456789";
        }
    }
}