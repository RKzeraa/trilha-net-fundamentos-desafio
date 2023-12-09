namespace DesafioFundamentos.Models
{
    public class TextCustom
    {
        private readonly ConsoleColor _originalColor;

        public TextCustom()
        {
            _originalColor = Console.ForegroundColor;
        }

        private string Logo()
        {
            return @"
___  _____   __  ___                      ___          _   
|   \| __\ \ / / / __| ___ __ _  _ _ _ ___| _ \__ _ _ _| |__
| |) | _| \ V /  \__ \/ -_) _| || | '_/ -_)  _/ _` | '_| / /
|___/|___| \_/   |___/\___\__|\_,_|_| \___|_| \__,_|_| |_\_\                                                                                                                                                                                                          
_____________________________________________________________

            ";
        }

        private static string Name()
        {
            return @"
____________________________________________________        
        ____  _  __                         
        |  _ \| |/ / _______ _ __ __ _  __ _ 
        | |_) | ' / |_  / _ \ '__/ _` |/ _` |
        |  _ <| . \  / /  __/ | | (_| | (_| |
        |_| \_\_|\_\/___\___|_|  \__,_|\__,_|        

____________________________________________________
            ";
        }

        public void Animacao()
        {
            int larguraBarra = 59;
            for (int i = 0; i <= larguraBarra; i++)
            {
                string barraDeCarregamento = "|" + new string('▓', i) + new string('░', larguraBarra - i) + "|";
                ShowLogo();
                ApplyColor(barraDeCarregamento, ConsoleColor.DarkGreen);
                Thread.Sleep(7); // Ajuste o intervalo de tempo conforme necessário
            }

            ShowBy();
            ApplyColor("Sistema finalizado com sucesso! ✅", ConsoleColor.DarkGreen);
        }

        public void ShowLogo()
        {
            Console.Clear();
            ApplyColor(Logo(), ConsoleColor.DarkMagenta);
        }

        public void ApplyColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = _originalColor;
        }

        private void ShowBy()
        {
            Console.Clear();
            ApplyColor("Desenvolvido por: \n" + Name(), ConsoleColor.DarkMagenta);
        }
    }
}