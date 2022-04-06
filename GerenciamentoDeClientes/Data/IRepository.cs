using GerenciamentoDeClientes.Models.Pessoas;

namespace GerenciamentoDeClientes.Data
{
    public interface IRepository
    {
        void InserirPessoa(string nome, string cpf, DateTime dataNascimento);
        void AlterarPessoa(ListarViewModel.Pessoa pessoa);
        IEnumerable<ListarViewModel.Pessoa> ListarPessoas(string name);
        ListarViewModel.Pessoa BuscarPessoa(int id);
        void RemoverPessoa(int id);

    }
}
