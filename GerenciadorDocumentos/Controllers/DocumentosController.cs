using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciarDocumentos.Models;
using GerenciadorDocumentos.Models.Entities;

namespace GerenciadorDocumentos.Controllers
{
    public class DocumentosController : Controller
    {
        private readonly DocumentoContext _context;

        public DocumentosController(DocumentoContext context)
        {
            _context = context;
        }

        // GET: Documentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentos.ToListAsync());
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            ViewBag.RevisaoSelect = GetRevisao();
            return View();
        }

        // POST: Documentos/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Titulo,Revisao,DataPlanejada,Valor")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documento);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            ViewBag.RevisaoSelect = GetRevisao();
            return View(documento);
        }

        // POST: Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Titulo,Revisao,DataPlanejada,Valor")] Documento documento)
        {
            if (id != documento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(documento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(documento);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoExists(int id)
        {
            return _context.Documentos.Any(e => e.Id == id);
        }

        private IList<SelectListItem> GetRevisao()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem {Text = "0", Value = "0"},
                    new SelectListItem {Text = "A", Value = "A"},
                    new SelectListItem {Text = "B", Value = "B"},
                    new SelectListItem {Text = "C", Value = "C"},
                    new SelectListItem {Text = "D", Value = "D"},
                    new SelectListItem {Text = "E", Value = "E"},
                    new SelectListItem {Text = "F", Value = "F"},
                    new SelectListItem {Text = "G", Value = "G"},
                };
        }
    }
}
