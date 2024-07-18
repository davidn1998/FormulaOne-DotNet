namespace FormulaOne.Entities.Dtos.Requests;

public class UpdateDriverAchievementDto
{
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }
    public int WorldChampionship { get; set; }
    public int PolePosition { get; set; }
    public int FastestLap { get; set; }
    public int Wins { get; set; }
}
