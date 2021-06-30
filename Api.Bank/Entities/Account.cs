using Api.Bank.Enum;
using System;

namespace Api.Bank.Entities
{
    public class Account
    {
		// Atributos
		private TypeAccount TypeAccount { get; set; }
		private double Balance { get; set; }
		private double Credit { get; set; }
		private string Name { get; set; }

        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            this.TypeAccount = typeAccount;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        // Métodos


        public bool Withdraw(double cashoutAmount)
		{
			// Validação de saldo suficiente
			if (this.Balance - cashoutAmount < (this.Credit * -1))
			{
				Console.WriteLine("Saldo insuficiente!");
				return false;
			}
			this.Balance -= cashoutAmount;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
			return true;
		}

		public void Deposit(double cashoutDeposit)
		{
			this.Balance += cashoutDeposit;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Name, this.Balance);
		}

		public void Transfer(double transferValue, Account accountDestination)
		{
			if (this.Withdraw(transferValue))
			{
				accountDestination.Deposit(transferValue);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta " + this.TypeAccount + " | ";
			retorno += "Nome " + this.Name + " | ";
			retorno += "Saldo " + this.Balance + " | ";
			retorno += "Crédito " + this.Credit;
			return retorno;
		}
	}
}
