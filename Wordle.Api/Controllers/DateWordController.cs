<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Wordle.Api.Controllers;


// we're just skipping writing a service and doing it in the controller.
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Wordle.Api.Data;

namespace Wordle.Api.Controllers;

>>>>>>> 09848f4796a6e5573a3c682a8ec5a4097835b03f
[ApiController]
[Route("[controller]")]
public class DateWordController : Controller
{
<<<<<<< HEAD

private readonly AppDbContext _context;
private readonly static object _mutex = new(); // literally just an object. we check if this obj is in the lock, if so, stop.
private static readonly ConcurrentDictionary<DateTime, string> _cache = new();
    public DateWordController(AppDbContext context) {
=======
    private readonly AppDbContext _context;
    private readonly static object _mutex = new();
    private static readonly ConcurrentDictionary<DateTime, string> _cache = new();

    public DateWordController(AppDbContext context)
    {
>>>>>>> 09848f4796a6e5573a3c682a8ec5a4097835b03f
        _context = context;
    }

    [HttpGet]
<<<<<<< HEAD
    public string? getDailyWord(DateTime date)
    {
        // sanitize the date by dropping time data
        // data centers run in UTC, except Avista does local time zones.

        date = date.Date;
         // check if day has a word in the database
=======
    public string? GetDailyWord(DateTime date)
    {
        //Sanitize the date by dropping time data
        date = date.Date;
>>>>>>> 09848f4796a6e5573a3c682a8ec5a4097835b03f
        if (date.ToUniversalTime() >= System.DateTime.Today.ToUniversalTime().AddDays(0.5))
        {
            return null;
        }
<<<<<<< HEAD
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
=======
        //Check if the day has a word in the database
        if (_cache.TryGetValue(date, out var word))
        {
            return word;
        }
        DateWord? wordOfTheDay = _context.DateWords
            .Include(x => x.Word)
            .FirstOrDefault(dw => dw.Date == date);

        if (wordOfTheDay != null)
        //Yes: return the word
        {
            _cache.TryAdd(date, wordOfTheDay.Word.Value);
            return wordOfTheDay.Word.Value;
        }
        else
        {
            //Mutex magic
            lock (_mutex)
            {
                wordOfTheDay = _context.DateWords
                    .Include(x => x.Word)
                    .FirstOrDefault(dw => dw.Date == date);
                if (wordOfTheDay != null)
                //Yes: return the word
                {
                    return wordOfTheDay.Word.Value;
                }
                else
                {
                    //No: get a random word from our list
                    int wordCount = _context.Words.Count();
                    int randomIndex = new Random().Next(0, wordCount);
                    Word chosenWord = _context.Words
                        .OrderBy(w => w.WordId)
                        .Skip(randomIndex)
                        .Take(1)
                        .First();
                    //Save the word to the database with the date
                    _context.DateWords.Add(new DateWord { Date = date, Word = chosenWord });
                    _context.SaveChanges();
                    //Return the word
                    _cache.TryAdd(date, chosenWord.Value);
                    return chosenWord.Value;
                }
            }
        }
    }
}

internal record struct NewStruct(object Item1, object Item2)
{
    public static implicit operator (object, object)(NewStruct value)
    {
        return (value.Item1, value.Item2);
    }

    public static implicit operator NewStruct((object, object) value)
    {
        return new NewStruct(value.Item1, value.Item2);
    }
}
>>>>>>> 09848f4796a6e5573a3c682a8ec5a4097835b03f
