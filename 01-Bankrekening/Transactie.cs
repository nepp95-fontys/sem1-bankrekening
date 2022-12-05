using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankrekening
{
    public class Transactie
    {
        public Bankrekening DoelRekening { get; }
        public decimal Bedrag { get; }

        public Transactie(string iban, decimal bedrag)
        {
            int i = 0;
            while(Bank.bankrekeningen[i].Iban != iban && i <= Bank.bankrekeningen.Count())
            {
                this.DoelRekening = Bank.bankrekeningen[i];
                i++;
            }

            this.Bedrag = bedrag;
        }
    }
}
