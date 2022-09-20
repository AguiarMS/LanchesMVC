using LanchesMVC.Models;
using LanchesMVC.Repository.Interfaces;
using LanchesMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMVC.Controllers
{
    public class LancheController : Controller
    {
        //Para acessar o bando de dados é necessário injeção de dependencia.
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }

            else
            {
                //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //        .OrderBy(l => l.Nome);
                //}

                //else
                //{
                //    lanches = _lancheRepository.Lanches
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //        .OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                                                   .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }
            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public ViewResult Search (string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            // verificar se tem searchString não é null ou vazio, se for ele atualiza todos os lanches
            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os Lanches";
            }

            else
            {
                // verifica o nome que o user inseriu
                lanches = _lancheRepository.Lanches
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                // Any() mostra se tem qualquer elemento, se tiver um lanche vai atualizar o texto de categoria para lanches
                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
            
        }
    }
}
