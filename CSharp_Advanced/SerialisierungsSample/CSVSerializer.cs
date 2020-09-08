using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SerialisierungsSample
{
    public static class CSVSerializer
    {
        public static void Serialize(this Person p, string path)
        {
            File.WriteAllText(path, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand}");
        }


        public static void DeserializePerson(this Person p, string path)
        {
            string content = File.ReadAllText(path);

            string[] csvParts = content.Split(';');
            p.Vorname = csvParts[0];
            p.Nachname = csvParts[1];
            p.Alter = Convert.ToByte(csvParts[2]);
            p.Kontostand = Convert.ToDecimal(csvParts[3]);
        }
    }
}
