using Microsoft.EntityFrameworkCore;

namespace PizzaStore.DB;

public record Pizza
{
  public int Id {get; set;} 
  public string ? Title { get; set; }
}

public class P: DbContext
{
  public P(DbContextOptions options): base(options){}

  public DbSet<Pizza> Pizzas { get; set; }
}

public class PizzaDb
{
  private static List<Pizza> _pizza = new List<Pizza>()
   {
     new Pizza{ Id=1, Title="Grand Theft Auto: Vice City" },
     new Pizza{ Id=2, Title="Assasin's Creed"},
     new Pizza{ Id=3, Title="Call Of Duty: 3"},
     new Pizza{ Id=4, Title="Dark Soul"},
     new Pizza{ Id=5, Title="The Simpson: Hits and Road"},
     new Pizza{ Id=6, Title="The Simpson: The VideGame (PS3)"},
     new Pizza{ Id=7, Title="The Elder Scroll: Morriwind"},
     new Pizza{ Id=8, Title="Prince Of Persia: The Last Clow"} 
   };

  public static List<Pizza> GetPizzas()
  {
    return _pizza;
  }

  public static Pizza[] GetPizzas(int limit)
  {
    Pizza[] pizza = _pizza.Take(limit).ToArray();

    return pizza;
  }

  public static string AddGame(string title)
  {
    int newId = _pizza.Count + 1;
    _pizza.Add(new Pizza{ Id=newId, Title=title });

    try
    {
      var newPizza = _pizza.Find(x => x.Id == newId);
      return $"Id: {newPizza?.Id}\nTitle: {newPizza?.Title}";
    }
    catch (System.Exception)
    {
      return "Ocurrio un problema";
    }

  }

  public static List<Pizza> UpdateGame(Pizza update)
  {
    var updatePizza = _pizza.Select(pizza =>
    {
      if (pizza.Id == update.Id) pizza.Title = update.Title;
      return pizza;
    }).ToList();

    _pizza = updatePizza;
    return _pizza;
  }

  public static List<Pizza> DeleteGame(int id)
  {
    _pizza = _pizza.Where(pizza => pizza.Id != id).ToList();
    return _pizza;
  }
}

