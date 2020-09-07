using System;

namespace _05_Dependency_inversion_principle_DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Bad Sample
    public class Email
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class Notification
    {
        private Email _email;
        public Notification()
        {
            _email = new Email();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion


    #region Good Sample
    public interface IMessenger
    {
        void SendMessage();
    }
    public class Email1 : IMessenger
    {
        public void SendMessage()
        {
            // code to send email
        }
    }

    public class SMS : IMessenger
    {
        public void SendMessage()
        {
            // code to send SMS
        }
    }
    
    
    public class Notification1
    {
        private IMessenger _iMessenger;
        public Notification1()
        {
            _iMessenger = new Email1();
        }
        public void DoNotify()
        {
            _iMessenger.SendMessage();
        }
    }

    #endregion
}
