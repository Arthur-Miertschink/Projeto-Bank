using System;

namespace bank
{
    public class Account
    {
        private AccountType AccountType {get; set; }

         private double Credit {get; set;}

         private double Balance {get; set;}

         private string Name {get; set;}

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }


        public bool WithDraw(double withdrawValue)
        {
            if(this.Balance - withdrawValue < (this.Credit *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Balance -= withdrawValue;

            Console.WriteLine("Saque Realizado com sucesso!");
            Console.WriteLine("O saldo atual da conta de {0} é R$: {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;

            Console.WriteLine("Depósito Realizado com sucesso!");
            Console.WriteLine("O saldo atual da conta de {0} é R$: {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account targetAccount)
        {
            if (this.WithDraw(transferValue)){
                targetAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "Tipo da conta " + this.AccountType + " | ";
            retorno += "Nome " + this.Name + " | ";
            retorno += "Saldo " + this.Balance + " | ";
            retorno += "Crédito " + this.Credit + " | ";
            return retorno;
        }

    }
};