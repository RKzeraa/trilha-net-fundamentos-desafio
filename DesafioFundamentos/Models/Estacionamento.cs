
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        private readonly TextCustom textCustom = new TextCustom();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            textCustom.ShowLogo();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().Replace("-", "").ToUpper();
            while(true){
                if(!ExistePlaca(placa))
                {
                    if(PlacaValida(placa)){
                        textCustom.ShowLogo();
                        veiculos.Add(placa);
                        textCustom.ApplyColor($"O veículo {FormatarPlaca(placa)} foi liberado para estacionar! ✅", ConsoleColor.DarkGreen);
                        break;
                    }
                    else
                    {
                        textCustom.ShowLogo();
                        textCustom.ApplyColor("Desculpe, essa placa não é válida. ❌\nExemplo de placa valida: AAA-0000 ou AAA0000 ou AAA0A00 ⚠", ConsoleColor.Red);
                        Console.WriteLine("Digite uma placa válida:");
                        placa = Console.ReadLine().Trim().Replace("-", "").ToUpper();
                    }
                }
                else
                {
                    textCustom.ShowLogo();
                    textCustom.ApplyColor($"Desculpe, esse veículo {FormatarPlaca(placa)} já está estacionado aqui. ❌" +
                     "\nCaso a placa e as características dos veículos sejam idênticas, favor entrar em contato com a policia." +
                     "\nDisk Denuncia: 181", ConsoleColor.Red);
                    break;
                }
            }
        }

        private bool ExistePlaca(string placa)
        {
            if(veiculos.Any(x => x == placa))
            { 
                return true;
            }
            return false;
        }

        private bool PlacaValida(string placa)
        {
            bool placaValida = false;
            if(!string.IsNullOrEmpty(placa))
            {
                return FormatoValido(placa);
            }

            
            return placaValida;        
        }

        private static bool FormatoValido(string placa)
        {
            bool placaValida = false;

            string formatoAntigo = @"^[A-Z]{3}\d{4}$"; // AAA0000 ou seja 3 letras maiúsculas e 4 números sem o ifen
            if(Regex.IsMatch(placa, formatoAntigo))
            {
                placaValida = true;
                return placaValida;
            }

            string formatoNovo = @"^[A-Z]{3}\d[A-Z]\d{2}$"; // AAA0A00 ou seja 3 letras maiúsculas, 1 número, 1 letra maiúscula e 2 números sem o ifen
            if(Regex.IsMatch(placa, formatoNovo))
            {
                placaValida = true;
                return placaValida;
            }

            return placaValida;
        }

        static string FormatarPlaca(string placa)
        {
            // Verifica se a placa segue o formato antigo e adiciona '-' se necessário
            if (Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$"))
            {
                placa = placa.Insert(3, "-");
            }

            return placa;
        }
        public void RemoverVeiculo()
        {
            textCustom.ShowLogo();
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                textCustom.ShowLogo();
                Console.WriteLine($"Digite a quantidade de horas que o veículo {placa} permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                textCustom.ApplyColor($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal} ✔", ConsoleColor.DarkGreen);
            }
            else
            {
                textCustom.ApplyColor($"Desculpe, esse veículo {placa} não está estacionado aqui. ❌\nConfira se digitou a placa corretamente ⚠", ConsoleColor.Red);
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                textCustom.ShowLogo();
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var veiculo in veiculos)
                {
                    textCustom.ApplyColor($"[{FormatarPlaca(veiculo)}]", ConsoleColor.DarkGreen);
                }
            }
            else
            {   
                textCustom.ApplyColor("Não há veículos estacionados. ❌", ConsoleColor.Red);
            }
        }
    }
}
