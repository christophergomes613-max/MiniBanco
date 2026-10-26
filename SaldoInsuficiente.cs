namespace MiniBanco.consoleApp
{
    public class SaldoInsuficienteException : Exception
    {
        public  SaldoInsuficienteException(string mensagem)
           : base(mensagem)
        {
            
        }
    }
}
