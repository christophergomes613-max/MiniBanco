
namespace MiniBanco.consoleApp
{
    public class ContaSalario : Conta
    {
        private int saquesRealizadosNoMes = 0;
        public string Empregador { get; private set; }

        public int LimiteSaquesMensais { get; private set; }

        public ContaSalario(
            string titular,
            int numero,
            decimal saldoInicial,
            string empregador,
            int limiteSaquesMensais)
            : base(titular, numero, saldoInicial)
        {
            Empregador = empregador;
            LimiteSaquesMensais = limiteSaquesMensais;
        }
        public override void Sacar(decimal valor)
        {
            base.Sacar(valor);

            saquesRealizadosNoMes++;

            if (saquesRealizadosNoMes > LimiteSaquesMensais)
            {
                decimal tarifa = 5m;
                Saldo -= tarifa;
                RegistrarTransacao(new Transacao
                {
                    Tipo = "Tarifa",
                    Valor = tarifa,
                    Data = DateTime.Now
                });
            }
        }

public override void AplicarFechamentoMensal()
{
    saquesRealizadosNoMes = 0;
}

    }
    
}
