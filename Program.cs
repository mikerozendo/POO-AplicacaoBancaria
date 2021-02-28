using System;
using System.Globalization;
using System.Collections.Generic;

namespace AplicacaoBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        static List<ContaBancaria> listaDeContasBancarias = new List<ContaBancaria>();
        private static void LimparTela()
        {
            Console.Clear();
        }
        private static void Transferir()
        {
            Console.Write("Informe o número da sua conta: ");
            int localizador = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da conta de destino: ");
            int localizadorDestinatario = int.Parse(Console.ReadLine());

            for (int i = 0; i < listaDeContasBancarias.Count; i++)
            {
                if (listaDeContasBancarias[i].IdConta == localizador)
                {
                    Console.Write("Informe o valor á ser transferido: ");
                    double valorParaTransferencia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listaDeContasBancarias[i].TrasferirDinheiro(valorParaTransferencia);


                    for (int j = 0; j < listaDeContasBancarias.Count; j++)
                    {
                        if (listaDeContasBancarias[j].IdConta == localizadorDestinatario)
                        {
                            listaDeContasBancarias[j].DepositarDinheiro(valorParaTransferencia);
                        }
                    }

                }
            }
        }
        private static void Depositar()
        {
            Console.Write("Informe o número da sua conta: ");
            int localizador = int.Parse(Console.ReadLine());

            for (int i = 0; i < listaDeContasBancarias.Count; i++)
            {
                if (listaDeContasBancarias[i].IdConta == localizador)
                {
                    Console.Write("Informe o valor á ser depositado: ");
                    double valorParaDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listaDeContasBancarias[i].DepositarDinheiro(valorParaDeposito);
                }
            }
        }
        private static void ListarContas()
        {
            for (int i = 0; i < listaDeContasBancarias.Count; i++)
            {
                Console.WriteLine(listaDeContasBancarias[i]);
            }
        }
        private static void Sacar()
        {
            Console.Write("Informe o número da sua conta: ");
            int localizador = int.Parse(Console.ReadLine());

            for (int i = 0; i < listaDeContasBancarias.Count; i++)
            {
                if (listaDeContasBancarias[i].IdConta == localizador)
                {
                    Console.Write("Informe o valor á ser sacado: ");
                    double valorParaSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listaDeContasBancarias[i].SacarDinheiro(valorParaSaque);
                }
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("====================================================");

            Console.WriteLine("Informe uma das seguintes opções: ");
            Console.WriteLine("0 - Pessoa Fisica");
            Console.WriteLine("1 - Pessoa Juridica");
            int modalidadeConta = int.Parse(Console.ReadLine());            
            Console.Write("Informe um número de quatro dígitos para a sua conta: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Informe o nome do titular da conta: ");
            string nomeTitularConta = Console.ReadLine();
            Console.Write("Informe o depósito inicial: ");
            double saldoConta = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Informe o crédito pretendido: ");
            double creditoConta = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (modalidadeConta == 0)
            {
                if (creditoConta <= 800.00 || creditoConta > 800.00)
                {
                    creditoConta = 800.00;
                    Console.WriteLine("Valor para crédito liberado: R${0}", creditoConta.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            else if (modalidadeConta == 1)
            {
                if (creditoConta <= 3.000 || creditoConta > 3000.00)
                {
                    creditoConta = 3000.00;
                    Console.WriteLine("Valor para crédito liberado: R${0}", creditoConta.ToString("F2", CultureInfo.InvariantCulture));
                }
            }

            Console.WriteLine("=======================================================");

            ContaBancaria contaBancaria = new ContaBancaria(
                (TipoConta)modalidadeConta,
                nomeTitularConta,
                saldoConta, creditoConta, id);
            listaDeContasBancarias.Add(contaBancaria);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
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
