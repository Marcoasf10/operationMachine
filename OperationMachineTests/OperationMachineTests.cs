using System.Runtime.CompilerServices;
using OperationMachine;
namespace MachineTests;

[TestClass]
public class OperationMachineTests
{
    [TestMethod]
    public void ExtractCommands_Success()
    {
        // Arrange
        string input = "PUSH 3 PUSH 4 ADD DUP MUL POP SUB ";
        string[] words = input.Split(' ');
        
        //Act
        List<string> commands = new List<string>();
        commands = Machine.ExtractCommands(words);

        //Assert
        List<string> expectedCommands = new List<string>{"PUSH 3", "PUSH 4", "ADD", "DUP", "MUL", "POP", "SUB"};
        CollectionAssert.AreEqual(expectedCommands, commands);
    }
    
    [TestMethod]
    public void ExtractCommands_InvalidParameters()
    {
        // Arrange
        string input = "PUSH PUSH 4 ADD INVALID DUP MUL POP SUB PUSH A";
        string[] words = input.Split(' ');

        // Act
        List<string> commands = Machine.ExtractCommands(words);

        // Assert
        List<string> expectedCommands = new List<string> {"PUSH 4", "ADD", "DUP", "MUL", "POP", "SUB" };
        CollectionAssert.AreEqual(expectedCommands, commands);
    }
    
    [TestMethod]
    public void ExtractCommands_CaseInsensitive()
    {
        // Arrange
        string input = "PUsH 3 pUSH 4 ADd DUP mul POP SUB";
        string[] words = input.Split(' ');

        // Act
        List<string> commands = Machine.ExtractCommands(words);

        // Assert
        List<string> expectedCommands = new List<string> { "PUSH 3", "PUSH 4", "ADD", "DUP", "MUL", "POP", "SUB" };
        CollectionAssert.AreEqual(expectedCommands, commands);
    }
    
    [TestMethod]
    public void Run_Valid_Commands()
    {
        // Arrange
        List<string> commands = new List<string> { "PUSH 3", "PUSH 4", "ADD", "DUP", "MUL", "DUP", "ADD", "POP"};
        Queue<int> queue = new Queue<int>();
        int errorCounter = 0;
        
        // Act
        foreach (var command in commands)
        {
            string result = Machine.Operation(queue, command);
            if (result != "sucesso")
            {
                errorCounter++;
            }
        }

        // Assert
        int expectedErrorCounter = 0;
        Assert.AreEqual(expectedErrorCounter, errorCounter);
    }
    
    [TestMethod]
    public void Run_Invalid_Commands()
    {
        // Arrange
        List<string> commands = new List<string> { "PUSH 3", "PUSH 4", "ADD", "DUP", "MUL", "SUB", "ADD", "MUL", "DIV", "SWAP", "POP", "PUSH 2", "PUSH 0", "DIV"};
        Queue<int> queue = new Queue<int>();
        List<string> errorMessages = new List<string>();
        
        // Act
        foreach (var command in commands)
        {
            string result = Machine.Operation(queue, command);
            if (result != "sucesso")
            {
                errorMessages.Add(result);
            }
        }

        // Assert
        List<string> expectedErrorMessages = new List<string>{"A queue não tem elementos suficientes para realizar a operação SUB", "A queue não tem elementos suficientes para realizar a operação ADD", "A queue não tem elementos suficientes para realizar a operação MUL", "A queue não tem elementos suficientes para realizar a operação DIV", "A queue não tem elementos suficientes para realizar a operação SWAP", "O 2º elemento da operação DIV não pode ser 0"}; 
        CollectionAssert.AreEqual(expectedErrorMessages, errorMessages);
    }
}