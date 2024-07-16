namespace FormulaOne.Entities.Dtos.Responses;

public class DriverAchievementResponse
{
    public Guid DriverId { get; set; }
    public int WorldChampionship { get; set; }
    public int PolePositions { get; set; }
    public int FastestLaps { get; set; }
    public int Wins { get; set; }
}
