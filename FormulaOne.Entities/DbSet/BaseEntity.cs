namespace FormulaOne.Entities.DbSet;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int Status { get; set; }
}
