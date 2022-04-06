using static GerenciamentoDeClientes.Models.Pessoas.ListarViewModel;

namespace GerenciamentoDeClientes.Models.Pessoas
{
    public class EditarViewModel
    {
        public Pessoa Pessoa { get; set; }
        public List<string> Erros { get; set; }
    }
}
