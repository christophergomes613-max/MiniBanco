using System.ComponentModel;

namespace MiniBanco.consoleApp
{
public abstract class Conta
    {
        public string Titular {get; protected set;}= "";
        public int Numero { get; protected set; }
        public decimal Saldo { get; protected set;}
        public List<Transacao> Transacoes{get;} = new List<Transacao>();
        
        protected Conta(string titular, int numero, decimal saldoinicial)
        {
            Titular = titular;
            Numero = numero;
            Saldo =  saldoinicial;
        }
        public void RegistrarTransacao(Transacao transacao)
        {
            Transacoes.Add(transacao);
        }
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O depósito deve ser maior que zero.");
            }

            Saldo += valor;

            RegistrarTransacao(new Transacao
            {
                Tipo = "Deposito",
                Valor = valor,
                Data = DateTime.Now
            });
        }
        public virtual void Sacar(decimal valor)
        {  
             if (valor <= 0)
            {
                throw new ArgumentException("O saque deve ser maior que zero");
            }

            if (valor > Saldo)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque");
            }

            Saldo -= valor;

            RegistrarTransacao(new Transacao
            {
                  Tipo = "Saque",
                  Valor = valor,
                  Data = DateTime.Now
            });

        }
      
      public  virtual void AplicarFechamentoMensal()
        {
            
        }
    }
}    
