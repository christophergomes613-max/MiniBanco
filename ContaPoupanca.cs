namespace MiniBanco.consoleApp
{
    public class ContaPoupanca : Conta
    {
        public decimal RendimentoPercentual {get; private set;}

        public int DiaAniversario {get; private set; }
        public ContaPoupanca(
            string titular,
            int numero,
            decimal saldoInicial,
            decimal rendimentoPercentual,
            int diaAniversario)
            : base(titular, numero, saldoInicial)
        {
            RendimentoPercentual = rendimentoPercentual;
            DiaAniversario = diaAniversario;
        }

        public override void AplicarFechamentoMensal()
        {
            decimal rendimento = Saldo * (RendimentoPercentual / 100);

            Saldo += rendimento;

            RegistrarTransacao(new Transacao
            {
                Tipo = "Deposito",
                Valor = rendimento,
                Data = DateTime.Now
                
            });
        }
    }
}