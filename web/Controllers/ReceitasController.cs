using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.IO;
using MasterChef.Persistence.Contexts;
using MasterChef.Domain.Models;

namespace MasterChef.Web.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly DataContext _context;

        public ReceitasController(DataContext context)
        {
            _context = context;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            var masterChefContext = _context.Receitas.Include(r => r.Categoria);
            return View(await masterChefContext.ToListAsync());
           
        }

        // GET: Receitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Receita = await _context.Receitas
                .Include(r => r.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Receita == null)
            {
                return NotFound();
            }

            return View(Receita);
        }

        // GET: Receitas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaReceitaId"] = new SelectList(_context.Categorias, "Id", "Descricao");
            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaReceitaId, Descricao, Id, Titulo, Foto, Tempo, Rendimento, Ingredientes, Preparo")] Receita Receita)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                var fileName = string.Empty;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var Foto = new byte[file.Length];

                        file.OpenReadStream().Read(Foto, 0, (int)file.Length);
                        Receita.Foto = Foto;
                    }
                }

                _context.Add(Receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaReceitaId"] = new SelectList(_context.Categorias, "Id", "Descricao", Receita.CategoriaReceitaId);
            return View(Receita);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Receita = await _context.Receitas.FindAsync(id);
            if (Receita == null)
            {
                return NotFound();
            }
            ViewData["CategoriaReceitaId"] = new SelectList(_context.Categorias, "Id", "Descricao", Receita.CategoriaReceitaId);
            return View(Receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaReceitaId, Descricao, Id, Titulo, Foto, Tempo, Rendimento, Ingredientes, Preparo")] Receita Receita)
        {
            if (id != Receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    var fileName = string.Empty;

                    if (files != null &&
                        files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                var Foto = new byte[file.Length];

                                file.OpenReadStream().Read(Foto, 0, (int)file.Length);
                                Receita.Foto = Foto;
                            }
                        }
                    }
                    else
                    {
                        Receita.Foto = null;
                    }

                    _context.Update(Receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(Receita.Id))
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
            ViewData["CategoriaReceitaId"] = new SelectList(_context.Categorias, "Id", "Descricao", Receita.CategoriaReceitaId);
            return View(Receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Receita = await _context.Receitas
                .Include(r => r.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Receita == null)
            {
                return NotFound();
            }

            return View(Receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Receita = await _context.Receitas.FindAsync(id);
            _context.Receitas.Remove(Receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            return _context.Receitas.Any(e => e.Id == id);
        }
    }
}
