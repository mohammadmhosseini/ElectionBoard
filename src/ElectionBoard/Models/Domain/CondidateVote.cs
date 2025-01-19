namespace ElectionBoard.Models.Domain;

public class CondidateVote
{
    public required int Code { get; set; }
    public required string Name { get; set; }
    public int ElectionCycle { get; set; }
    public long Votes { get; set; }
    public required string FipsCode { get; set; }
}
