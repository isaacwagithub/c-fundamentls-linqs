using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hometown> hometowns = new List<Hometown>() {
                new Hometown{ Country="South Africa", City="Pretoria"},
                new Hometown{ Country="Zimbabwe", City="Denzil City"},
                new Hometown{ Country="Brazil", City="Santos"},
                new Hometown{ Country="France", City="Paris"},
                new Hometown{ Country="China", City="Shanghai"},
                new Hometown{ Country="Canada", City="Toronto"},
            };
            List<People> people = new List<People>()
            {
                new People{FirstName = "Isaac", LastName = "Boss", Town="Pretoria" },
                new People{FirstName = "Isaac", LastName = "Master", Town="ksland" },
                new People{FirstName = "Kevin", LastName = "Junior", Town="Laudium" },
                new People{FirstName = "Thabiso", LastName = "Boss", Town="Pretoria" }
            };

            var myPeople = from p in people
                           orderby p.FirstName descending, p.LastName descending
                           select new { name = p.FirstName, surname = p.LastName};

            var peopleWithHomeTowns = from person in people
                                      join town in hometowns
                                      on person.Town equals town.City
                                      select new { name = person.FirstName, surname = person.LastName, town = town.City, country = town.Country};

            var grouped = from person in people
                          group person by person.Town into myGroups
                          select new { city = myGroups.Key, count = myGroups };

            var peopleWithTowns = from person in people
                                  join town in hometowns
                                  on person.Town equals town.City
                                  select new { name = person.FirstName, surname = person.LastName, town = person.Town, country = town.Country};

            var filtering = people.Where(p => p.FirstName == "Isaac").OrderByDescending(p => p.FirstName).ThenBy(p=>p.LastName);

            var joining = people.Join(hometowns, p=> p.Town, h=>h.City, (p,h)=> new { p.FirstName, h.City, h.Country});

            foreach (var item in filtering)
            {
                Console.WriteLine($"filtering results are: first Name {item.FirstName} and last Name: {item.LastName}");
            }
            foreach (var item in peopleWithTowns)
            {
                Console.WriteLine($"Name: {item.name}, surname: {item.surname}, town: {item.town}");
            }
            /*foreach (var item in grouped) {
                Console.WriteLine($"key: {item.city} count: {item.count.Count}");
            }*/
        }
    }
}
