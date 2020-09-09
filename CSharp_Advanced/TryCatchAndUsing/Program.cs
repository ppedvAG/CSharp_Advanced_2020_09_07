using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TryCatchAndUsing
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
            





            #region try/catch/finally -> Beispiel, wie man einen Stream.Close() implementiert.
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = File.OpenWrite("Person.bin");
                formatter.Serialize(stream, p1);
                //Code der einen Fehler verusachen kann
            }
            catch (IOException e)
            {
                //Fehler wurde spezifisiert und wird in Log-Datei festgehalten und optional kann man hier den Fehler noch weitergeben throw - Befehl


                //Log.WriteLog(e.Message);

                throw new IOException("Lieber Benutzer, du hast was falsch gemacht...Ätsch!");
            }
            catch (Exception e)
            {
                //E
            }
            finally
            {
                stream.Close();
                //Wird immer ausgeführt. Für Dekonstruktionsarbeiten
            }


            #endregion




            

            using (Stream stream1 = File.OpenWrite("Person1.bin")) //.NET 3.0  -> Using-Objekte benötigen das Interface: IDisposable
            {
                formatter.Serialize(stream1, p1);
            } //-> hier wird stream1.Dispose() aufgerufen

            using Stream stream2 = File.OpenWrite("Person2.bin");




            //Einlese von Binär -> Person
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)formatter.Deserialize(stream);
            stream.Close();


            
            Console.WriteLine(geladenePerson.Vorname);
            Console.WriteLine(geladenePerson.Nachname);
            Console.WriteLine(geladenePerson.Alter);
            Console.WriteLine(geladenePerson.Kontostand);
        } //hier wird stream2 -> Dispose() aufgerufen
    }

    public class Person //: IDisposable
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public void Dispose()
        {
            //if (stream != null)
            //{
            //    stream.Close();
            //    stream.Dispose();
        }
    }
}
