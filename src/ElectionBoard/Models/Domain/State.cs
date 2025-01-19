namespace ElectionBoard.Models.Domain;

public class State
{
    public required string FipsCode { get; set; }
    public int ElectoralVotes { get; set; }
    public required string Name { get; set; }
}
