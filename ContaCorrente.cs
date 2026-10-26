using System.Data;

namespace MiniBanco.consoleApp
{
 public class ContaCorrente : Conta
    {
        public decimal limiteChequeEspecial {get; private set;}
         
         public ContaCorrente(
            string titular,
            int numero,
            decimal saldoInicial,
            decimal LimiteChequeEspecial)
            : base(titular, numero, saldoInicial)
        {
            LimiteChequeEspecial = limiteChequeEspecial;
        }

        public override void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O saque deve ser maior que zero.");
            }

            if (valor > Saldo + limiteChequeEspecial)
            {
                throw new SaldoInsuficienteException(
                    "Saldo e limite do cheque especial insuficiente.");
            }

            Saldo -= valor;

            RegistrarTransacao(new Transacao
            {
                   Tipo = "Saque",
                   Valor = valor,
                   Data = DateTime.Now
            });
        }

        public override void AplicarFechamentoMensal()
        {
           decimal tarifa = 10;

           Saldo -= tarifa;
           
           RegistrarTransacao(new Transacao
           {
               Tipo = "Tarifa",
               Valor = tarifa,
               Data = DateTime.Now
           });
        }
    }
}