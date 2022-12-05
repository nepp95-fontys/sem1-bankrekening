using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Bankrekening
{
    class Bank
    {
        public static BindingList<Bankrekening> bankrekeningen { get; set; }

        static Bank()
        {
            bankrekeningen = new BindingList<Bankrekening>();
        }

        public static Bankrekening MaakRekening(string name)
        {
            Bankrekening rekening = new Bankrekening(name);
            bankrekeningen.Add(rekening);

            return rekening;
        }

        public static Bankrekening MaakRekening(string iban, string name)
        {
            Bankrekening rekening = new Bankrekening(iban, name);
            bankrekeningen.Add(rekening);

            return rekening;
        }

        public static Bankrekening MaakRekening(string iban, string name, decimal saldo)
        {
            Bankrekening rekening = new Bankrekening(iban, name, saldo);
            bankrekeningen.Add(rekening);

            return rekening;
        }

        public static void VerwijderRekening(Bankrekening rekening)
        {
            bankrekeningen.Remove(rekening);
        }

        public static string GenereerIban()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            bool valid = false;
            string iban = "";

            while (!valid)
            {
                iban = "NL" + random.Next(10, 99) + "NEPP000" + random.Next(1000000, 9999999);
                
                valid = true;

                foreach (Bankrekening rekening in bankrekeningen)
                {
                    if (rekening.Iban == iban)
                        valid = false;
                }
            }

            return iban;
        }
    }
}
