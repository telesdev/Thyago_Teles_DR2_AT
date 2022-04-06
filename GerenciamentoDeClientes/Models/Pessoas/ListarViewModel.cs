namespace GerenciamentoDeClientes.Models.Pessoas
{
    public class ListarViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public class Pessoa
        {
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string NomeError { get; set; }

            public string Cpf { get; set; } = string.Empty;
            public string CpfError { get; set; }

            public DateTime DataNascimento { get; set; }
            public string DataNascimentoError { get; set; }
        }
    }
}
