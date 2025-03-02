# Explorando Marte

## Descrição do Problema

O projeto "Explorando Marte" simula a exploração de um planalto em Marte por sondas robóticas. As sondas são posicionadas em um planalto com coordenadas específicas e recebem uma sequência de instruções para se mover e explorar a área. O objetivo é garantir que as sondas sigam as instruções corretamente, respeitem os limites do planalto e evitem colisões com outras sondas.

## Configuração e Execução do Projeto

### Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou outro ambiente de desenvolvimento compatível

### Passos para Configuração

1. Clone o repositório para o seu ambiente local:
   
   
```
   git clone https://github.com/seu-usuario/explorando-marte.git   
```

2. Navegue até o diretório do projeto:
   
   
```
   cd explorando-marte   
```

3. Restaure as dependências do projeto:
   
   
```
   dotnet restore   
```

### Executando o Projeto

1. Compile e execute o projeto:
   
   
```
   dotnet run --project ExplorandoMarte   
```

2. Siga as instruções no console para fornecer as coordenadas do planalto e as posições iniciais das sondas.

3. Insira a sequência de instruções para cada sonda e observe os resultados no console.

### Executando os Testes

1. Navegue até o diretório de testes:
   
   
```
   cd ExplorandoMarte.Tests   
```

2. Execute os testes:
   
   
```
   dotnet test   
```

## Decisões de Projeto

### Padrão de Design

O projeto utiliza o padrão de design **Command Pattern** para encapsular as instruções das sondas em objetos de comando. Isso promove a separação de responsabilidades e facilita a extensão e manutenção do código. O `CommandInvoker` é responsável por gerenciar a execução dos comandos, garantindo que todas as instruções sejam executadas de forma centralizada.

### Estrutura do Projeto

- **Controllers**: Contém os controladores que gerenciam a lógica de negócios.
- **Models**: Contém as classes de modelo que representam as entidades do domínio, como `Rover` e `Planalto`.
- **Services**: Contém os serviços que encapsulam a lógica de negócios e interagem com os repositórios.
- **Repositories**: Contém os repositórios que gerenciam o acesso aos dados.
- **Commands**: Contém os comandos que encapsulam as instruções das sondas.
- **Invokers**: Contém o invocador que gerencia a execução dos comandos.
- **Interfaces**: Contém as interfaces que definem os contratos para os serviços e repositórios.
- **Tests**: Contém os testes unitários para garantir a qualidade e a correção do código.

### Validação e Tratamento de Erros

O projeto inclui validações para garantir que as coordenadas e direções das sondas sejam válidas e que as sondas não se movam além dos limites do planalto ou para posições já ocupadas por outras sondas. Exceções são lançadas para tratar entradas inválidas e movimentos inválidos.
Tudo registrado em um arquivo log localizado em "C:\ExplorandoMarte\logs\log.txt"

## Debugging no VSCode

Para fazer o debugging no VSCode, siga os passos abaixo:

1. Abra o projeto no VSCode.
2. Coloque pontos de interrupção (breakpoints) no código onde deseja inspecionar a execução.
3. Pressione `F5` ou vá para o menu `Run` e selecione `Start Debugging`.
4. O VSCode iniciará o projeto e parará nos pontos de interrupção definidos, permitindo que você inspecione variáveis e o fluxo de execução.
5. Utilize F10 para avançar cada passo.
6. Utilize F11 para entrar nos métodos e fazer o debug.

## Pipeline de CI

O pipeline de CI foi configurado para garantir que todas as alterações no código sejam testadas automaticamente. O pipeline executa os testes unitários e verifica se o código está em conformidade com os padrões definidos.

### Configuração do Pipeline

O pipeline de CI está definido no arquivo `.github/workflows/dotnet-desktop.yml` e realiza as seguintes etapas:

1. **Checkout do código**: Faz o checkout do código do repositório.
2. **Configuração do .NET**: Configura o ambiente .NET com a versão 8.0.x.
3. **Restaurar dependências**: Restaura as dependências do projeto.
4. **Build**: Compila o projeto na configuração Release.
5. **Executar testes**: Executa os testes do projeto.
6. **Publicar**: Publica o projeto no diretório especificado.
7. **Upload de artefatos de build**: Faz o upload dos artefatos de build para o GitHub.


### Acompanhando os Resultados

1. Acesse a aba `Actions` no repositório do GitHub.
2. Selecione o workflow desejado para ver os detalhes da execução.
3. Verifique os logs para identificar possíveis falhas e corrigi-las.

## Comentários Adicionais

- O projeto foi estruturado para ser extensível e fácil de manter.
- O uso do Command Pattern facilita a adição de novas instruções no futuro.
- A validação rigorosa garante que as sondas operem dentro dos limites definidos e evitem colisões.

---
