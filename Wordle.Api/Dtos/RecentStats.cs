namespace Wordle.Api.Dtos;
public class RecentStats
{
    private DateTime day { get; set; }
    private double averageGuesses { get; set; }
    private int averageTime { get; set; }
    private double winRate { get; set; }
    private bool wonDay { get; set; }
    private int plays { get; set; }

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
