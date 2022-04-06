using GerenciamentoDeClientes.Data;

namespace GerenciamentoDeClientes.Services
{
    public class Service
    {
        private readonly IRepository repository;

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public CadastrarPessoaResult CadastrarPessoa(Models.Pessoas.CadastrarViewModel formulario)
        {
            bool temErros = false;

            if (string.IsNullOrEmpty(formulario.Nome))
            {
                formulario.NomeError = "Nome é um campo obrigatório";
                temErros = true;
            }

            if (formulario.Cpf.Length != 11)
            {
                formulario.CpfError = "CPF precisa conter 11 dígitos";
                temErros = true;
            }

            if (formulario.DataNascimento > DateTime.Today)
            {
                formulario.DataNascimentoError = "Data de Nascimento não pode ser maior que hoje";
                temErros = true;
            }

            if (temErros)
            {
                return new CadastrarPessoaResult { CadastradoComSucesso = false };
            }

            repository.InserirPessoa(formulario.Nome, formulario.Cpf, formulario.DataNascimento);

            return new CadastrarPessoaResult { CadastradoComSucesso = true };
        }

        public EditarPessoaResult EditarPessoa(Models.Pessoas.ListarViewModel.Pessoa pessoa)
        {
            bool temErros = false;

            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                pessoa.NomeError = "Nome é um campo obrigatório";
                temErros = true;
            }

            if (pessoa.Cpf.Length != 11)
            {
                pessoa.CpfError = "CPF precisa conter 11 dígitos";
                temErros = true;
            }

            if (pessoa.DataNascimento > DateTime.Today)
            {
                pessoa.DataNascimentoError = "Data de Nascimento não pode ser maior que hoje";
                temErros = true;
            }

            if (temErros)
            {
                return new EditarPessoaResult { EditadoComSucesso = false };
            }

            repository.AlterarPessoa(pessoa);

            return new EditarPessoaResult { EditadoComSucesso = true };
        }
    }

    public class CadastrarPessoaResult
    {
        public bool CadastradoComSucesso { get; set; }
    }
    public class EditarPessoaResult
    {
        public bool EditadoComSucesso { get; set; }
    }
}
