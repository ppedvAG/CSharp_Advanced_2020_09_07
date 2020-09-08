using System;
using TheDogLibrary;

namespace TheDogApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog() { Name = "Bello", Rasse = "Dackel", Birthday = DateTime.Now };

            dog.Bellen();
            Console.ReadLine();
        }
    }

    public static class DogExtentionsMethods
    {
        public static void Bellen (this Dog dog)
        {
            Console.WriteLine($"{dog.Name} bellt");
        }
    }
}
