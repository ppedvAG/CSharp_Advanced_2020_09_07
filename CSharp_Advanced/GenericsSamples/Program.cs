using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Einfaches Beispiel
            DataStore<string> store = new DataStore<string>();
            store.Data = "Hello World";

            DataStore<int> store1 = new DataStore<int>();
            store1.Data = 123;

            DataStore<string> cities = new DataStore<string>();
            cities.AddOrUpde(0, "Mumbai");
            cities.AddOrUpde(1, "Chicago");
            cities.AddOrUpde(2, "London");


            string currentCity = cities.GetData(1);
            string currentCity1 = cities.GetData(4);

            //Default-bei Generics
            DataStore<Dog> dogStore = new DataStore<Dog>();
            dogStore.DisplayDefaultOf<Dog>();


            Printer printer = new Printer();
            printer.Print<Dog>(new Dog());


            #region Generic Method-Overloading
            MyKeyValuePair<int, string, string> myKeyValuePair = new MyKeyValuePair<int, string, string>();
            myKeyValuePair.Key = 1;
            myKeyValuePair.Value = "Tester";
            #endregion


            //#region Wo findet man generische Klassen im .NET Framework. 2 werden vorgestellt

            ////IList<T> + List
            //IList<string> stringListe = new List<string>();

            //#region Dictionary Sample 

            //Dictionary<int, string> myDict = new Dictionary<int, string>();
            //myDict.Add(1, "Harald");
            //myDict.Add(2, "Frauke");
            //myDict.Add(3, "Petermann");




            //if (myDict.ContainsKey(2))
            //{
            //    string name = myDict[2];
            //    Console.WriteLine($"Der ausgelese Name ist : {name}");
            //}

            //foreach (KeyValuePair<int, string> item in myDict)
            //{

            //    Console.WriteLine($"Der ausgelese Name ist : {item.Value}");
            //}
            //#endregion

            //Console.ReadLine();
            //#endregion

            //#region Besser nicht verwenden!!!! Die Hashtable....brrrr
            ////HashTable - Besser nicht verwenden. Das auslesen, kann bei freudiger Benutzung des HashTables sehr lange dauern.
            //Hashtable hashTable = new Hashtable();
            //hashTable.Add(123, new DataStore<string>());
            //hashTable.Add(DateTime.Now, "Helloooo");
            //hashTable.Add("1232323", "Harald");

            //#endregion



        }
    }



    public class MyKeyValuePair<TKey, TValue, TIchWillAuch>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public TIchWillAuch WeiteresValue { get; set; }
    }

    public class Dog
    {
        public string Name { get; set; } = "Lessi";

        public override string ToString()
        {
            return $"Unser Hunde heisst: {Name}";
        }
    }

    class DataStore<T>
    {
        public T Data { get; set; }

        public T[] _data = new T[10];

        public void AddOrUpde(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData (int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T); //Was wird hier bei default zurück gegeben? -> https://www.c-sharpcorner.com/article/defaultt-in-generics/
        }

        public void DisplayDefaultOf<T>()
        {
            var val = default(T);
            Console.WriteLine($"Default value of {typeof(T)} is {(val == null ? "null" : val.ToString())}.");
        }
    }


    class Printer
    {
        public void Print<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
}
