# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.


## Contribuição
Nesse projeto optei em ir mais além, deixando o projeto com o meu estilo.

Com isso utilizei algumas coisas a mais, são elas:

- **ASCII Art**
- **Class Custom**
- **DateTime**
- **Tupla**
- **Regex**
- **Thread**
- **ConsoleColor**


A ideia foi deixar o visual do Console mais organizado e com minhas características, dai vem a ideia de brincar com **ASCII Art** para mostrar a Logo, também ao encerrar o sistema, o **ConsoleColor** para colorir o console dando mais ênfase enquanto sucesso ou fracasso, e a **Class Custom** para reunir toda essa parte visual referente ao texto no Console, além de colocar **Thread** para brincar um pouco, na tentativa fazer algum tipo de animação, que nesse caso usei para gerar uma barra de carregamento ao iniciar e ao finalizar o sistema.



Brincando um pouco com **DateTime** para pegar a hora em que o veiculo chega no estacionamento, para não criar uma classe a mais, optei por gerar uma **Tupla** pegando no primeiro valor uma string que nesse caso é a placa, e no segundo valor um **DateTime** que vai ser a hora de entrada, além de usar o **TimeSpan** e transformar em inteiro para auxiliar no cálculo do valor total.

Para validar a placa fiz alguns **Regex** me baseando nas placas brasileiras, no formato antigo que possui 3 letras e 4 números, e no novo formato que é 3 letras, 1 número, 1 letra e 2 números, além de usar o **.Trim()** e o **.Replace()**.



_Develop By RKzeraa🔌_
