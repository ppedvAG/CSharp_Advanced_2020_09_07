using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person { Id=1, Age=40, Vorname="Kevin", Nachname="Winter"},
                new Person { Id=2, Age=43, Vorname="Petra", Nachname="Musterfrau"},
                new Person { Id=3, Age=19, Vorname="Pascal", Nachname="Neugierig"},
                new Person { Id=4, Age=53, Vorname="Matthias", Nachname="Trump"},
                new Person { Id=5, Age=23, Vorname="Denise", Nachname="Muster"},
                new Person { Id=6, Age=39, Vorname="Steffi", Nachname="Schuhmacher"},
                new Person { Id=7, Age=41, Vorname="Heike", Nachname="Müller"},
                new Person { Id=8, Age=29, Vorname="Peter", Nachname="Mustermann"}
            };


            IList<Person> results = persons
                .Where(a => a.Age > 20)
                .OrderBy(n => n.Vorname)
                .ToList();


            //Gegenbeispiel zu Linq - Query
            IList < Person > result2 = (from num in persons
                                where num.Age > 40
                                orderby num.Vorname
                                select num).ToList();

            foreach (Person person in results)
            {
                Console.WriteLine($"{person.Id} {person.Vorname} {person.Nachname} {person.Age}");
            }

            foreach (Person person in result2)
            {
                Console.WriteLine($"{person.Id} {person.Vorname} {person.Nachname} {person.Age}");
            }

            Console.ReadLine();
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

    }
}
