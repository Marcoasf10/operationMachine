namespace OperationMachine;

public class Machine
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo!");
        Console.WriteLine("Para começar, digite um ou mais dos seguintes comandos: \"PUSH X\": Empurra o valor X para a queue.\n\"ADD\": Adiciona os dois valores no topo da queue e empurra o resultado de volta.\n\"SUB\": Subtrai o valor no topo da queue do próximo valor e empurra o resultado de volta.\n\"MUL\": Multiplica os dois valores no topo da queue e empurra o resultado de volta.\n\"DIV\": Divide o valor no topo da queue pelo próximo valor e empurra o resultado de volta.\n\"DUP\": Duplica o valor no topo da queue.\n\"POP\": Remove o valor no topo da queue.\nSWAP: Inverte a posição dos dois valores no topo da queue.");
    }
}