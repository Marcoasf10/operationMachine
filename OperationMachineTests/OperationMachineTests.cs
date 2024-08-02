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
    public void ExtractCommands_InvalidParameter()
    {
        // Arrange
        string input = "PUSH 3 PUSH 4 ADD INVALID DUP MUL POP SUB";
        string[] words = input.Split(' ');

        // Act
        List<string> commands = Machine.ExtractCommands(words);

        // Assert
        List<string> expectedCommands = new List<string> { "PUSH 3", "PUSH 4", "ADD", "DUP", "MUL", "POP", "SUB" };
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
    
    
}