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
        
        foreach (var command in commands)
        {
            Console.WriteLine("\nCommand " + command);
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
}
