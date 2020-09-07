using CSharp71_Features;
using System;
using System.Threading.Tasks;

namespace CSharp71_Features
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(2000);

            Console.WriteLine("Nach 2 Sekunden...wird das hier geschrieben");
        }
    }


    public class MyClass
    {
        public void GetPublic() { }
        private void GetPrivate() { }
        internal void GetInternal() { }
        protected void GetProtected() { }
        protected internal void GetProtectedInternal() { }
        protected private void GetPrivateProtected() { }
    }


    public class YourClass : MyClass
    {
        MyClass mc = new MyClass();
        public void Show()
        {
            mc.GetPublic();
            //mc.GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            mc.GetInternal();
            //mc.GetProtected(); Not accessible as protected members can be accessed only through inheritance and not by creating an object.  
            mc.GetProtectedInternal();
            //mc.GetPrivateProtected(); Not accessible as Private Protected members can be accessed only through inheritance in same assembly.                
            GetPublic();
            //GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            GetInternal();
            GetProtected();
            GetProtectedInternal();
            GetPrivateProtected();
        }
    }



}



//Outside the assembly  

namespace ClassLibrary1
{
    public class YourClass1 : MyClass
    {
        MyClass mc = new MyClass();
        public void show()
        {
            mc.GetPublic();
            //mc.GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            mc.GetInternal(); //Not accessible as internal members are not accessible outside it's assembly.  
            //mc.GetProtected(); Not accessible as protected members can be accessed only through inheritance and not by creating an object.  
            //mc.GetProtectedInternal(); Not accessible as Protected Internal members can not be accessed outside of assembly by creating an object.  
            //mc.GetPrivateProtected(); Not accessible as Private Protected members are not accessible outside of assembly by creating an object or through inheritance.      
            GetPublic();
            //GetPrivate(); Not accessible as private members of a class are not accessible outside class.  
            GetProtected();
            //GetInternal(); Not accessible as internal members are not accessible outside it's assembly.  
            GetProtectedInternal();
            //GetPrivateProtected(); Not accessible as Private Protected members are not accessible outside of assembly by creating an object or through inheritance.    
        }
    }
}
