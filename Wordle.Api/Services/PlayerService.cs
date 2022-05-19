using Wordle.Api.Data;

namespace Wordle.Api.Services
{
	
	
	public class PlayerService
	{
		
		public PlayerService(AppDbContext context)
		{
			_context = context;
		}

		private AppDbContext _context;

		public IEnumerable<Player> GetPlayers(string name)
		{
			//var result = _context.Players.OrderBy(i => i.AverageAttempts).Take(10); // not finished 
			var result = _context.Players; // not finished 
			// .FirstOrDefault(i => i.Name == name)

				return result;

			
		}
		public void  Update(string name, int attempts, int seconds){
			
			 var player = _context.Players.FirstOrDefault(x => x.Name == name);
			 if (player is null) {
				// create player
			 }
			 else {
				 // update player - we have what we need to call ScoreStatsServ Update?
			 }
			 _context.SaveChanges();

		}
	}
}

