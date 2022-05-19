// having something happen at midnight is really hard because websites are event driven.
// hankfire does this but thats outside scope/ complicated (does 'jobs')
// we're going to give out words on demand. 
// wheres the dragon? Two people ask for a days word at same time and db runs the request on multiple threads.

using System.ComponentModel.DataAnnotations.Schema; // for [ForeignKey]

namespace Wordle.Api.Data;
 
public class DateWord {
public int DateWordId { get; set; } // primary (C# knows if you use [key] or its called ID or its the class name with Id at the end)
public DateTime Date { get;set; } 

[ForeignKey(nameof(WordID))] // not necessary but we're doing this explicitly
public Word Word { get; set; } = null!;
public int WordID { get; set; }


// int is not nullable, so int is being considered non-nullable


}


