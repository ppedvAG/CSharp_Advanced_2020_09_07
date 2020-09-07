using System;

namespace CSharp7_Features
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Vorstellung - out - Variablen

            int variableB = 5;
            int result = Calculate(3, out variableB);
            Console.WriteLine(variableB); // Variable soll 11 sein.
            Console.WriteLine(result); // Die Variable von Result ist 33
            #endregion

            #region praktische Anwendung von out-Variablen mit int.TryParse

            Console.Write("Bittte geben sie eine Zahl ein");
            string inputZahl = Console.ReadLine();

            // Bei der Eingabe : '10.' oder '.123.' wird es beim umwandeln mit Convert.ToInt32 einen Fehler geben
            //int convertedNumber = Convert.ToInt32(inputZahl); // Kann Exception hervorrufen
            //convertedNumber = int.Parse(inputZahl); // Kann Exception hervorrufen


            int convertedNumber;

            if (int.TryParse(inputZahl, out convertedNumber))
            {
                // Wenn ich in diesem Block mich befinde, ist die Zahl erfolgreich konventiert worden

                Console.WriteLine(convertedNumber);
            }

            #endregion

            #region Nullable Datatypes früheren C# Version
            int zahl1 = -1; // -1 = neu angelegte Variable mit einem inital-wert

            int? nullableIntegerVariable = null;


            //Prüfe ob ein Wert zugewiesen wurde
            if (!nullableIntegerVariable.HasValue)
                nullableIntegerVariable = 23;


            if (nullableIntegerVariable.HasValue)
                Console.WriteLine(nullableIntegerVariable.Value);

            #endregion


            #region Verwenden von Tuple
            Person person = new Person();
            var result1 = person.GetCompleteName();
            //result1.Item1 -> Vorname
            //result1.Item2 -> Zweiten Vornamen
            //result1.Item3 -> Nachname

            //selbe schreibweise wie bei var result1 -> man verwendet item1, item2, item3
            (string, string, string) result2 = person.GetCompleteName();

            string vorname, nachname, zweiterVorname;

            (vorname, zweiterVorname, nachname) = person.GetCompleteName();
            //printf Nachahme in C#
            Console.WriteLine("{0}, {1}, {2}", vorname, zweiterVorname, nachname);
            // seit C# 7.0
            Console.WriteLine($"Der Vorname ist: {vorname} - Zweiter Vorname: {zweiterVorname} - Nachname {nachname} ");

            #endregion

            #region Dekonstruktion von Typen
            Kunde k = new Kunde { Id = 123, Name = "Andre", Stammkunde = true };
            var (id, name, stammkunde) = k;
            Console.WriteLine($"{id}{name}{stammkunde}");

            #endregion

            #region Literale in C#

            int eineMio = 1000000;
            int zweiMio = 1_000_000;

            decimal myBankAccount = 12234343;
            decimal myBankAccountWithLiteral = 123123123123m;

            int hexValue = 0xFFF000;
            byte binaer = 0b00001111;

            Console.WriteLine($"{eineMio}{zweiMio}{myBankAccount}{myBankAccountWithLiteral}{hexValue}{binaer}");
            #endregion

            #region Rückgabe via Referenz
            // Create an array of author names   
            string[] authors = { "Mahesh Chand", "Mike Gold", "Dave McCarter", "Allen O'neill", "Raj Kumar" };

            // Call a method that returns by ref    
            ref string author4 = ref new Program().FindAuthor(3, authors);
            Console.WriteLine("Original author:{0}", author4);

            // Prints 4th author in array = Allen O'neill    
            Console.WriteLine();

            // Replace 4th author by new author. By Ref, it will update the array    
            author4 = "Chris Sells";

            // Print 4th author in array  
            Console.WriteLine("Replaced author:{0}", authors[3]);

            //Prints Chris Sells    
            Console.ReadKey();


            int[] zahlen = { 5, 7, 3, 433, 12, 23 };
            ref int position = ref new Program().Zahlensuche(3, zahlen);
            //position = 100_000_000;

            //Console.WriteLine(zahlen[5]);
            #endregion

            Console.ReadLine();
        }

        public static int Calculate (int a,  out int b)
        {
            b = 11;

            return a * b;
        }

        public ref string FindAuthor(int number, string[] names)
        {

            if (names.Length > 0)
                return ref names[number]; // return the storage location, not the value    
            throw new IndexOutOfRangeException($"{nameof(number)} not found.");

        }

        public ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];

            }
            throw new IndexOutOfRangeException();
        }
    }


    public class Person
    {
        private string zweiterVornamen;
        public string ZweiterVornamen
        {
            get => this.zweiterVornamen;
            

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Variable muss befüllt sein");
                this.zweiterVornamen = value;
            }

        }

        //Auto-Property
        public string Vorname { get; set; }

        public string Nachname { get; set; }


        //Deconstrutor Objekt wird auf seine Variablen aufgebröselt
        public (string, string, string) GetCompleteName ()
        {
            return (Vorname, ZweiterVornamen, Nachname);
        }
    }

    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Stammkunde { get; set; }

        public void Deconstruct (out int ID, out string Name, out bool Stammkunde)
        {
            ID = this.Id;
            Name = this.Name;
            Stammkunde = this.Stammkunde;
        }
    }
}
