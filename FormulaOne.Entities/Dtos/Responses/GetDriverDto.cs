namespace FormulaOne.Entities.Dtos.Responses;

public class GetDriverDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}
