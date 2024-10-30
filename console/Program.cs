using System;
using System.Collections.Generic;

namespace LegacySystem
{
    
    class MainSistema
    {
        static void Main(string[] args)
        {
            
            const string EmpresaNome = "Empresa Teste";
            const string DescricaoTransacao = "Compra de Insumo";

            var sistemaCliente = new SistemaCliente();
            sistemaCliente.AddCliente(1, "Joao", "joao@email.com");
            sistemaCliente.AddCliente(2, "Maria", "maria@email.com");

            var sistemaTransacoes = new SistemaTransacoes();
            sistemaTransacoes.AdicionarTransacao(1, 100.50m, "Compra de Produto");
            sistemaTransacoes.AdicionarTransacao(2, 200.00m, "Compra de Serviço");
            sistemaTransacoes.AdicionarTransacao(3, 300.75m, "Compra de Software");

            sistemaCliente.ExibirTodosOsClientes();
            sistemaTransacoes.ExibirTransacoes();

            sistemaCliente.RemoverCliente(1);
            sistemaCliente.ExibirTodosOsClientes();

            sistemaCliente.AtualizarNomeCliente(2, "Maria Silva");

            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Nome da Empresa: {EmpresaNome} | Descrição: {DescricaoTransacao}");
            }

            
            Relatorio relatorio = new Relatorio();
            relatorio.GerarRelatorioCliente(sistemaCliente.GetClientes());
        }
    }

    #region SistemaCliente
    class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void AddCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void ExibirTodosOsClientes()
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (var cliente in _clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}");
            }
        }

        public void AtualizarNomeCliente(int id, string novoNome)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null) cliente.MudarNome(novoNome);
        }

        public void RemoverCliente(int id)
        {
            _clientes.RemoveAll(c => c.Id == id);
        }

        public List<Cliente> GetClientes() => _clientes;
    }
    #endregion

    #region SistemaTransacoes
    class SistemaTransacoes
    {
        private readonly List<Transacao> _transacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            _transacoes.Add(new Transacao(id, valor, descricao));
        }

        public void ExibirTransacoes()
        {
            Console.WriteLine("Lista de Transações:");
            foreach (var transacao in _transacoes)
            {
                Console.WriteLine($"ID: {transacao.Id}, Valor: {transacao.Valor}, Descrição: {transacao.Descricao}");
            }
        }
    }
    #endregion

    #region Modelos
    class Cliente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public void MudarNome(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
        }
    }

    class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public string Descricao { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
        }
    }
    #endregion

    #region Relatorio
    class Relatorio
    {
        public void GerarRelatorioCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Relatório de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} | Email: {cliente.Email}");
            }
        }
    }
    #endregion
}
