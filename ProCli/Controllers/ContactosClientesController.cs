#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProCli.Data;
using ProCli.Models;

namespace ProCli.Controllers
{
    public class ContactosClientesController : Controller
    {
        private readonly ProCliContext _context;

        public ContactosClientesController(ProCliContext context)
        {
            _context = context;
        }

        // GET: ContactosClientes
        public async Task<IActionResult> Index(int? id)
        {
            var proCliContext = _context.ContactosCliente.Include(c => c.Cliente).Where(c => c.ClienteId == id);
            //var ContactosClientes = _context.ContactosCliente.Where(c => c.ClienteId == id).ToList;
            ViewBag.Id = id;
            return View(await proCliContext.ToListAsync());
        }

        // GET: ContactosClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactosCliente = await _context.ContactosCliente
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactosCliente == null)
            {
                return NotFound();
            }

            return View(contactosCliente);
        }

        // GET: ContactosClientes/Create
        public IActionResult Create(int? id)
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre", id);
            ViewBag.Id = id;
            return View();
        }

        // POST: ContactosClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Nombre,Telefono,Email")] ContactosCliente contactosCliente)
        {
            if (ModelState.IsValid==false)
            {
                _context.Add(contactosCliente);
                await _context.SaveChangesAsync();
                ViewBag.Id = contactosCliente.ClienteId;
                return RedirectToAction(nameof(Index), null, new { id = ViewBag.Id });
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", contactosCliente.ClienteId);
            return View(contactosCliente);
        }

        // GET: ContactosClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             if (id == null)
            {
                return NotFound();
            }

            var contactosCliente = await _context.ContactosCliente.FindAsync(id);
            if (contactosCliente == null)
            {
                return NotFound();
            }
            ViewBag.Id = contactosCliente.ClienteId;
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre", contactosCliente.ClienteId);
            return View(contactosCliente);
        }

        // POST: ContactosClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,Nombre,Telefono,Email")] ContactosCliente contactosCliente)
        {
            if (id != contactosCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid==false)
            {
                try
                {
                    _context.Update(contactosCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactosClienteExists(contactosCliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Id = contactosCliente.ClienteId;
                return RedirectToAction(nameof(Index), null, new { id = ViewBag.Id });
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", contactosCliente.ClienteId);
            ViewBag.Id = contactosCliente.ClienteId;
            return View(contactosCliente);
        }

        // GET: ContactosClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactosCliente = await _context.ContactosCliente
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactosCliente == null)
            {
                return NotFound();
            }

            ViewBag.Id = contactosCliente.ClienteId;
            return View(contactosCliente);
        }

        // POST: ContactosClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactosCliente = await _context.ContactosCliente.FindAsync(id);
            _context.ContactosCliente.Remove(contactosCliente);
            await _context.SaveChangesAsync();
            ViewBag.Id = contactosCliente.ClienteId;
            return (RedirectToAction(nameof(Index), null, new { id = ViewBag.Id }));
        }

        private bool ContactosClienteExists(int id)
        {
            return _context.ContactosCliente.Any(e => e.Id == id);
        }
    }
}
