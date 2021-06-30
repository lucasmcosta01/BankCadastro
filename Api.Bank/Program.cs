using Api.Bank.Entities;
using Api.Bank.Enum;
using System;
using System.Collections.Generic;

namespace Api.Bank
{
    public class Program
	{
		static List<Account> listAccount = new List<Account>();
		public static void Main(string[] args)
		{
			string opcaoUser = ObtainOpcaoUser();

			while (opcaoUser.ToUpper() != "X")
			{
				switch (opcaoUser)
				{
					case "1":
						ListAccount();
						break;
					case "2":
						InsertAccount();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
                           Deposit();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUser = ObtainOpcaoUser();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

        private static void Deposit()
		{
			Console.Write("Digite o número da conta: ");
			int indexConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valueDeposit = double.Parse(Console.ReadLine());

			listAccount[indexConta].Deposit(valueDeposit);
		}

		private static void Withdraw()
		{
			Console.Write("Digite o número da conta: ");
			int indexConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valuePackage = double.Parse(Console.ReadLine());

			listAccount[indexConta].Withdraw(valuePackage);
		}

		private static void Transfer()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indexAccountOrigin = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");

			int indexAccountDestination = int.Parse(Console.ReadLine());
			Console.Write("Digite o valor a ser transferido: ");
			double transferValue = double.Parse(Console.ReadLine());

			listAccount[indexAccountOrigin].Transfer(transferValue, listAccount[indexAccountDestination]);
		}

		private static void InsertAccount()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int enterTypeAccount = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string enterName = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double enterBalance = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double enterCredit = double.Parse(Console.ReadLine());

			Account newAccount = new Account(typeAccount: (TypeAccount)enterTypeAccount,
											balance: enterBalance,
											credit: enterCredit,
											name: enterName);

			listAccount.Add(newAccount);
		}

		private static void ListAccount()
		{
			Console.WriteLine("Listar contas");

			if (listAccount.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listAccount.Count; i++)
			{
				Account account = listAccount[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}


		private static string ObtainOpcaoUser()
		{
			Console.WriteLine();
			Console.WriteLine("Tecno Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
