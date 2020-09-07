using System;
using System.Collections.Generic;

namespace _04_Interface_segregation_principle_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region schaut schick aus, geht noch besser
            IReadOnlyRepository kannNurLesen = new KevinsRepository(); // Beispiel für Dependency Injections
            //kannNurLesen.GetEmployeeById 
            //kannNurLesen.ReadAll


            IRepository kannAlles = new KevinsRepository(); // Beispiel für Dependency Injections
            kannAlles.ReadAll();
            kannAlles.InsertEmployee(new Employee());
            kannAlles.GetEmployeeById(123);
            kannAlles.Update(new Employee());


            //Achtung Blindheit -> Bitte mit interfaces arbeiten
            KevinsRepository kevinsRepository = new KevinsRepository();
            #endregion



            #region bessere variabte nach ISP

            ICanRead kannLesenRepository = new Repository();


            ICanInsert kannNurSchreiben = new Repository();
            kannNurSchreiben.InsertEmployee(new Employee());
            #endregion

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Birthday { get; set; }
    }





    public interface IReadOnlyRepository
    {
        IList<Employee> ReadAll();

        Employee GetEmployeeById(int Id);
    }


    public interface IRepository : IReadOnlyRepository
    {
        void InsertEmployee(Employee toInsert);
        void Update(Employee toUpdate);
        void Delete(Employee employee);
    }

    public class KevinsRepository : IRepository
    {
        public void Delete(Employee employee)
        {
            Console.WriteLine("Losche Employee");
        }

        public Employee GetEmployeeById(int Id)
        {
            Console.WriteLine("GetEmployeeById");

            return new Employee();
        }

        public void InsertEmployee(Employee toInsert)
        {
            Console.WriteLine("InsertEmployee");
        }

        public IList<Employee> ReadAll()
        {
            Console.WriteLine("ReadAll");

            return new List<Employee>();
        }

        public void Update(Employee toUpdate)
        {
            Console.WriteLine("Update");
        }
    }








    public interface ICanRead
    {
        IList<Employee> ReadAll();

        Employee GetEmployeeById(int Id);
    }

    public interface ICanInsert
    {
        void InsertEmployee(Employee toInsert);
    }

    public interface ICanUpdate
    {
        void Update(Employee toUpdate);
    }

    public interface ICanDelete
    {
        void Delete(Employee employee);
    }

    public class Repository : ICanInsert, ICanRead, ICanUpdate, ICanDelete
    {
        public void Delete(Employee employee)
        {
            Console.WriteLine("Employee kann Delete");
        }

        public Employee GetEmployeeById(int Id)
        {
            Console.WriteLine("Employee mit ID auslesen");
            return new Employee();
        }

        public void InsertEmployee(Employee toInsert)
        {
            Console.WriteLine("Neuer Employee");
        }

        public IList<Employee> ReadAll()
        {
            Console.WriteLine("Lese alles");

            return new List<Employee>();
        }

        public void Update(Employee toUpdate)
        {
            Console.WriteLine("Update alles");
        }
    }
}
