using System;
using System.Linq;

namespace ORM_S
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = "";
      var db = new OnTheSafariContext();
      while (input != "quit")
      {
        var
        var animals = db.Animals.OrderBy(o => o.Species);
        foreach (var animal in animals)
        {
          Console.WriteLine($"{animal.Species}");
        }

        Console.WriteLine("What animals have you seen?");
        input = Console.ReadLine();

        if (input != "quit")
        {

          var data = input.Split(',');
          var newCreature = new Animal
          {
            Species = data[0],
            CountOfTimesSeen = int.Parse(data[1].Trim()),
            LocationLastSeen = data[2].Trim()
          };

          db.Animals.Add(newCreature);
          db.SaveChanges();
        }



        var frog = db.Animals.FirstOrDefault(w => w.Species.Contains("frog"));
        frog.Species = "frog";
        db.SaveChanges();
        Console.WriteLine("Where did you see the animal?");

        var FrogInput = Console.ReadLine();
        Console.WriteLine(frog?.Species.Length);
        frog.LocationLastSeen = FrogInput;
        db.SaveChanges();

        var camel = db.Animals.FirstOrDefault(w => w.Species == "camel");
        Console.WriteLine("How many times have you seen the camel?");

        var CamelInput = Console.ReadLine();
        camel.CountOfTimesSeen = int.Parse(CamelInput);
        db.SaveChanges();

        var AnimalInJungle = db.Animals.Where(w => w.LocationLastSeen == "jungle");
        foreach (var Animal in AnimalInJungle)
        {
          Console.WriteLine(Animal.Species);
        }
        db.SaveChanges();

        var AnimalInDesert = db.Animals.Where(w => w.LocationLastSeen == "desert");
        foreach (var Animal in AnimalInDesert)
        {
          db.Animals.Remove(Animal);
        }
        db.SaveChanges();

        var TotalCount = db.Animals.Sum(w => w.CountOfTimesSeen);
        Console.WriteLine($"You have seen {TotalCount} animals");

        var Wizard = new[] { "Lion", "tiger", "bear" };
        var OhMy = db.Animals.Where(w => Wizard.Contains(w.Species)).Sum(s => s.CountOfTimesSeen);
        Console.WriteLine($"You have seen {OhMy} Lion, tiger and bear");


      }
    }
  }
}
