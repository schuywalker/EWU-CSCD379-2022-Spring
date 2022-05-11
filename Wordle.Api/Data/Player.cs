namespace Wordle.Api.Data;
using System.ComponentModel.DataAnnotations;

// makes a table of players

public class Player
{
        //[Key] not needed - entity framework will recognize without
        public int PlayerId { get; set; }
        public string Name { get; set; } = null!;
        
        public int GameCount { get; set; }
        public double AverageAttempts { get; set; }
        public int AverageTime { get; set; }
        public int WordId { get; set; }
        public ICollection<Game> Games {get; set;} = null!;

// dependancy injection - ask for and get an ILoggerFactory, which could be an event logger or a service logger or whatever.
// like a generic with a contract (its an interface)

// can use ensure created
// open test log

        public Player Clone()
        {
            return new Player
            {
                PlayerId = PlayerId,
                Name = Name,
                GameCount = GameCount,
                AverageAttempts = AverageAttempts,
                AverageTime = AverageTime,
                Games = Games
            };
        }
}


