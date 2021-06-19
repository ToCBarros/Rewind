using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rewind.Data;
using Rewind.Models;

namespace Rewind.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly RewindDB _context;

        public ComentariosController(RewindDB context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var rewindDB = _context.Comentarios.Include(c => c.Serie).Include(c => c.Utilizador);
            return View(await rewindDB.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var comentarios = await _context.Comentarios
                .Include(c => c.Serie)
                .Include(c => c.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }

            return View(comentarios);
        }
        /*
        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["SeriesID"] = new SelectList(_context.Series, "ID", "Estado");
            ViewData["UtilizadoresID"] = new SelectList(_context.Utilizadores, "ID", "Email");
            return View();
        }
        */
        // GET: Comentarios/Create
        
        //é recebido o id da série
        public IActionResult Create(int id)
        {
            
            //Verifica-se qual é a serie a qual o id pertence
            var serie = _context.Series.FirstOrDefault(s => s.ID == id);
            //são enviados o titulo e o id da série, para que possa ser preenchido automáticamente e caso se queira voltar a trás, vá para a série
            ViewData["id"] = id;
            ViewData["UtilizadoresID"] = new SelectList(_context.Utilizadores, "ID", "Email");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UtilizadoresID,SeriesID,Estado,Data,Comentario,Estrelas")] Comentarios comentarios)
        {
            comentarios.ID = 0;
            comentarios.Estado = "visivel";
            comentarios.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(comentarios);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Index", "Series");
                }
                catch (Exception ex)
                {

                }
            }
            ViewData["SeriesID"] = new SelectList(_context.Series, "ID", "Estado", comentarios.SeriesID);
            ViewData["UtilizadoresID"] = new SelectList(_context.Utilizadores, "ID", "Email", comentarios.UtilizadoresID);
            return View(comentarios);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var comentarios = await _context.Comentarios.FindAsync(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["SeriesID"] = new SelectList(_context.Series, "ID", "Estado", comentarios.SeriesID);
            ViewData["UtilizadoresID"] = new SelectList(_context.Utilizadores, "ID", "Email", comentarios.UtilizadoresID);
            HttpContext.Session.SetInt32("IDComentariosEdicao", comentarios.ID);
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UtilizadoresID,SeriesID,Estado,Data,Comentario,Estrelas")] Comentarios comentarios)
        {
            if (id != comentarios.ID)
            {
                return RedirectToAction("Index");
            }
            var IDComentariosEdit = HttpContext.Session.GetInt32("IDComentariosEdicao");

            if (IDComentariosEdit == null || IDComentariosEdit != comentarios.ID)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentariosExists(comentarios.ID))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeriesID"] = new SelectList(_context.Series, "ID", "Estado", comentarios.SeriesID);
            ViewData["UtilizadoresID"] = new SelectList(_context.Utilizadores, "ID", "Email", comentarios.UtilizadoresID);
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var comentarios = await _context.Comentarios
                .Include(c => c.Serie)
                .Include(c => c.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetInt32("IDComentariosDelete", comentarios.ID);
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarios = await _context.Comentarios.FindAsync(id);
            var IDComentariosDel = HttpContext.Session.GetInt32("IDComentariosDelete");

            if (IDComentariosDel == null || IDComentariosDel != comentarios.ID)
            {
                return RedirectToAction("Index");
            }
            _context.Comentarios.Remove(comentarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentariosExists(int id)
        {
            return _context.Comentarios.Any(e => e.ID == id);
        }
    }
}
