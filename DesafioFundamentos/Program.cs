using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;
// Instancia a classe Estacionamento, já com os valores obtidos anteriormente

TextCustom textCustom = new TextCustom();
textCustom.Animacao();
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

decimal precoInicial = ObterPrecoInicial(textCustom);

decimal precoPorHora = ObterPrecoPorHora(textCustom);

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    textCustom.ShowLogo();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.Write("\r\nSelecione uma opção: ");

    switch (Console.ReadLine())
    {
        case "1":  
            es.AdicionarVeiculo();
            break;

        case "2":
            Console.Clear();
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            textCustom.ShowLogo();
            exibirMenu = false;
            break;

        default:
            textCustom.ShowLogo();
            textCustom.ApplyColor("Opção inválida", ConsoleColor.Red);
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

textCustom.Animacao();

#region Métodos
static decimal ObterPrecoInicial(TextCustom textCustom)
{
    while(true)
    {
        textCustom.ShowLogo();
        Console.WriteLine("Digite o preço inicial:");

        if (decimal.TryParse(Console.ReadLine(), out decimal preco) && preco >= 0)
        {
            return preco;
        }
        else
        {
            textCustom.ShowLogo();
            textCustom.ApplyColor("O valor digitado não é um número válido", ConsoleColor.Red);
        }
    }
}

static decimal ObterPrecoPorHora(TextCustom textCustom)
{
    while(true)
    {
        textCustom.ShowLogo();
        Console.WriteLine("Agora digite o preço por hora:");

        if (decimal.TryParse(Console.ReadLine(), out decimal preco) && preco >= 0)
        {
            return preco;
        }
        else
        {
            textCustom.ShowLogo();
            textCustom.ApplyColor("O valor digitado não é um número válido", ConsoleColor.Red);
        }
    }
}

#endregion