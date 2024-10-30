using System;
using System.Collections.Generic;

namespace LegacySystem
{
    #region Cliente
    // Classe Cliente
    class Cliente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Cadastro { get; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cadastro = DateTime.Now;
        }

        public void MudarNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                Nome = nome;
            }
        }

        public void AtualizarEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
            {
                Email = email;
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Id: {Id} | Nome: {Nome} | Email: {Email} | Cadastro: {Cadastro}");
        }
    }
    #endregion

    #region Transacoes
    // Classe Transações
    class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public DateTime Data { get; }
        public string Descricao { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Data = DateTime.Now;
            Descricao = descricao;
        }

        public void ExibirTransacao()
        {
            Console.WriteLine($"Id: {Id} | Valor: {Valor} | Descrição: {Descricao} | Data: {Data}");
        }
    }
    #endregion

    #region SistemaTransacoes
    // Classe Sistema Transações
    class SistemaTransacoes
    {
        private readonly List<Transacao> _listaDeTransacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            var transacao = new Transacao(id, valor, descricao);
            _listaDeTransacoes.Add(transacao);
        }

        public void ExibirTransacoes()
        {
            Console.WriteLine("Lista de Transações:");
            foreach (var transacao in _listaDeTransacoes)
            {
                transacao.ExibirTransacao();
            }
        }
    }
    #endregion

    #region SistemaCliente
    // Classe Sistema Cliente
    class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void AddCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            _clientes.RemoveAll(c => c.Id == id);
        }

        public void ExibirTodosOsClientes()
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (var cliente in _clientes)
            {
                cliente.ExibirDados();
            }
        }

        public void AtualizarNomeCliente(int id, string nome)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            cliente?.MudarNome(nome);
        }
    }
    #endregion

    #region Relatorio
    // Classe Relatório
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
