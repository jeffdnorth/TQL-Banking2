using System;

using TQL_Banking2.Exceptions;

namespace TQL_Banking2
{
    class Program
    {
        static void Main(string[] args)
        {
            var acct100 = new Account();
            acct100.Deposit(100);
            try
            {
                acct100.Withdraw(12000);
            }
            catch(InsufficientFundsException ex)
            {
            }
            catch(DivideByZeroException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
            }
            var sv1 = new Savings2();
            sv1.Deposit(2000);
            var cd10 = new CertificateOfDeposit2(5000, 60);
            var accounts = new IBanking[] { sv1, cd10 };
            foreach(var acct in accounts)
            {
                Console.WriteLine($"Account balance is {acct.GetBalalance()}");
            }

            var cd1 = new CertificateOfDeposit2(Amount: 1000, Months: 12);
            //cd1.Deposit(1);
            //cd1.Withdraw(1);
            cd1.WithdrawDate = DateTime.Now.AddDays(-1);  //yesterday
            var funds = cd1.Withdraw();

            var sav1 = new Savings();
            sav1.Deposit(1000);
            sav1.PayInterest(3);

            var acct1 = new Account();
            acct1.Deposit(500);
            acct1.Withdraw(200);
            acct1.Withdraw(600);
            acct1.Deposit(-400);
            Console.WriteLine($"Balance is {acct1.Balance}");

            var acct2 = new Account();
            acct1.Transfer(1000, acct2);
            Console.WriteLine($"Balance is {acct1.Balance}");
            Console.WriteLine($"Balance is {acct2.Balance}");
        }
    }
}
