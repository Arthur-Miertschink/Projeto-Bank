using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Account> listAccount = new List<Account>();

        static void Main(string[] args)
        {
            string userOption = CatchUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        WithDraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção não encontrada. Por favor tente novamente.");    
                }

                userOption = CatchUserOption();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços. Volte Sempre!");
            Console.WriteLine();
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta de Pessoa Física ou 2 para Jurídica: ");
            int entryTypeAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do titular: ");
            string entryName = Console.ReadLine();

            Console.Write("Digite o Saldo inicial: ");
            double entryBalance = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entryCredit = double.Parse(Console.ReadLine());
            
            Account newAccount = new Account(accountType: (AccountType)entryTypeAccount,
                                                            balance: entryBalance,
                                                            credit: entryCredit,
                                                            name: entryName);
            
            listAccount.Add(newAccount);
        }

        private static void ListAccounts()
        {
            if (listAccount.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas.");
                return;
            }

            for (int i = 0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(account);

            }
        }

        private static void WithDraw()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccount[accountIndex].WithDraw(withdrawValue);
        }

        private static void Deposit()
        {
            Console.Write("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccount[accountIndex].Deposit(depositValue);
        }

        private static void Transfer()
        {
            Console.Write("Digite o número da conta de origem: ");
            int originAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int targetAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccount[originAccountIndex].Transfer(transferValue, listAccount[targetAccountIndex]);
        }


        
		private static string CatchUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Bem vindo ao MoneyRain bank!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}

    }
}
