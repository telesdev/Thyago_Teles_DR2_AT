using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeClientes.Models.Pessoas;
using System.Data;
using Dapper;
using GerenciamentoDeClientes.Data;
using GerenciamentoDeClientes.Services;

namespace GerenciamentoDeClientes.Controllers
{
    public class PessoasController : Controller
    {
        IDbConnection conexao;
        readonly IRepository repository;
        readonly Service service;

        public PessoasController(IDbConnection conexao, IRepository repository, Service service)
        {
            this.conexao = conexao;
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewModel = new CadastrarViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarViewModel formulario)
        {
            var resultado = service.CadastrarPessoa(formulario);

            if (resultado.CadastradoComSucesso == true)
            {
                return RedirectToAction("listar");
            }

            return View(formulario);
        }

        [HttpGet]
        public ActionResult Listar(string nome)
        {
            ViewBag.Titulo = "Lista de Pessoas";

            var resultado = repository.ListarPessoas(nome);

            return View(resultado);
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            repository.RemoverPessoa(id);
            
            return RedirectToAction("listar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var pessoa = repository.BuscarPessoa(id);

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(ListarViewModel.Pessoa pessoa)
        {
            var resultado = service.EditarPessoa(pessoa);

            if (resultado.EditadoComSucesso == true)
            {
                return RedirectToAction("listar");
            }

            return RedirectToAction("listar");
        }
    }
}
