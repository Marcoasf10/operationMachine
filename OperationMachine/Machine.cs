namespace OperationMachine;

public class Machine
{
    private static readonly HashSet<string> KnownCommands = new HashSet<string> 
    { 
        "PUSH", "ADD", "SUB", "MUL", "DIV", "DUP", "POP", "SWAP" 
    };
    
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo!\n");
        Console.WriteLine("Para começar, digite um ou mais dos seguintes comandos: \"PUSH X\": Empurra o valor X para a queue.\n\"ADD\": Adiciona os dois valores no topo da queue e empurra o resultado de volta.\n\"SUB\": Subtrai o valor no topo da queue do próximo valor e empurra o resultado de volta.\n\"MUL\": Multiplica os dois valores no topo da queue e empurra o resultado de volta.\n\"DIV\": Divide o valor no topo da queue pelo próximo valor e empurra o resultado de volta.\n\"DUP\": Duplica o valor no topo da queue.\n\"POP\": Remove o valor no topo da queue.\nSWAP: Inverte a posição dos dois valores no topo da queue.\n");
        Console.WriteLine("\nExemplo de entrada: \"PUSH 3 PUSH 4 ADD DUP MUL POP SUB\"");
        
        string input;
        input = Console.ReadLine();
        string[] words = input.Split(' ');
        
        List<string> commands = new List<string>();
        commands = ExtractCommands(words);

        Queue<int> queue = new Queue<int>();
        string success;
        for (int i = 0; i < commands.Count; i++)
        {
            success = Operation(queue, commands[i]);
            if (success.Equals("sucesso"))
            {
                Console.WriteLine(i+1 +"º instrução: " + commands[i] + " => " +"[" + string.Join(", ", queue) + "]");
            }
            else
            {
                Console.WriteLine(i+1 +"º instrução: " + commands[i] + " => " +"Erro - " + success);
            }
            
        }
    }

    private static List<string> ExtractCommands(string[] words)
    {
        List<string> commands = new List<string>();
        for (int i = 0; i <= words.Length - 1; i++)
        {
            words[i] = words[i].ToUpper();
            if (KnownCommands.Contains(words[i]))
            {
                if (words[i].Equals("PUSH"))
                {
                    var wordAux = words[i] + words[i + 1];
                    i++;
                    commands.Add(wordAux);
                    continue;
                }
                commands.Add(words[i]);
            }
        }
        return commands;
    }

    private static string Operation(Queue<int> queue, string command)
    {
        if (command.StartsWith("PUSH"))
        {
            var valor = command.Substring(4); //extrair resto do comando a seguir a "PUSH"
            if (int.TryParse(valor, out int number)) // tentar converter a string valor para um inteiro. Se a conversão for bem-sucedida, o número é armazenado em number
            {
                queue.Enqueue(number);
            }
        }
        else
        {
            switch (command)
            {
                case "ADD":
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var addValor1 = queue.Dequeue();
                    var addValor2 = queue.Dequeue();
                    queue.Enqueue(addValor1 + addValor2);
                    
                    break;
                case "SUB":
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var subValor1 = queue.Dequeue();
                    var subValor2 = queue.Dequeue();
                    queue.Enqueue(subValor1 - subValor2);
                    
                    break;
                case "MUL":
                    if (queue.Count < 2)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    var mulValor1 = queue.Dequeue();
                    var mulValor2 = queue.Dequeue();
                    queue.Enqueue(mulValor1 * mulValor2);
                    
                    break;
                case "DIV":
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
                case "DUP":
                    if (queue.Count < 1)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    queue.Enqueue(queue.Peek());
                    
                    break;
                case "POP":
                    if (queue.Count < 1)
                    {
                        return "A queue não tem elementos suficientes para realizar a operação " + command;
                    }
                    queue.Dequeue();
                    
                    break;
                case "SWAP":
                    if (queue.Count >= 2)
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
        return "sucesso";
    }
}
