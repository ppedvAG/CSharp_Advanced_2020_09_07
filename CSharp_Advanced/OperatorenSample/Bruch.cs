using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorenSample
{
    public class Bruch
    {
        

        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner;
        }

        public int Zähler { get; set; }
        public int Nenner { get; set; }

        public static bool operator == (Bruch left, Bruch right)
        {
            if (left.Nenner != right.Nenner)
                return false;

            if (left.Zähler != right.Zähler)
                return false;

            return true;
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
  

        public static bool operator != (Bruch left, Bruch right)
        {
            return false;
        }

        public static Bruch operator*(Bruch left, Bruch right)
        {
            return new Bruch(left.Zähler * right.Zähler, left.Nenner * right.Nenner);
        }
        public static Bruch operator *(Bruch left, int right)
        {
            return new Bruch(left.Zähler * right, left.Nenner);
        }

    }
}
