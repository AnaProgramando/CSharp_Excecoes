![banner CSharp - Exceções](https://github.com/AnaProgramando/CSharp_Excecoes/blob/09a5f8fc94afc38948c1ab022b4ea6752f608e0b/CSharp_Excecoes.png)
----

<img src="https://img.shields.io/static/v1?label=Status&message=complete&color=32CD32&style=for-the-badge"/>

<p align="center">
 <a href="#-welcome">Welcome</a> | 
 <a href="#-csharp---exce%C3%A7%C3%B5es">Exceções</a> | 
 <a href="#-material-base">Material base</a> | 
 <a href="#-primeiros-passos-com-exce%C3%A7%C3%B5es">Primeiros passos com exceções</a> | 
 <a href="#-tratamento-de-exce%C3%A7%C3%B5es">Tratamento de exceções</a> | 
 <a href="#-argumentexception-paramname-e-nameof">ArgumentException ParamName e nameof</a> | 
 <a href="#-criando-exce%C3%A7%C3%B5es-ricas">Criando exceções ricas</a> | 
 <a href="#-stacktrace-e-innerexception">StackTrace e InnerException</a> | 
 <a href="#-finally-e-using">Finally e using</a> | 
 <a href="#-refer%C3%AAncias">Referências</a> | 
 <a href="#-d%C3%BAvidas">Dúvidas</a> | 
 <a href="#%EF%B8%8F-contatos">Contatos</a> | 
 <a href="#%EF%B8%8F-desenvolvedora">Desenvolvedora</a>
</p>

# 🤗 Welcome

Olá, seja muito bem vinda(o)! 

Tive a ideia de começar o desafio de #100DaysOfCode, além de compartilhar alguns projetos para quem tem interesse em aprender C#, por isso se trata de algo bem simples para quem gostaria de iniciar na programação ou precisa melhorar as suas habilidades.

<br>

## <img align="center" alt="Ana-Csharp" height="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg"> CSharp - Exceções

📚 Aproveite o código desse exercício

👩‍💻 Refaça do seu jeito

😉 Se tiver qualquer dúvida, me contate

<br>

## 📚 Material base

Para seguir os passos abaixo e trabalhar com exceções baixe o projeto que trata de heranças e interfaces [clicando aqui](https://github.com/AnaProgramando/CSharp_Heranca-e-interface).

<br>

## 👣 Primeiros passos com exceções 

- Abra o arquivo Program.cs 

- Crie o método dividir:
```
public static int Dividir(int numero, int divisor)
{
    return numero / divisor;
}
```

- Para visualizar a CallStack, crie os métodos Metodo() e TestaDivisao():

###### 💬 CallStack: Se trata de uma cadeia de caracteres que contém informações do rastreamento de pilha.

```
static void Metodo()
{
    TestaDivisao(0);
}
static void TestaDivisao(int divisor)
{
    Dividir(10, divisor);
}
```

- No método Main, faça uma chamada ao Metodo():

```
static void Main(string[] args)
{
    Metodo();
    Console.ReadLine();
}
```

- Execute a aplicação

###### 💬 Será possível ver que houve uma exceção não tratada, pois a CLR (Common Language Runtime) não encontrou um manipulador dessa exceção no código, por isso o Visual Studio exibiu as informações da exceção e execução do programa.

###### 💬 CLR: O .NET fornece um ambiente de tempo de execução, chamado de Common Language Runtime, que executa o código e fornece serviços que facilitam o processo de desenvolvimento. 

- Para tratar a exceção, adicione um bloco try/catch para o tipo DivideByZeroException no método Main:

```
static void Main(string[] args)
{
    try
    {
        Metodo();
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Exceção tratada.");
    }
    Console.ReadLine();
}
```

###### 💬 Ao executar a aplicação, irá imprimir a exceção tratada e continuar executando, aguardando o método Console.ReadLine() retornar. Quando uma exceção é lançada, o CLR procura a instrução catch que trata essa exceção. Se o método em execução no momento não contiver um bloco catch, o CLR procurará no método que chamou o método atual e assim por diante para cima na pilha de chamadas. Se nenhum bloco catch for encontrado, o CLR exibirá uma mensagem de exceção sem tratamento para o usuário e interromperá a execução do programa.

###### 💬 Try: O bloco try contém o código protegido que pode causar a exceção, e ele é executado até que uma exceção seja lançada ou ocorra a conclusão com êxito.

###### 💬 Catch: O bloco catch especifica os manipuladores para diferentes exceções. Usar argumentos catch é uma maneira de filtrar as exceções que deseja manipular. Na ocorrência de uma exceção, a máquina virtual visita, de cima para baixo, os blocos catch definidos.

###### 💬  No C# os erros NÃO são os números que estamos acostumados a ver e que muitas vezes precisamos buscar o significado, nele os erros são objetos.

- Nomeie a referência para a exceção do tipo DivideByZeroException:

```
catch (DivideByZeroException excecao)
```

###### 💬 catch(DivideByZeroException) - Informa que não é possível fazer uma divisão por 0.

- Utilize as duas propriedades da exceção Message e StackTrace para o rastro da pilha entre lançamento de exceção e o tratamento no bloco catch:

###### 💬 Message: A mensagem de erro que explica o motivo da exceção ou de uma cadeia de caracteres vazia (""). O texto da propriedade Message deve descrever completamente o erro e, quando possível, também explicar como corrigí-lo. Eles também podem exibir a mensagem para os usuários finais, de modo que você deve verificar se ela está gramaticalmente correta, se cada frase da mensagem termina com ponto, sem o uso de interrogação ou exclamação.

###### 💬 StackTrace: A propriedade StackTrace retorna os quadros da pilha de chamadas que se originam no local onde a exceção foi gerada, mostrando uma cadeia de caracteres que descreve os quadros imediatos da pilha de chamadas. A pilha de execução mantém o controle de todos os métodos que estão em execução em um determinado instante. Um rastreamento das chamadas de método é chamado de rastreamento de pilha, e a listagem de rastreamento de pilha fornece uma maneira de seguir a pilha de chamadas para o número de linha no método em que ocorre a exceção.

```
catch (DivideByZeroException excecao)
{
    Console.WriteLine(excecao.Message);
    Console.WriteLine(excecao.StackTrace);
}
```

###### 💬 Executando a StackTrace temos a mensagem de tentativa de divisão por zero, e em seguida uma descrição da trilha seguida pela chamada dos métodos, primeiro Dividir() e, em seguida o TestaDivisao().

- Para testar outro tipo de exceção, tente acessar um membro de uma referência nula no método Dividir:

```
static int Dividir(int numero, int divisor)
{
    ContaCorrente conta = null;
    Console.WriteLine(conta.Saldo);
    return numero / divisor;
}
```

###### 💬 Executando a aplicação é possível ver que a exceção do tipo NullReferenceException foi lançada e não houve tratamento, pois só temos blocos try e catch para o tipo DivideByZeroException.

- Adicione um tratamento para esta exceção no método Metodo:

```
static void Metodo()
{
    try
    {
        TestaDivisao(0);
    }
    catch (NullReferenceException excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
}
```

###### 💬 Executando a aplicação podemos observar que o processo não é encerrado abruptamente e houve uma alteração nos dados apresentados na menssagem do StackTrace, pois a exceção foi tratada em Metodo e não no Main.

<br>

## 📚 Tratamento de exceções

- Mantenha o bloco try/catch apenas no método Main e remova os outros.

- Crie um bloco try com vários catch’s para testar, adicione para estes tipos de exceções no Main:

```
static void Main(string[] args)
{
    try
    {
        Metodo();
    }
    catch (DivideByZeroException excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
    catch (NullReferenceException excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
    Console.ReadLine();
}
```

- Execute a aplicação com a linha "Console.WriteLine(conta.Saldo)"" do método Dividir, depois execute comentando esse trecho, note que as exceções são tratadas pelo método Main.

- Simplifique os blocos catch e trate apenas o tipo Exception:

###### 💬 Todas as exceções no .NET derivam do tipo Exception, é nela onde as propriedades Message e StackTrace são definidas.

```
static void Main(string[] args)
{
    try
    {
        Metodo();
    }
    catch (Exception excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
    Console.ReadLine();
}
```

- Execute com e sem comentário no trecho "Console.WriteLine(conta.Saldo)" verificando os resultados.

- Crie um tratamento especial para a exceção do tipo DivideByZeroException, adicionando o bloco catch após o catch(Exception excecao):

```
static void Main(string[] args)
{
    try
    {
        Metodo();
    }
    catch (Exception excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
    catch (DivideByZeroException excecao)
    {
        Console.WriteLine("Não é possível divisão por 0!");
    }
    Console.ReadLine();
}
```

###### 💬 Como o CLR verifica os blocos catch de cima para baixo, colocando na ordem Exception -> DivideByZeroException, os tratamentos de tipos mais derivados nunca serão executados. 

- Inverta a ordem dos catchs, definindo primeiro os tipos de exceção mais derivados, e depois de tipos menos derivados:

```
static void Main(string[] args)
{
    try
    {
        Metodo();
    }
    catch (DivideByZeroException excecao)
    {
        Console.WriteLine("Não é possível divisão por 0!");
    }
    catch (Exception excecao)
    {
        Console.WriteLine(excecao.Message);
        Console.WriteLine(excecao.StackTrace);
    }
    Console.ReadLine();
}
```

- Adicione um bloco try/catch no método Dividir para realizar uma ação antes de propagar a exceção para o método seguinte:

```
static int Dividir(int numero, int divisor)
{
    try
    {
        return numero / divisor;
    }
    catch (Exception)
    {
        Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
    }
}
```

###### 💬 Como a CLR entende que foi manipulada a exceção no método Dividir, logo se trata de um caminho sem a instrução return, o que é incorreto.

- Use a palavra reservada throw no bloco catch para propagar a exceção para o próximo método da callstack:

###### 💬 Throw (lançar): É possível tratar uma exceção simplesmente criando-se uma notificação da sua ocorrência, e continuar propagando-a pela pilha de chamadas. Quando usamos a palavra reservada "throw" o compilador deixa de identificar o erro no código, posto que é um controle de fluxo, ele indica o encerramento do método, então qualquer código que estiver abaixo dele não será executado.

```
static int Dividir(int numero, int divisor)
{
    try
    {
        return numero / divisor;
    }
    catch (Exception)
    {
        Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
        throw;
    }
}
```

###### 💬 Quando temos um throw vazio dentro de um bloco catch, a máquina virtual passa o objeto de exceção para o próximo método na pilha de chamadas, assim sucessivamente até encontrar um bloco catch que possa pegar a exceção.

- A convenção é utilizar o nome "e" ou "ex" no nome exception para as variáveis de exceção capturadas nos blocos catch, então altere o "exception".

<br>

## 📚 ArgumentException ParamName e nameof

- Como os setters das propriedades Numero e Agencia não são necessários, altere a definição destas propriedades para:

```
public int Agencia { get; }
public int Numero { get; }
```

- A verificação de Numero e Agencia devem estar no construtor. Adicione o código para verificar se os valores das variáveis int agencia e int numero são maiores que 0 e, caso contrário, lançar uma exceção.

- O .NET possui uma classe para representar uma exceção de argumento inválido, a ArgumentException:

###### 💬 ArgumentException: A exceção que é gerada quando um dos argumentos fornecidos para um método não é válido.

```
public ContaCorrente(int agencia, int numero)
{
    if (agencia <= 0)
    {
        throw new ArgumentException();
    }

    if(numero <= 0)
    {
        throw new ArgumentException();
    }

    Agencia = agencia;
    Numero = numero;

    TotalDeContasCriadas++;
    TaxaOperacao = 30 / TotalDeContasCriadas;
}
```

- A classe ArgumentException possui um construtor mais específico. Use-o para oferecer mais informações na mensagem (propriedade Message) da exceção e o nome do parâmetro (propriedade ParamName) com valor inválido:

###### 💬 ParamName: Obtém o nome do parâmetro que causa uma exceção.

```
if (agencia <= 0)
{
    throw new ArgumentException("O argumento agencia deve ser maior que 0.", "agencia");
}

if(numero <= 0)
{
    throw new ArgumentException("O argumento numero deve ser maior que 0.", "numero");
}
```

- Se mudar o nome do argumento, o compilador não irá forçar a atualização do conteúdo das strings usadas para representar o nome dos argumentos. Para isto, use o operador nameof():

###### 💬 nameof: Uma expressão nameof produz o nome de uma variável, tipo ou membro como a constante de cadeia de caracteres.

```
if (agencia <= 0)
{
    throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
}

if(numero <= 0)
{
    throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
}
```

- Teste a exceção ArgumentException em seu programa, com um try/catch para esta exceção, exibindo a propriedade ParamName para verificar o argumento inválido e a Message:

```
try
{
    ContaCorrente conta = new ContaCorrente(0, 0);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.ParamName);
}
```

<br>

## 📚 Criando exceções ricas

- Certifique-se de que o construtor da classe ContaCorrente não está com erro na lógica para o cálculo da TaxaOperacao, calculando-a antes de incrementar a propriedade TotalDeContasCriadas:

```
public ContaCorrente(int agencia, int numero)
{
    // código omitido
    TotalDeContasCriadas++;
    TaxaOperacao = 30 / TotalDeContasCriadas;
}
```

- Na raiz do projeto, crie a classe SaldoInsuficienteException, seguindo a convenção de nomes de exceções no .NET.

- Toda exceção deve derivar do tipo Exception, por isso altere a classe recém-criada para respeitar esta restrição da linguagem e do .NET:

```
public class SaldoInsuficienteException : Exception
{
}
```

- Crie os construtores sem argumentos, e um com uma string mensagem de argumento:

```
public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException()
    {
    }

    public SaldoInsuficienteException(string mensagem)
        : base(mensagem)
    {
    }
}
```

- Guarde o valor de saldo e o valor do saque para guardar mais informações sobre o estado da aplicação no momento de lançamento desta exceção. Crie estas propriedades somente-leitura e o construtor que os popula:

```
public double Saldo { get; }
public double ValorSaque { get; }
public SaldoInsuficienteException(double saldo, double valorSaque)
    : this("Tentativa de saque de " + valorSaque + " com saldo de " + saldo)
{
    Saldo = saldo;
    ValorSaque = valorSaque;
}
```

- Voltando à classe ContaCorrente, use a classe de exceção no método Sacar, para isso altere o tipo de retorno deste método para void e remova o return true. e return false.:

```
public void Sacar(double valor)
{
    if (_saldo < valor)
    {

    }
    _saldo -= valor;
}
```

- Para sinalizar o estado inválido da aplicação, lance uma exceção do tipo SaldoInsuficienteException:

```
public void Sacar(double valor)
{
    if (_saldo < valor)
    {
        throw new SaldoInsuficienteException(_saldo, valor);
    }
    _saldo -= valor;
}
```

- Adicione esta verificação para o caso do valor de saque ser negativo:

```
public void Sacar(double valor)
{
    if (valor < 0)
    {
        throw new ArgumentException("Valor de saque não pode ser negativo", nameof(valor));
    }
    if (_saldo < valor)
    {
        throw new SaldoInsuficienteException(_saldo, valor);
    }
    _saldo -= valor;
}
```

- Use o método Sacar no método Transferir:

```
public void Transferir(double valor, ContaCorrente contaDestino)
{
    if (valor < 0)
    {
        throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
    }

    Sacar(valor);

    contaDestino.Depositar(valor);
}
```

<br>

## 📚 StackTrace e InnerException

- Crie a propriedade ContadorSaquesNaoPermitidos:

```
public int ContadorSaquesNaoPermitidos { get; private set; }
```

- Incremente este contador no método sacar:

```
if (_saldo < valor)
{
    ContadorSaquesNaoPermitidos++;
    throw new SaldoInsuficienteException(Saldo, valor);
}
```

- Faça o mesmo com as transferências, crie a propriedade ContadorTransferenciasNaoPermitidas:

```
public int ContadorTransferenciasNaoPermitidas { get; private set; }
```

- Para incrementar este contador, use o bloco try/catch no método Transferir:

```
try
{
    Sacar(valor);
}
catch(SaldoInsuficienteException ex)
{
    ContadorTransferenciasNaoPermitidas++;
    throw;
}
```

- No catch do método Transferir foi lançada a exceção com a instrução throw, sem uma expressão de exceção, e graças a esta sintaxe, a CLR não altera a propriedade StackTrace da exceção e mantém a informação intacta.

- É possível encapsular uma cadeia de exceções por meio da InnerException, crie a OperacaoFinanceiraException para isto:

```
public class OperacaoFinanceiraException : Exception
{
    public OperacaoFinanceiraException()
    {

    }

    public OperacaoFinanceiraException(string mensagem)
        : base(mensagem)
    {

    }

    public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna)
        : base(mensagem, excecaoInterna)
    {

    }
}
```

- Foram criados 3 construtores de exceção, conforme as convenções da Microsoft: construtor sem argumentos, construtor com mensagem e construtor com mensagem e InnerException.

- Agora é possível usar a exceção:

```
throw new OperacaoFinanceiraException("Operação não realizada.", ex);
```

- No programa, escreva o código para testar esta exceção e verificar que, apesar do StackTrace da exceção lançada nascer no método Transferir, dá para verificar a InnerException e saber de onde a exceção original partiu:

```
try
{
    ContaCorrente conta1 = new ContaCorrente(1234, 123456);
    ContaCorrente conta2 = new ContaCorrente(4321, 654321);

    // conta1.Transferir(10000, conta2);
    conta1.Sacar(10000);
}
catch (OperacaoFinanceiraException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);

    Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

    Console.WriteLine(e.InnerException.Message);
    Console.WriteLine(e.InnerException.StackTrace);
}
```

###### 💬 inner exceptions: Se trata de um objeto que descreve o erro que causou a exceção atual. A propriedade InnerException retorna o mesmo valor passado para o construtor Exception(String, Exception), ou null, se o valor de exceção interno não foi fornecido para o construtor.

<br>

## 📚 Finally e using

###### 💬 finally: Quando ocorre uma exceção, a execução é interrompida e o controle é dado ao manipulador de exceção apropriado. Geralmente, isso significa que linhas de código que você espera que sejam executadas são ignoradas. A limpeza de alguns recursos, assim como o fechamento de um arquivo, precisará ser feita mesmo se uma exceção for gerada. Para fazer isso, você pode usar um bloco finally. Um bloco finally sempre é executado, independentemente de uma exceção ser ou não gerada. Usando um bloco finally, você pode limpar todos os recursos alocados em um bloco try e pode executar código mesmo se uma exceção ocorrer no bloco try. 

###### 💬 using: A instrução using é encerrada ao final do bloco de instruções "using" ou quando a execução sai do bloco indiretamente, por exemplo - quando uma exceção for lançada. Além disso, a instrução "using" permite especificar vários recursos em uma única instrução.

- Crie a classe LeitorDeArquivo com o código abaixo. Certifique-se de adicionar no cabeçalho do arquivo desta classe a diretiva using System.IO; pois serão usadas classes deste namespace:

```
public class LeitorDeArquivo
{
    public string Arquivo { get; }

    public LeitorDeArquivo(string arquivo)
    {
        Arquivo = arquivo;

        // throw new FileNotFoundException();
        Console.WriteLine("Abrindo arquivo: " + arquivo);
    }

    public string LerProximaLinha()
    {
        Console.WriteLine("Lendo linha. . .");

        // throw new IOException();
        return "Linha do arquivo";
    }

    public void Fechar()
    {
        Console.WriteLine("Fechando arquivo.");
    }
}
```

- Escreva o código de teste para esta classe:

```
private static void CarregarContas()
{
    LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");

    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();

    leitor.Fechar();
}
```

- Executando o método CarregarContas(), você encontrará a saída:

> Abrindo arquivo: contas.txt
> Lendo linha. . .
> Lendo linha. . .
> Lendo linha. . .
> Fechando arquivo.

- Para simular problemas em ler o arquivo, lance uma exceção do tipo IOException em LerProximaLinha:

```
public string LerProximaLinha()
{
    Console.WriteLine("Lendo linha. . .");

    throw new IOException();
    return "Linha do arquivo";
}
```

- Com esta alteração feita, será necessário tratar a exceção em CarregarContas, pois é fundamental chamar o método Fechar:

```
LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");
try
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.Fechar();
}
catch(IOException e)
{
    leitor.Fechar();
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
```

- Podemos evitar esta duplicação do código leitor.Fechar(), onde temos um código que deve ser executado ao fim do try e ao fim do catch, quando houver uma exceção, podemos usar o finally:

```
LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");
try
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
catch(IOException e)
{
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
finally
{
    leitor.Fechar();
}
```

- Existem outras exceções em potencial na leitura de arquivos, como quando o arquivo não é encontrado. Vamos simular isto através da alteração no construtor da classe LeitorDeArquivo:

```
public LeitorDeArquivo(string arquivo)
{
    Arquivo = arquivo;

    throw new FileNotFoundException();
    Console.WriteLine("Abrindo arquivo: " + arquivo);
}
```

- Agora será necessário mover a instanciação desta classe para dentro do bloco try:

```
LeitorDeArquivo leitor = null;
try
{
    leitor = new LeitorDeArquivo("contas.txt");
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
catch(IOException e)
{
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
finally
{
    leitor.Fechar();
}
```

- Executar este código pode gerar problemas, pois a tentativa de atribuição na variável leitor irá gerar uma exceção e, no bloco finally uma uma referência nula. Verifique:

```
finally
{
    if(leitor != null)
    {
        leitor.Fechar();
    }
}
```

- Como a única função de nosso try/catch/finally é ter certeza de que o método Fechar do recurso foi invocado, é possível trocar ele pelo bloco using:

```
using(LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
```

- O bloco using é um açúcar sintático para o código escrito no try/finally, mas o bloco using não conhece o método Fechar, apenas o método Dispose da interface IDisposable. Altere a classe LeitorDeArquivo e implemente a interface:

###### 💬 dispose: A implementação do método Dispose destina-se principalmente à liberação de recursos não gerenciados. O Framework chama o método Dispose dos objetos especificados na instrução "using" quando o bloco é encerrado.

###### 💬 IDisposable: Os objetos especificados no bloco using devem implementar a interface IDisposable, e ele fornece um mecanismo para liberar recursos não gerenciados.

```
public class LeitorDeArquivo : IDisposable
{
    public string Arquivo { get; }

    public LeitorDeArquivo(string arquivo)
    {
        Arquivo = arquivo;

        // throw new FileNotFoundException();
        Console.WriteLine("Abrindo arquivo: " + arquivo);
    }

    public string LerProximaLinha()
    {
        Console.WriteLine("Lendo linha. . .");

        // throw new IOException();
        return "Linha do arquivo";
    }

    public void Fechar()
    {
        Console.WriteLine("Fechando arquivo.");
    }
}
```

- Troque o nome do método Fechar para Dispose:

```
public void Dispose()
{
    Console.WriteLine("Fechando arquivo.");
}
```

<br>

## ✍ Referências

Existem diversos exercícios, artigos e vídeos sobre C# por aí, por isso recomendo que vocês deem uma olhada nos cursos incríveis da Alura e no MSDN (Microsoft Developer Network), pois ambos tem muitos conteúdos e explicações para ajudarem a nos desenvolvermos e sanar as nossas dúvidas.

📘 [Alura](https://www.alura.com.br/)
<br>
A maior plataforma brasileira de cursos de tecnologia.

📗 [MSDN](https://docs.microsoft.com/pt-br/?redirectedfrom=MSDN)
<br>
Central de documentação e aprendizado da Microsoft para desenvolvedores

📒 [Documentação do C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
<br>
Saiba como escrever qualquer aplicativo usando a linguagem de programação C# na plataforma .NET.

<br>

## ❓ Dúvidas

Qualquer dúvida, interaja aqui:
  * Faça perguntas
  * Dê sugestões de melhoria para o projeto
  * Compartilhe suas ideias
  * E interaja sobre o assunto

😉Lembre-se de que esta é uma comunidade que construímos juntos 💪.

<br>

## ✉️ Contatos

Se precisar de ajuda, entre em contato comigo 😉

[<img align="left" alt="Gmail" width="80px" src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white"/>](mailto:anabe.valentim@gmail.com)
[<img align="left" alt="LinkedIn" width="100px" src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white"/>](https://www.linkedin.com/in/ana-beatriz-valentim)
[<img align="left" alt="Beacons" width="80px" src="https://github.com/AnaProgramando/AnaProgramando/blob/31ac40741768033915a37ec0f949984bf6aad2d1/beacons_logo.png"/>](https://beacons.page/anaprogramando)

<br>
<br>

## 🙋‍♀️ Desenvolvedora

<div>
  <img align="left" alt="Ana Valentim" width="100px" src="https://avatars.githubusercontent.com/u/31097110?v=4"/>
</div>

<br>
✏️ Feito com ❤️ e C# por <a href="https://github.com/AnaProgramando">Ana Valentim</a>.

💙 Se você gostou desse projeto, dê uma ⭐ e compartilhe!

<br><br>
[<img align="right" alt="Voltar ao topo" width="100px" src="https://img.shields.io/static/v1?label&message=Voltar+ao+topo&color=blueviolet&style=flat&logo"/>](https://github.com/AnaProgramando/CSharp_Excecoes/blob/main/README.md#)


<div>
  <img align="center" alt="Pixel-Art" width="1000px" src="https://github.com/AnaProgramando/CSharp_Declaracao-Caracteres-e-Textos/blob/d77aca3327c866f2508eb049cb245586d8dd0fd3/suicide%20squad.gif"/>
</div>
