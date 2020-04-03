using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabSheet9
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public decimal OverDraftLimit { get; set; }

        public void DepositMoney(decimal amount)
        {
            Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            decimal availableFunds = Balance + OverDraftLimit;
            if(amount <= availableFunds)
            Balance -= amount;
        }


    }
}
