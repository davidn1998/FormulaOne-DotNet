namespace FormulaOne.Entities.Dtos.Requests;

public class CreateDriverDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
