namespace PasswordGenerator.Model;

public partial class PasswordGenerator
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
