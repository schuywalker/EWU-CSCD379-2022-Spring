using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
    public class ScoreStat
    {
        [Key]
        public int ScoreStatId { get; set; }
        public int Score { get; set; }
        public int AverageSeconds { get; set; }
        public int TotalGames { get; set; }

//   DTO: Data Transfer Object 
// - keeps us from exposing and allowing bad data to be passed to the database.
        public ScoreStat Clone()
        {
            return new ScoreStat
            {
                ScoreStatId = ScoreStatId,
                Score = Score,
                AverageSeconds = AverageSeconds,
                TotalGames = TotalGames,

            };
        }
    }
}
