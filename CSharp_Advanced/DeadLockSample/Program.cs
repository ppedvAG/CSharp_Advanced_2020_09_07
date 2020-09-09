﻿using System;
using System.Threading;

namespace DeadLockSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            Account Account1001 = new Account(1001, 5000);
            Account Account1002 = new Account(1002, 3000);
            AccountManager accountManager1 = new AccountManager(Account1001, Account1002, 5000);
            Thread thread1 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };
            AccountManager accountManager2 = new AccountManager(Account1002, Account1001, 6000);
            Thread thread2 = new Thread(accountManager2.FundTransfer)
            {
                Name = "Thread2"
            };
            AccountManager accountManager3 = new AccountManager(Account1001, Account1002, 5000);
            Thread thread3 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };
            AccountManager accountManager4 = new AccountManager(Account1001, Account1002, 5000);
            Thread thread4 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };
            AccountManager accountManager5 = new AccountManager(Account1001, Account1002, 5000);
            Thread thread5 = new Thread(accountManager1.FundTransfer)
            {
                Name = "Thread1"
            };






            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
           
            Console.WriteLine("Main Thread Completed");
            Console.ReadKey();
        }
    }

    public class Account
    {
        public int ID { get; }
        private double Balance;

        public Account(int id, double balance)
        {
            ID = id;
            Balance = balance;
        }

        public void WithdrawMoney(double amount)
        {
            Balance -= amount;
        }

        public void DepositMoney(double amount)
        {
            Balance += amount;
        }
    }

    public class AccountManager
    {
        private Account FromAccount;
        private Account ToAccount;
        private double TransferAmount;

        public AccountManager(Account AccountFrom, Account AccountTo, double AmountTransfer)
        {
            FromAccount = AccountFrom;
            ToAccount = AccountTo;
            TransferAmount = AmountTransfer;
        }

        public void FundTransfer()
        {
            //Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {FromAccount.ID}");
            ////lock (FromAccount)
            ////{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {FromAccount.ID}");
            //    Console.WriteLine($"{Thread.CurrentThread.Name} Doing Some work");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {ToAccount.ID}");

                //lock (ToAccount)
                //{
                    FromAccount.WithdrawMoney(TransferAmount);
                    ToAccount.DepositMoney(TransferAmount);
                //}
            //}
        }
    }
}
