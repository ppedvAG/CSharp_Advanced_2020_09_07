using System;
using System.Collections.Generic;
using System.Text;

namespace SerialisierungsSample
{

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }

    //Für binäre Serialisierung benötigen wird Fields und keine Properties -> 
    //[Serializable] //-> Wird nur für binäre Serialisierung verwendet
    //public class Person
    //{
    //    public string Vorname;
    //    public string Nachname;
    //    public byte Alter;

    //    [NonSerialized]
    //    public decimal Kontostand;
    //}
}
