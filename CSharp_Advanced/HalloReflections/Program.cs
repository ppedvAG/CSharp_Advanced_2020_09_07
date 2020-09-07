using System;
using System.Reflection;

namespace HalloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly geladen = Assembly.LoadFrom("netstandard2.0\\TrumpRechner.dll");

            var allTypes = geladen.GetTypes();

            Type TaschenrechnerTyp = geladen.GetType("TrumpRechner.Taschenrechner"); // Wenn man den Namen direkt kennt

            object tr = Activator.CreateInstance(TaschenrechnerTyp);

            MethodInfo addInfo = TaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            var result = addInfo.Invoke(tr, new object[] { 12, 3 });
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
