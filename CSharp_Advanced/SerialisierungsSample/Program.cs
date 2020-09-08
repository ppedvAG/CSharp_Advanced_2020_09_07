
using Newtonsoft.Json; // Newtonsoft Library
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter
using System.Xml.Serialization; //XMLSerializer

//System.Text.Json.Serialization -> Microsofts JSON Formatter

namespace SerialisierungsSample
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test-Objekt
            Person p1 = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 10,
                Kontostand = 10000000009900
            };

            //Beispiel 1: Binär
            #region Binäres schreiben unserer Person
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = File.OpenWrite("Person.bin");
            formatter.Serialize(stream, p1);
            stream.Close();

            //Einlese von Binär -> Person
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine(geladenePerson.Vorname);
            Console.WriteLine(geladenePerson.Nachname);
            Console.WriteLine(geladenePerson.Alter);
            Console.WriteLine(geladenePerson.Kontostand);
            #endregion

            //Beispiel 2: XML

            //Schreiben
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Person));
            Stream stream1 = File.OpenWrite("Person.xml");
            xmlFormatter.Serialize(stream1, p1);
            stream1.Close();

            //Lesen
            stream1 = File.OpenRead("Person.xml");
            Person geladenPerson = (Person)xmlFormatter.Deserialize(stream1);
            stream1.Close();

            //Beispiel 3: JSON

            string json = JsonConvert.SerializeObject(p1);
            File.WriteAllText("Person.json", json);
            Console.WriteLine(json);

            Person person1 = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(person1.Vorname);


            //Beispiel 4: Customize Serializer für CSV

            p1.Serialize("Person.csv");

            Person p2 = new Person();
            p2.DeserializePerson("Person.csv");




            
            Console.ReadLine();
        }
    }
}
