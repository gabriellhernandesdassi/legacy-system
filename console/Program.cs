using System;
using System.Collections.Generic;
using System.IO;

namespace LegacySystem
{
    class MainSistema
    {
        static void Main(string[] args)
        {
            SistemaCliente sc = new SistemaCliente();
            sc.AddCliente(1, "Joao", "joao@email.com");
            sc.AddCliente(2, "Maria", "maria@email.com");

            SistemaTransacoes st = new SistemaTransacoes();
            st.AdicionarTransacao(1, 100.50m, "Compra de Produto");
            st.AdicionarTransacao(2, 200.00m, "Compra de Serviço");
            st.AdicionarTransacao(3, 300.75m, "Compra de Software");

            sc.ExibirTodosOsClientes();
            st.ExibirTransacoes();

            sc.removerCliente(1);
            sc.ExibirTodosOsClientes();

            sc.AtualizarNomeCliente(2, "Maria Silva");

            string nomeEmpresa = "Empresa Teste";
            string descricaoTransacao = "Compra de Insumo";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Nome da Empresa: " + nomeEmpresa + " Descrição: " + descricaoTransacao);
            }

            Relatorio relatorio = new Relatorio();
            relatorio.GerarRelatorioCliente(sc.clientes);
            relatorio.GerarRelatorioClienteDuplicado(sc.clientes);

            int soma = 0;
            for (int i = 0; i < 10; i++)
            {
                //Soma mais 1
                soma += i;
            }

            Console.WriteLine("Soma total: " + soma);

            int somaDuplicada = 0;
            for (int i = 0; i < 10; i++)
            {
                //Soma Duplicada
                somaDuplicada += i;
            }
        }
    }
}