
using MiniBanco.consoleApp;

List<Conta> contas = new List<Conta>();

MotorAnalise motorAnalise = new MotorAnalise();

int opcao = 0;

while (opcao != 6)
{
    Console.WriteLine("1 - Abrir conta");
Console.WriteLine("2 - Realizar depósito");
Console.WriteLine("3 - Realizar saque");
Console.WriteLine("4 - Fechamento mensal");
Console.WriteLine("5 - Relatório de contas");
Console.WriteLine("6 - Sair");
    if (int.TryParse(Console.ReadLine(), out opcao))
    {
        switch (opcao)
        {
           
case 1:
{
    Console.WriteLine("\n--- Abrir Conta ---");
    Console.WriteLine("1 - Conta Corrente");
    Console.WriteLine("2 - Conta Poupança");
    Console.WriteLine("3 - Conta Salário");
    Console.Write("Escolha o tipo de conta: ");

    if (int.TryParse(Console.ReadLine(), out int tipoConta)
        && tipoConta >= 1 && tipoConta <= 3)
    {
        Console.Write("Nome do titular: ");
        string titular = Console.ReadLine() ?? "";

        Console.Write("Número da conta: ");

        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.Write("Saldo inicial: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal saldoInicial)
                && saldoInicial >= 0)
            {
                if (tipoConta == 1)
                {
                    Console.Write("Limite do cheque especial: ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal limite)
                        && limite >= 0)
                    {
                        ContaCorrente conta = new ContaCorrente(
                            titular, numero, saldoInicial, limite);

                        contas.Add(conta);
                        Console.WriteLine("Conta Corrente criada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Limite inválido.");
                    }
                }
                else if (tipoConta == 2)
                {
                    Console.Write("Taxa de rendimento mensal (%): ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal taxa)
                        && taxa >= 0)
                    {
                        Console.Write("Dia de aniversário da conta (1 a 31): ");

                        if (int.TryParse(Console.ReadLine(), out int dia)
                            && dia >= 1 && dia <= 31)
                        {
                            ContaPoupanca conta = new ContaPoupanca(
                                titular, numero, saldoInicial, taxa, dia);

                            contas.Add(conta);
                            Console.WriteLine("Conta Poupança criada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Dia de aniversário inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Taxa de rendimento inválida.");
                    }
                }
                else if (tipoConta == 3)
                {
                    Console.Write("Nome do empregador: ");
                    string empregador = Console.ReadLine() ?? "";

                    Console.Write("Limite de saques mensais: ");

                    if (int.TryParse(Console.ReadLine(), out int limiteSaques)
                        && limiteSaques >= 0)
                    {
                        ContaSalario conta = new ContaSalario(
                            titular, numero, saldoInicial,
                            empregador, limiteSaques);

                        contas.Add(conta);
                        Console.WriteLine("Conta Salário criada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Limite de saques inválido.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Saldo inicial inválido.");
            }
        }
        else
        {
            Console.WriteLine("Número da conta inválido.");
        }
    }
    else
    {
        Console.WriteLine("Tipo de conta inválido.");
    }

    break;
}



          
case 2:
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        break;
    }

    Console.Write("Número da conta: ");

    if (int.TryParse(Console.ReadLine(), out int numeroDeposito))
    {
        Conta? contaDeposito = null;

        foreach (Conta conta in contas)
        {
            if (conta.Numero == numeroDeposito)
            {
                contaDeposito = conta;
                break;
            }
        }

        if (contaDeposito != null)
        {
            Console.Write("Valor do depósito: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito)
                && valorDeposito > 0)
            {
                contaDeposito.Depositar(valorDeposito);
                Console.WriteLine("Depósito realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor de depósito inválido.");
            }
        }
        else
        {
            Console.WriteLine("Conta não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("Número da conta inválido.");
    }
    break;


case 3:
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        break;
    }

    Console.Write("Número da conta: ");

    if (int.TryParse(Console.ReadLine(), out int numeroSaque))
    {
        Conta? contaSaque = null;

        foreach (Conta conta in contas)
        {
            if (conta.Numero == numeroSaque)
            {
                contaSaque = conta;
                break;
            }
        }

        if (contaSaque != null)
        {
            Console.Write("Valor do saque: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque)
                && valorSaque > 0)
            {
                try
                {
                    contaSaque.Sacar(valorSaque);
                    Console.WriteLine("Saque realizado com sucesso!");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Valor de saque inválido.");
            }
        }
        else
        {
            Console.WriteLine("Conta não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("Número da conta inválido.");
    }
    break;

           
case 4:
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        break;
    }

    foreach (Conta conta in contas)
    {
        conta.AplicarFechamentoMensal();
    }

    Console.WriteLine("Fechamento mensal aplicado às contas.");
    break;

case 5:
    if (contas.Count == 0)
    {
        Console.WriteLine("Nenhuma conta cadastrada.");
        break;
    }

    foreach (Conta conta in contas)
    {
        motorAnalise.ExibirRelatorio(conta);
    }

    break;


            case 6:
                Console.WriteLine("Encerrando o MiniBanco...");
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Digite um número válido.");
        opcao = 0;
    }
}
