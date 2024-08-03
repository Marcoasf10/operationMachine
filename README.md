# Máquina de Operações em C#

Este projeto tem como objetivo o desenvolvimento de uma máquina em formato de aplicação consola que recebe comandos e executa operações numa pilha.

A linguagem escolhida para o desenvolvimento foi C# através da plataforma JetBrains Rider e com recurso ao .NET Core 8. Além do projeto com a classe que programa a máquina, a solução conta com um projeto com cenários de teste para aferir a qualidade e capacidade de resposta da máquina aos vários cenários.

## Funcionalidades

- **PUSH X**: Empurra o valor X para a pilha.
- **ADD**: Adiciona os dois valores no topo da pilha e empurra o resultado de volta.
- **SUB**: Subtrai o valor no topo da pilha do próximo valor e empurra o resultado de volta.
- **MUL**: Multiplica os dois valores no topo da pilha e empurra o resultado de volta.
- **DIV**: Divide o valor no topo da pilha pelo próximo valor e empurra o resultado de volta.
- **DUP**: Duplica o valor no topo da pilha.
- **POP**: Remove o valor no topo da pilha.
- **SWAP**: Inverte a posição dos dois valores no topo da pilha.


## Estrutura do Projeto

- **Machine.cs**: Contém a lógica principal da aplicação de consola.
- **MachineTests.cs**: Contém os cenários de teste para verificar as funcionalidades da máquina.

## Executávies da aplicação

- **Windows**: "./OperationMachine/bin/Release/net8.0/win-x64/publish/OperationMachine.exe"
- **Mac processador apple**: "./OperationMachine/bin/Release/net8.0/osx-arm64/publish/OperationMachine" 