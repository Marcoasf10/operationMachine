using System.Runtime.CompilerServices;

namespace OperationMachine;

static class Constants
{
    public const string Push = "PUSH";
    public const string Add = "ADD";
    public const string Sub = "SUB";
    public const string Mul = "MUL";
    public const string Div = "DIV";
    public const string Dup = "DUP";
    public const string Pop = "POP";
    public const string Swap = "SWAP";
    public const string Success = "SUCCESS";
}
public class Machine
{
    private static readonly HashSet<string> KnownCommands = new HashSet<string> 
    { 
        Constants.Push, Constants.Add, Constants.Sub, Constants.Mul, Constants.Div, Constants.Dup, Constants.Pop, Constants.Swap 
    };
    
    static void Main(string[] args)
    {
        Console.WriteLine("Operations Machine\n");
        Console.WriteLine("Para começar, digite um ou mais dos seguintes comandos: \n\n\"PUSH X\": Empurra o valor X para a queue.\n\"ADD\": Adiciona os dois valores no topo da queue e empurra o resultado de volta.\n\"SUB\": Subtrai o valor no topo da queue do próximo valor e empurra o resultado de volta.\n\"MUL\": Multiplica os dois valores no topo da queue e empurra o resultado de volta.\n\"DIV\": Divide o valor no topo da queue pelo próximo valor e empurra o resultado de volta.\n\"DUP\": Duplica o valor no topo da queue.\n\"POP\": Remove o valor no topo da queue.\nSWAP: Inverte a posição dos dois valores no topo da queue.\n");
        Console.WriteLine("Exemplo de entrada: \"PUSH 3 PUSH 4 ADD DUP MUL POP SUB\"");

        Queue<int> queue = new Queue<int>();
        string input;
        while (true)
        {
            Console.Write("\nSelecione comandos para começar ou pressione 'q' para sair: ");
            input = Console.ReadLine();
            
            if (input.ToLower() == "q")
            {
                break;
            }

            string[] words = input.Split(' ');
            List<string> commands = ExtractCommands(words);
            if (commands.Count > 0)
            {
                string success;
                for (int i = 0; i < commands.Count; i++)
                {
                    success = Operation(queue, commands[i]);
                    if (success.Equals(Constants.Success))
                    {
                        Console.WriteLine("\n" + i + 1 + "º instrução: " + commands[i] + " => " + "[" + string.Join(", ", queue) + "]");
                    }
                    else
                    {
                        Console.WriteLine("\n" + i + 1 + "º instrução: " + commands[i] + " => " + "Erro - " + success);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNão foram introduzidos comandos válidos");
            }
        }
        Console.WriteLine("\nPrograma terminado. Pressione Enter para sair...");
        Console.ReadLine();
    }
    
    public static List<string> ExtractCommands(string[] words)
    {
        List<string> commands = new List<string>();
        for (int i = 0; i <= words.Length - 1; i++)
        {
            words[i] = words[i].ToUpper();
            if (KnownCommands.Contains(words[i]))
            {
                if (!words[i].Equals(Constants.Push))
                {
                    commands.Add(words[i]);
                }
                else
                {
                    if (i + 1 < words.Length)
                    {
                        if(int.TryParse(words[i+1],out _))
                        {
                            var wordAux = words[i] + " " +words[i + 1];
                            commands.Add(wordAux);
                        }
                        else
                        {
                            if (KnownCommands.Contains(words[i+1].ToUpper()))
                            {
                                Console.WriteLine("\nComando PUSH sem argumento\n");
                            }
                            else
                            {
                                Console.WriteLine("\nParâmetro \"" + words[i+1].ToUpper() + "\" inválido no PUSH. O valor tem de ser numérico\n");
                            }
                        }
                    }
                }
            }
        }
        return commands;
    }

    public static string Operation(Queue<int> queue, string command)
    {
        if (command.StartsWith(Constants.Push))
        {
            var valor = command.Substring(4); //extrair resto do comando a seguir a "PUSH "
            queue.Enqueue(int.Parse(valor)); // Sabe-se que o valor é numérico porque foi verificado no método de extração dos comandos  
        }
        else
        {
            switch (command)
            {
                case Constants.Add:
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var addValor1 = queue.Dequeue();
                    var addValor2 = queue.Dequeue();
                    queue.Enqueue(addValor1 + addValor2);
                    
                    break;
                case Constants.Sub:
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var subValor1 = queue.Dequeue();
                    var subValor2 = queue.Dequeue();
                    queue.Enqueue(subValor1 - subValor2);
                    
                    break;
                case Constants.Mul:
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var mulValor1 = queue.Dequeue();
                    var mulValor2 = queue.Dequeue();
                    queue.Enqueue(mulValor1 * mulValor2);
                    
                    break;
                case Constants.Div:
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var divValor1 = queue.Dequeue();
                    var divValor2 = queue.Dequeue();
                    if (divValor2 == 0)
                    {
                        return "O 2º elemento da operação " + command + " não pode ser 0";
                    }
                    queue.Enqueue(divValor1 / divValor2);
                    
                    break;
                case Constants.Dup:
                    if (queue.Count < 1)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    queue.Enqueue(queue.Peek());
                    
                    break;
                case Constants.Pop:
                    if (queue.Count < 1)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    queue.Dequeue();
                    
                    break;
                case Constants.Swap:
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var swapValor1 = queue.Dequeue();
                    var swapValor2 = queue.Dequeue();
                    queue.Enqueue(swapValor2);
                    queue.Enqueue(swapValor1);
                    
                    break;
                default:
                    return "Comando não reconhecido.";
            }
        }
        return Constants.Success;
    }
}
