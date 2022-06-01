namespace Wordle.Api.Dtos;
public class RecentStats
{
    public DateTime day { get; set; }
    public double averageGuesses { get; set; }
    public int averageTime { get; set; }
    public double winRate { get; set; }
    public bool wonDay { get; set; }
    public int plays { get; set; }

    public RecentStats(DateTime day, int plays, double averageGuesses, int averageTime, double winRate, bool wonDay)
    {
        this.day = day;
        this.plays = plays;
        this.averageGuesses = averageGuesses;
        this.averageTime = averageTime;
        this.winRate = winRate;
        this.wonDay = wonDay;
    }
}
