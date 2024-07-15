using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPersona.Models;

namespace MVCPersona.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly PersonaDBContext _context;

        public AsignacionesController(PersonaDBContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var personaDBContext = _context.Asignaciones.Include(a => a.Empleado).Include(a => a.Proyecto);
            return View(await personaDBContext.ToListAsync());
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "ID", "ApellidoEmpleado");
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ID", "DescripcionProyecto");
            return View();
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FechaAsignacion,RolAsignacion,EmpleadoId,ProyectoId")] Asignacion asignacion)
        {
            ModelState.Remove("Empleado");
            ModelState.Remove("Proyecto");

            if (ModelState.IsValid)
            {
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "ID", "ApellidoEmpleado", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ID", "DescripcionProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "ID", "ApellidoEmpleado", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ID", "DescripcionProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FechaAsignacion,RolAsignacion,EmpleadoId,ProyectoId")] Asignacion asignacion)
        {
            ModelState.Remove("Empleado");
            ModelState.Remove("Proyecto");
            if (id != asignacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.ID))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "ID", "ApellidoEmpleado", asignacion.EmpleadoId);
            ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ID", "DescripcionProyecto", asignacion.ProyectoId);
            return View(asignacion);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.ID == id);
        }
    }
}
