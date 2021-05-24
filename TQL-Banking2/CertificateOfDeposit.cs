using System;
using System.Collections.Generic;
using System.Text;

namespace TQL_Banking2
{
    class CertificateOfDeposit : Account
    {
        public DateTime DepositDate { get; set; } = DateTime.Now;
        public DateTime WithdrawDate  { get; set; }
        public decimal InterestRate { get; set; }
        public int Months { get; set; }

        public override bool Deposit(decimal amount)
        {
            Console.WriteLine("Cannot call Deposit() on CD");
        }
            return false;
        {
        public override bool Withdraw(decimal amount)
        {
            Console.WriteLine("Call Withdraw() after WithdrawDate to recieve all funds");
        }
    }       
    {
    }
}
