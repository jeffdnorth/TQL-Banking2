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
            return false;
             }
        public override bool Withdraw(decimal amount)
             {
            Console.WriteLine("Call Withdraw() after WithdrawDate to recieve all funds");
            return false;
             }
        public bool Withdraw()
        {   
            if(DateTime.Now < WithdrawDate)
            {
 Console.WriteLine($"Cannot withdraw funds from CD till {WithdrawDate.ToString("MM/dd/yyyy")}");
                return false;
            }
            return base.Withdraw(Balance);
        }
        private void CalcAndPayInterestOnDeposit()
        {
            var interest = Balance * (InterestRate / 12) * Months;
            base.Deposit(decimal.Round(interest, 2));
        }
        private void  SetDurationAndRate(int months)
        {
            switch(months)
            {
                case 12:
                    WithdrawDate = DepositDate.AddYears(1);
                    InterestRate = 0.01m;
                    break;
                case 24:
                    WithdrawDate = DepositDate.AddYears(2);
                    InterestRate = 0.02m;
                    break;
                case 36:
                    WithdrawDate = DepositDate.AddYears(3);
                    InterestRate = 0.3m;
                    break;
                case 48:
                    WithdrawDate = DepositDate.AddYears(4);
                    InterestRate = 0.04m;
                    break;
                case 60:
                    WithdrawDate = DepositDate.AddYears(5);
                    InterestRate = 0.05m;
                    break;
                default:
                    break;
            }
        }
            public CertificateOfDeposit(decimal Amount, int Months)
              {
            this.Months = Months;
            SetDurationAndRate(Months);
            var success = base.Deposit(Amount);
            CalcAndPayInterestOnDeposit();
              }
    }       
}
