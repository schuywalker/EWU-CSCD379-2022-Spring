using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services
{
    public class RecentStatsService
    {
        public RecentStatsService(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;

        public IEnumerable<RecentStats> GetRecentScoreStats(int PlayerId)
        {
            List<RecentStats> recents = new();
            for(int i = 10; i >=0; i--)
            {
                DateTime day = DateTime.Now.AddDays(i);
                var daysGames = _context.Games
                .Where(g => g.WordId == _context.DateWords.Where(dw => dw.Date == day).Select(dw => dw.WordId).First()).ToList();

                int gameWins = daysGames.Where(g => g.Guesses.Count > 0 && g.Guesses.Count != 7).Count();
                int gameFails = daysGames.Where(g => g.Guesses.Count == 7).Count();

                double winRate = gameWins / gameFails;

                int oneGuess = daysGames.Where(g => g.Guesses.Count == 1).Count();
                int twoGuess = daysGames.Where(g => g.Guesses.Count == 2).Count();
                int threeGuess = daysGames.Where(g => g.Guesses.Count == 3).Count();
                int fourGuess = daysGames.Where(g => g.Guesses.Count == 4).Count();
                int fiveGuess = daysGames.Where(g => g.Guesses.Count == 5).Count();
                int sixGuess = daysGames.Where(g => g.Guesses.Count == 6).Count();

                double averageGuesses = oneGuess + twoGuess+ threeGuess + fourGuess + fiveGuess + sixGuess / 6;

                bool wonDay = daysGames.Any(g => g.PlayerId == PlayerId);

                //TODO Migrate time to game
                int averageTime = (int)Math.Floor(1.0/daysGames.Count);

                recents.Add(new RecentStats(day, daysGames.Count, averageGuesses, averageTime, winRate, wonDay));
            }
            return recents;
        }


    }
}
