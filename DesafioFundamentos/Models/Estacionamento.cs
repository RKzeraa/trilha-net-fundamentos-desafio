
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<Tuple<string, DateTime>> _veiculos = new List<Tuple<string, DateTime>>();

        private readonly TextCustom _textCustom = new TextCustom();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            _textCustom.ShowLogo();
            do
            {
                
                Console.WriteLine("Digite a placa do veículo para estacionar:");

                string placa = Console.ReadLine().Trim().Replace("-", "").ToUpper();

                if (ExistePlaca(placa))
                {
                    _textCustom.ShowLogo();
                    _textCustom.ApplyColor($"Desculpe, esse veículo {FormatarPlaca(placa)} já está estacionado aqui. ❌\nCaso a placa e as características dos veículos sejam idênticas, favor entrar em contato com a polícia.\nDisk Denúncia: 181", ConsoleColor.Red);
                    break;
                }

                if (!PlacaValida(placa))
                {
                    _textCustom.ShowLogo();
                    _textCustom.ApplyColor("Desculpe, essa placa não é válida. ❌\nExemplo de placa válida: AAA-0000 ou AAA0000 ou AAA0A00 ⚠", ConsoleColor.Red);
                }
                else
                {
                    DateTime horaEntrada = DateTime.Now;
                    _veiculos.Add(new Tuple<string, DateTime>(placa, horaEntrada));
                    _textCustom.ShowLogo();
                    _textCustom.ApplyColor($"O veículo {FormatarPlaca(placa)} foi liberado para estacionar! ✅ \nHora de Entrada: {horaEntrada.ToString("HH:mm")}", ConsoleColor.DarkGreen);
                    break;
                }
            } while (true);
        }

        private bool ExistePlaca(string placa)
        {
            if(_veiculos.Any(x => x.Item1 == placa))
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
            if (!_veiculos.Any())
            {
                _textCustom.ShowLogo();
                _textCustom.ApplyColor("Não há veículos estacionados. ❌", ConsoleColor.Red);
                return;
            }

            _textCustom.ShowLogo();
            ListarVeiculos();

            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().Replace("-", "").ToUpper();
            if(!PlacaValida(placa))
            {
                _textCustom.ShowLogo();
                _textCustom.ApplyColor("Desculpe, essa placa não é válida. ❌\nExemplo de placa válida: AAA-0000 ou AAA0000 ou AAA0A00 ⚠", ConsoleColor.Red);
                return;
            }
            if (!ExistePlaca(placa))
            {
                _textCustom.ShowLogo();
                _textCustom.ApplyColor($"Desculpe, esse veículo {FormatarPlaca(placa)} não está estacionado aqui. ❌\nConfira se digitou a placa corretamente ⚠", ConsoleColor.Red);
                return;
            }

            DateTime horaEntrada = _veiculos.First(x => x.Item1 == placa).Item2;
            DateTime horaSaida = DateTime.Now;
            int diferenca = (int)CalcularDiferencaDeHoras(horaEntrada, horaSaida).TotalHours;

            _textCustom.ShowLogo();
            Console.WriteLine($"O veículo {FormatarPlaca(placa)} permaneceu estacionado por {diferenca}h");

            decimal valorTotal = ValorPagar(diferenca);

            _veiculos.Remove(_veiculos.First(x => x.Item1 == placa));

            _textCustom.ApplyColor($"Saída liberada {FormatarPlaca(placa)}, o preço total pago foi de: R$ {valorTotal} ✔", ConsoleColor.DarkGreen);
        }

        private decimal ValorPagar(int diferenca)
        {
            return _precoInicial + _precoPorHora * diferenca;
        }

        private static TimeSpan CalcularDiferencaDeHoras(DateTime horaEntrada, DateTime horaSaida)
        {
            TimeSpan diferenca = horaSaida - horaEntrada;
            return diferenca;
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            _textCustom.ShowLogo();
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (var veiculo in _veiculos)
                {
                    _textCustom.ApplyColor($"Placa: [{FormatarPlaca(veiculo.Item1)}] - Hora de Entrada: {veiculo.Item2.ToString("HH:mm")}", ConsoleColor.DarkGreen);
                }
            }
            else
            {   
                _textCustom.ApplyColor("Não há veículos estacionados. ❌", ConsoleColor.Red);
            }
        }
    }
}
