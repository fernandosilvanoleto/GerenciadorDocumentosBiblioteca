using GerenciadorDocumentos.Models.Entities;
using GerenciarDocumentos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GerenciadorDocumentos.Models.ViewModels;

namespace GerenciadorDocumentos.Controllers
{
    public class AutorsController : Controller
    {
        private readonly DocumentoContext _context;

        public AutorsController(DocumentoContext context)
        {
            _context = context;
        }

        // GET: AutorsController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autors.ToListAsync());
        }

        // GET: AutorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return NotFound("Id menor que zero!");
            }

            Autor autor = _context.Autors.Find(id);
            if (autor == null)
            {
                return NotFound("Autor não encontrado!");
            }

            // CONSULTAR LIVROS DISPONÍVEIS NO BANCO DE DADOS
            // NESSE CASO, SERÃO CONSULTADOS TODOS OS LIVROS
            var livrosDisponiveis = from l in _context.Livros
                                    select new
                                    {
                                        l.Id,
                                        l.Titulo,
                                        l.Descricao,
                                        l.DataPublicacao,
                                        Checked = ((from la in _context.LivroAutors
                                                    where (la.AutorId == id) & (la.LivroId == l.Id)
                                                    select la).Count() > 0)
                                    };

            // MONTAR A PRIMEIRA VIEW MODEL => MONTAR AS INFORMAÇÕES DE AUTORES
            var autoresViewModel = new AutoresViewModel();
            autoresViewModel.Id = autor.Id;
            autoresViewModel.Nome = autor.Nome;
            autoresViewModel.SobreNome = autor.SobreNome;
            autoresViewModel.SiglaNome = autor.SiglaNome;
            autoresViewModel.Brasileiro = autor.Brasileiro;

            // MONTAR A SEGUNDA VIEW MODEL QUE SERÁ OBJETO DE SELEÇÃO NO PROJETO
            var livrosCheckBoxViewModel = new List<LivrosCheckBoxViewModel>();
            foreach (var item in livrosDisponiveis)
            {
                livrosCheckBoxViewModel.Add(
                        new LivrosCheckBoxViewModel
                        {
                            Id = item.Id,
                            Titulo = item.Titulo,
                            Descricao = item.Descricao,
                            DataPublicacao = item.DataPublicacao,
                            Checked = item.Checked
                        }
                    );
            }

            autoresViewModel.Livros = livrosCheckBoxViewModel;

            return View(autoresViewModel);
        }

        // POST: AutorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutoresViewModel autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var livroAutores = _context.LivroAutors;
                    var autorSelecioando = _context.Autors.Find(autor.Id);
                    autorSelecioando.Nome = autor.Nome;
                    autorSelecioando.SobreNome = autor.SobreNome;
                    autorSelecioando.SiglaNome = autor.SiglaNome;
                    autorSelecioando.Brasileiro = autor.Brasileiro;

                    foreach (var livro in autor.Livros)
                    {
                        var livroAutor = livroAutores.FirstOrDefault(la => la.AutorId == autor.Id && la.LivroId == livro.Id);
                        if (livro.Checked)
                        {
                            if (livroAutor == null)
                            {
                                _context.LivroAutors.Add(new LivroAutor() { AutorId = autor.Id, LivroId = livro.Id });
                            }
                        }
                        else
                        {
                            if (livroAutor != null)
                            {
                                _context.LivroAutors.Remove(livroAutor);
                            }
                        }
                        
                    }
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
