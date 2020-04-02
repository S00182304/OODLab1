using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabSheet9
{
    public class BankAccount
    {
        public double Balance { get; set; }

        public double DepositMoney(double Deposit)
        {
            Deposit += Balance;
            return Balance;
        }

        public double WithdrawMoney(double Withdraw)
        {
            Withdraw -= Balance;
            return Balance;
        }
    }
}
