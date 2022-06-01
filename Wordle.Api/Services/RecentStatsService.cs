using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<RecentStats> GetRecentScoreStats(Guid PlayerId)
        {
            List<RecentStats> recents = new();
            for(int i = 9; i >=0; i--)
            {
                DateTime day = DateTime.Now.AddDays(-i).Date;
                var wordId = _context.DateWords.Where(dw => dw.Date == day).Select(dw => dw.WordId).FirstOrDefault();
                var daysGames = _context.Games.Include(g=>g.Guesses).Include(g=>g.Player).Where(g => (g.GameType == Game.GameTypeEnum.PlayedWordOfTheDay || g.GameType == Game.GameTypeEnum.WordOfTheDay) && g.WordId == wordId).ToList();
                 
                int gameWins = daysGames.Where(g => g.WonGame == true).Count();
                int gameFails = daysGames.Where(g => g.WonGame == false).Count();

                double winRate = 0;
                if (gameFails != 0)
                {
                    winRate = gameWins / gameFails;
                }
                

                int oneGuess = daysGames.Where(g => g.Guesses.Count == 1).Count();
                int twoGuess = daysGames.Where(g => g.Guesses.Count == 2).Count();
                int threeGuess = daysGames.Where(g => g.Guesses.Count == 3).Count();
                int fourGuess = daysGames.Where(g => g.Guesses.Count == 4).Count();
                int fiveGuess = daysGames.Where(g => g.Guesses.Count == 5).Count();
                int sixGuess = daysGames.Where(g => g.Guesses.Count == 6).Count();

                double averageGuesses = oneGuess + twoGuess + threeGuess + fourGuess + fiveGuess + sixGuess / 6.0;

                bool wonDay = daysGames.Any(x=>x.Player.Guid == PlayerId &&
                                            x.GameType == Game.GameTypeEnum.PlayedWordOfTheDay);

                double secondsPlayed = 0;
                daysGames.ForEach(x => secondsPlayed += x.Seconds);

                int averageTime = 0; 
                if (daysGames.Count != 0)
                {
                    averageTime = (int)Math.Floor(secondsPlayed / daysGames.Count);
                }               

                recents.Add(new RecentStats(day, daysGames.Count, averageGuesses, averageTime, winRate, wonDay));
            }
            return recents;
        }


    }
}
