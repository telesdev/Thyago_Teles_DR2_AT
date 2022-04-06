using GerenciamentoDeClientes.Models.Pessoas;
using System.Data;
using Dapper;

namespace GerenciamentoDeClientes.Data
{
    public class Repository : IRepository
    {
        private IDbConnection conexao { get; }

        public Repository(IDbConnection conexao)
        {
            this.conexao = conexao;
        }

        public void InserirPessoa(string nome, string cpf, DateTime dataNascimento)
        {
            conexao.Open();

            string sql = @"INSERT INTO Pessoa (nome, cpf, dataNascimento) " +
                "values (@nome, @cpf, @dataNascimento)";

            conexao.Execute(sql, new
            {
                nome = nome,
                cpf = cpf,
                dataNascimento = dataNascimento,
            });

            conexao.Close();
        }

        public IEnumerable<ListarViewModel.Pessoa> ListarPessoas(string nome)
        {
            conexao.Open();
            string sql = "SELECT * FROM Pessoa";

            if(nome != null)
            {
                sql += " WHERE nome LIKE '%@nome%'";
            }

            var resultado = conexao.Query<ListarViewModel.Pessoa>(sql, new { nome = nome });
            conexao.Close();

            return resultado;
        }

        public ListarViewModel.Pessoa BuscarPessoa(int id)
        {
            conexao.Open();
            var pessoa = conexao.QuerySingle<ListarViewModel.Pessoa>("SELECT * FROM Pessoa WHERE id = @id", new { id = id });
            conexao.Close();

            return pessoa;
        }

        public void RemoverPessoa(int id)
        {
            conexao.Open();
            conexao.Execute("DELETE FROM Pessoa WHERE id = @id", new { id = id });
            conexao.Close();
        }

        public void AlterarPessoa(ListarViewModel.Pessoa pessoa)
        {
            conexao.Open();

            string sql = @"
                UPDATE Pessoa SET 
                    nome = @nome, 
                    cpf = @cpf, 
                    dataNascimento = @dataNascimento 
                WHERE id = @id";

            conexao.Execute(sql, new
            {
                id = pessoa.Id,
                nome = pessoa.Nome,
                cpf = pessoa.Cpf,
                dataNascimento = pessoa.DataNascimento,
            });

            conexao.Close();
        }
    }
}
