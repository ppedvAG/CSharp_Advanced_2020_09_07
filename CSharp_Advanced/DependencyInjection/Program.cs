using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {

            ICarService carService = new CarService();



            carService.RepairCar(new MockCar()); // Dummy Objekt für Testphase
            carService.RepairCar(new Car()); //Normales Auto-Objekt wenn es fertig ist. 

            carService.RepairCar(new MockCarV2());



            Console.WriteLine("Hello World!");
        }
    }

    #region Bad Sample
    public class BadCar //Programmierer A 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructYear { get; set; }
        public string Color { get; set; }


        public void Beschleunigen()
        {

        }

        public void Bremsen ()
        {

        }
    }

    public class BadCarService //Programmierer B
    {
        public void Repair (BadCar car)
        {
            // Mach was mit dem Auto 
        }
    }
    #endregion


    #region Dependency Injections

    public interface ICar
    {
        string Brand { get; set; }
        string Model { get; set; }
        DateTime ConstructionYear { get; set; }
        string Farbe { get; set; }
    }

    public interface ICarV2 : ICar
    {
        bool Klimaanlage { get; set; }
    }

    public class MockCarV2 : ICarV2
    {
        public bool Klimaanlage { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
        public string Farbe { get; set; }
    }


    public interface ICarService
    {
        void RepairCar(ICar car);
    }

    //public interface IDrittanbieter
    //{
    //    void RepairCar(ICar car);
    //}

    public class MockCarService : ICarService
    {
        public void RepairCar(ICar car)
        {
            //Mockbearbeitung. 
        }
    }

    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
        public string Farbe { get; set; }
    }

    public class CarService : ICarService
    {

        #region Expliziete Interface - Impementierung
        //void ICarService.RepairCar(ICar car)
        //{
        //    throw new NotImplementedException();
        //}

        //void IDrittanbieter.RepairCar(ICar car)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
        public void RepairCar(ICar car)
        {
            //Mach was mit dem Auto
        }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "Opel";
        public string Model { get; set; } = "Astra";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
        public string Farbe { get; set; } = "Blau";
    }

    #endregion
}
