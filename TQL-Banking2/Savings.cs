using System;
using System.Collections.Generic;
using System.Text;

namespace TQL_Banking2
{
    class Savings : Account
    {
        public decimal InterestRate { get; private set; } = 0.12m;
        public decimal CalculateInterestByMonths(int NumberofMonths)
        {
            return Balance * (InterestRate / 12.0m) * NumberOfMonths;
        }
        public void PayInterest(int NumberofMonths)
        {
        var interest = CalculateInterestByMonths(NumberofMonths);
        Deposit(interest);
        }
    }
}
