using System;
using System.Collections;

namespace Gernics_Constraints
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataStore<T> where T : class
            DataStore<string> store1 = new DataStore<string>();//valide
            DataStore<MyClass> store2 = new DataStore<MyClass>();//valide
            DataStore<IMyInterface> store3 = new DataStore<IMyInterface>(); //valide
            //DataStore<MyStruct> store4 = new DataStore<MyStruct>(); //nicht valiede
            //DataStore<int> store4 = new DataStore<int>(); //nicht valiede  
            DataStore<ArrayList> store5 = new DataStore<ArrayList>(); //nicht valiede



            //DataStore<T> where T : struct
            //DataStore1<string> store1 = new DataStore1<string>();//nicht valide
            //DataStore1<MyClass> store2 = new DataStore1<MyClass>();//nicht valide
            //DataStore1<IMyInterface> store3 = new DataStore1<IMyInterface>(); //nicht valide
            DataStore1<MyStruct> store4 = new DataStore1<MyStruct>(); //valiede
            DataStore1<int> store41 = new DataStore1<int>(); //valiede  
            //DataStore1<ArrayList> store5 = new DataStore1<ArrayList>(); //nicht valiede


            DataStore2<Animal> dataStore2 = new DataStore2<Animal>();
            DataStore2<Dog> dataStore2b = new DataStore2<Dog>();
            //DataStore2<MyClass> dataStore2c = new DataStore2<MyClass>();
        }
    }


    class DataStore<T> where T : class
    {
        public T Data { get; set; }
    }

    class DataStore1<T> where T : struct
    {
        public T Data { get; set; }
    }

    class DataStore2<T> where T : Animal
    {
        public T Data { get; set; }
    }


    class MyClass
    {

    }

    internal interface IMyInterface
    {
    }

    struct MyStruct
    {
        string Name { get; set; }
    }


    public class Animal
    {
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "Schäferhund";
    }
}
