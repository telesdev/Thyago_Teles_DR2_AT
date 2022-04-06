namespace GerenciamentoDeClientes.Models.Pessoas
{
    public class CadastrarViewModel
    {
        public string Nome { get; set; } = string.Empty;
        public string NomeError { get; set; }

        public string Cpf { get; set; }
        public string CpfError { get; set; }

        public DateTime DataNascimento { get; set; }
        public string DataNascimentoError { get; set; }
    }
}
