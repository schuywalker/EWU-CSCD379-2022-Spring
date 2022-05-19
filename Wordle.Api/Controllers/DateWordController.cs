using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Wordle.Api.Controllers;


// we're just skipping writing a service and doing it in the controller.
[ApiController]
[Route("[controller]")]
public class DateWordController : Controller
{

private readonly AppDbContext _context;
private readonly static object _mutex = new(); // literally just an object. we check if this obj is in the lock, if so, stop.
private static readonly ConcurrentDictionary<DateTime, string> _cache = new();
    public DateWordController(AppDbContext context) {
        _context = context;
    }

    [HttpGet]
    public string? getDailyWord(DateTime date)
    {
        // sanitize the date by dropping time data
        // data centers run in UTC, except Avista does local time zones.

        date = date.Date;
         // check if day has a word in the database
        if (date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
        {
            return null;
        }
         if (_cache.TryGetValue(date, out var word))
        {
            return word;
        }   
        
        
        
        DateWord? wordOfTheDay = _context.DateWords.Include(x => x.Word).FirstOrDefault(dw => dw.Date == date); // where clause has to be last in linq
        
        // Mutex magic // lets assume we're running on one server. make private static object _mutex or _lock
       

        lock(_mutex) 
        {
        
        


       if (wordOfTheDay != null)
       {
            // if day has word, return the word

           return wordOfTheDay.Word.Value;
       }
        else // if not, get words from db, get a random word and save it to the database
        {
            lock (_mutex){
                wordOfTheDay = _context.DateWords.Include(x => x.Word).FirstOrDefault(dw => dw.Date == date); // pasted from above
            }
            if (wordOfTheDay != null)
            {
                return wordOfTheDay.Word.Value;
            }
            else 
            {
                int wordCount = _context.Words.Count();
            int randomIndex = new Random().Next(0, wordCount);
            Word chosenWord = _context.Words.OrderBy(f => f.WordId).Skip(randomIndex).Take(1).First();
            // string chosenWord = _context.Words.OrderBy(f => f.WordId).Skip(randomIndex).Take(1).First().Value; // use Value for getting string back
            // two important keywords: take and skip. skip skips a certain number then starts reading. take grabs the number you specify. used for Paging???

            // putting word back to database
            _context.DateWords.Add(new DateWord { Date = date, Word = chosenWord });
            _context.SaveChangesAsync(); // line above doesnt save. doesnt have to be async
            _cache.TryAdd(date, chosenWord.Value);
            return chosenWord.Value;
            }
        }
            

/* thinking things through
- get daily word
- does exist?
- if yes return
- if not, LOCK, check if it exists AGAIN, {
    get daily word. check if exist. if not exist, create new word.
    why do logic twice?
    so we can lock other threads who may get to that point. whenever you use a lock block, you have to do the logic a second time.
    if multiple threads evaluate, one has to lock first, but the others may have entered this block and be ready to execute when lock releases. therefore, we check again.
}
*/

        }

    }
}

/*
Rosyln Symbol build - how ef migration works
compiles code, then looks through and generates code. ef migrations is just a code generator.

// if doing migrations, might need to comment out seed method in
*/