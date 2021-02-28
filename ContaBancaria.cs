using System;
using System.Globalization;

namespace AplicacaoBancaria
{
    class ContaBancaria
    {
        public int IdConta { get; private set; }
        private string Nome { get; set; }
        private double SaldoConta { get; set; }
        public TipoConta Modalidade { get; set; }
        private double Credito { get; set; }

        public ContaBancaria(TipoConta modalidade, string nome, double saldoConta, double creditoConta, int id)
        {
            Modalidade = modalidade;
            Nome = nome;
            SaldoConta = saldoConta;
            Credito = creditoConta;
            IdConta = id;

        }
        public void DepositarDinheiro(double valorDepositado)
        {
            SaldoConta += valorDepositado;
        }

        public void SacarDinheiro(double valorSolicitadoSaque)
        {
            if (valorSolicitadoSaque < (SaldoConta + Credito))
            {
                SaldoConta -= valorSolicitadoSaque;
            }
            else
            {
                Console.WriteLine("Valor solicitado indisponível em conta");
            }
        }
        public void TrasferirDinheiro(double valorParaTransferencia)
        {
            if (valorParaTransferencia < SaldoConta + Credito)
            {
                SaldoConta -= valorParaTransferencia;
            }
            else
            {
                Console.WriteLine("Valor solicitado indisponível em conta");
            }
        }

        public override string ToString()
        {
            return
                "Numero da conta: " + IdConta + " | " +
                "Nome do titular: " + Nome + " | " +
                "Modalidade: " + Modalidade + " | " +
                "Saldo em conta: " + SaldoConta.ToString("F2", CultureInfo.InvariantCulture) + " | ";
        }

    }
}
