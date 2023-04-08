using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Excecoes
{
    public class ContaCorrente
    {
        // A TaxaOperacao é uma característica compartilhada por todas as instâncias de ContaCorrente, isto é, trata-se de uma característica da classe, logo também será uma propriedade estática.
        private static int TaxaOperacao;

        // Contador de contas correntes
        public static int TotalContas { get; private set; }

        public Cliente Titular {get; set;}

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        //Bloqueado o acesso aos dados, ou seja, é possível viualizar, mas não editar       
        public int Agencia { get; }
        public int NumConta { get; }

        //Valor padrão do saldo inicial da conta é de 100 e não 0
        private double _saldo = 100;

        // Propriedade Saldo
        public double Saldo
        {
            get
            {
                // O [saldo] é um campo privado que pode ser usado em uma propriedade.
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numConta)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numConta <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numConta));
            }


            // Bloqueado para que não posssa criar uma nova conta sem a agência e número da conta
            // No Program ficará como: ContaCorrente conta = new ContaCorrente(conta.Agencia, conta.NumConta)
            Agencia = agencia;
            NumConta = numConta;

            //Contador do número total de contas criadas
            TotalContas++;

            // A taxa irá diminuir conforme as contas forem criadas, ou seja, quanto mais for incrementando o número de contas (TotalContas++), menor ficará a taxa de operação.
            // Essa exceção da divisão por zero não pode ficar antes da incrementação de criação das contas correntes, se não uma nova conta não pode ser criada.
            TaxaOperacao = 30 / TotalContas;            
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            _saldo -= valor;
        }

        //Void, pois a função não tem retorno
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            // Não precisamos denominar os objetos de exceção, mas é possível fazê-lo seguindo a convenção e utilizando "ex".
            try
            {
                Sacar(valor);
            }
            
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }
            contaDestino.Depositar(valor);
        }
    }
}
