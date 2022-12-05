using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bankrekening
{
    public class Bankrekening : INotifyPropertyChanged
    {
        private string _iban = String.Empty;
        private string _name = String.Empty;
        private decimal _saldo = 0.0m;

        public string Iban
        {
            get 
            {
                return this._iban;
            }
            set
            { 
                this._iban = value;
                OnPropertyChanged("Iban"); 
            } 
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                OnPropertyChanged("Name");
            }
        }

        public decimal Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                this._saldo = value;
                OnPropertyChanged("Saldo");
            }
        }

        public Bankrekening(string name)
        {
            this.Iban = Bank.GenereerIban();
            this.Name = name;
        }

        public Bankrekening(string iban, string name)
        {
            this.Iban = iban;
            this.Name = name;
        }

        public Bankrekening(string iban, string name, decimal saldo)
        {
            this.Iban = iban;
            this.Name = name;
            this.Saldo = (decimal)saldo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Storten(decimal hoeveelheid)
        {
            this.Saldo += hoeveelheid;
        }

        public bool Opnemen(decimal hoeveelheid)
        {
            if (this.Saldo >= hoeveelheid)
            {
                this.Saldo -= hoeveelheid;
                return true;
            }

            return false;
        }

        public bool Overmaken(Transactie transactie)
        {
            if (this.Opnemen(transactie.Bedrag))
            {
                transactie.DoelRekening.Storten(transactie.Bedrag);
                return true;
            }

            return false;
        }
    }
}
