
namespace MiniBanco.consoleApp
{
    public class MotorAnalise
    {
        
public int CalcularPontuacao(Conta conta)
{
    int pontuacao = 0;

    foreach (Transacao transacao in conta.Transacoes)
    {
        if (transacao.Tipo == "Deposito")
        {
            pontuacao += 10;
        }
        else if (transacao.Tipo == "Saque")
        {
            pontuacao += 5;
        }
    }

    return pontuacao;
}

public int CalcularPontuacaoMaxima(Conta conta)
{
    int pontuacaoMaxima = 0;

    foreach (Transacao transacao in conta.Transacoes)
    {
        pontuacaoMaxima += 10;
    }

    return pontuacaoMaxima;
}

public double CalcularPercentualSaude(Conta conta)
{
    int pontuacaoObtida = CalcularPontuacao(conta);
    int pontuacaoMaxima = CalcularPontuacaoMaxima(conta);

    if (pontuacaoMaxima == 0)
    {
        return 0;
    }

    return (double)pontuacaoObtida / pontuacaoMaxima * 100;
}

public string ClassificarSaude(Conta conta)
{
    double percentual = CalcularPercentualSaude(conta);

    if (percentual >= 90)
    {
        return "Saudável";
    }
    else if (percentual >= 60)
    {
        return "Atenção";
    }
    else
    {
        return "Risco";
    }
}

public int ContarTarifas(Conta conta)
{
    int quantidade = 0;

    foreach (Transacao transacao in conta.Transacoes)
    {
        if (transacao.Tipo == "Tarifa")
        {
            quantidade++;
        }
    }

    return quantidade;
}

public int ContarSaques(Conta conta)
{
    int quantidade = 0;

    foreach (Transacao transacao in conta.Transacoes)
    {
        if (transacao.Tipo == "Saque")
        {
            quantidade++;
        }
    }

    return quantidade;
}

public string GerarRecomendacao(Conta conta)
{
    string classificacao = ClassificarSaude(conta);

    if (classificacao == "Saudável")
    {
        return "Continue mantendo bons hábitos financeiros.";
    }
    else if (classificacao == "Atenção")
    {
        return "Revise seus saques e acompanhe suas movimentações.";
    }
    else
    {
        return "Atenção: revise suas movimentações e evite tarifas desnecessárias.";
    }
}


public void ExibirRelatorio(Conta conta)
{
    Console.WriteLine("\n===== RELATÓRIO DA CONTA =====");
    Console.WriteLine($"Titular: {conta.Titular}");
    Console.WriteLine($"Número: {conta.Numero}");
    Console.WriteLine($"Saldo: R$ {conta.Saldo:F2}");

        if (conta is ContaCorrente corrente)
        {
            Console.WriteLine("Tipo: Conta Corrente");
            Console.WriteLine($"Limite do cheque especial: R$ {corrente.limiteChequeEspecial:F2}");
        }
        else if (conta is ContaPoupanca poupanca)
        {
            Console.WriteLine("Tipo: Conta Poupança");
            Console.WriteLine($"Rendimento mensal: {poupanca.RendimentoPercentual}%");
            Console.WriteLine($"Dia de aniversário: {poupanca.DiaAniversario}");
        }
        else if (conta is ContaSalario salario)
        {
            Console.WriteLine("Tipo: Conta Salário");
            Console.WriteLine($"Empregador: {salario.Empregador}");
            Console.WriteLine($"Limite de saques mensais: {salario.LimiteSaquesMensais}");
        }


Console.WriteLine("\n--- Análise Financeira ---");

Console.WriteLine(
    $"Pontuação obtida: {CalcularPontuacao(conta)}");

Console.WriteLine(
    $"Pontuação máxima: {CalcularPontuacaoMaxima(conta)}");

Console.WriteLine(
    $"Saúde financeira: {CalcularPercentualSaude(conta):F2}%");

Console.WriteLine(
    $"Classificação: {ClassificarSaude(conta)}");

Console.WriteLine("\n--- Itens de Atenção ---");

Console.WriteLine($"Tarifas (itens críticos): {ContarTarifas(conta)}");

Console.WriteLine($"Saques (itens de atenção): {ContarSaques(conta)}");

Console.WriteLine($"Recomendação: {GerarRecomendacao(conta)}");

}

    }
    
    
    
}

