﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Data;
using WebApplication4.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public IActionResult Index()
        {
            var sobe = _context.Sobe.ToList();
            return View(sobe);
        }


        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije
                .Include(r => r.Soba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create(int sobaId)
        {
            ViewData["SobaId"] = sobaId; 
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SobaId,VrijemeDolaska,VrijemeOdlaska")] Rezervacija rezervacija)
        {
            
            var soba = await _context.Sobe.FindAsync(rezervacija.SobaId);
            if (soba == null)
            {
                ModelState.AddModelError("SobaId", "Izabrana soba ne postoji.");
            }
            else
            {
             
                rezervacija.Soba = soba;
        
               
                ModelState.Remove("Soba");
            }
            
            if (rezervacija.VrijemeOdlaska <= rezervacija.VrijemeDolaska)
            {
                ModelState.AddModelError("VrijemeOdlaska", "Neispravan unos datuma.");
                return View(rezervacija);
            }

           
            if (ModelState.IsValid)
            {
           
                bool roomReserved = _context.Rezervacije
                    .Any(r => r.SobaId == rezervacija.SobaId &&
                              ((rezervacija.VrijemeDolaska >= r.VrijemeDolaska && rezervacija.VrijemeDolaska < r.VrijemeOdlaska) ||
                               (rezervacija.VrijemeOdlaska > r.VrijemeDolaska && rezervacija.VrijemeOdlaska <= r.VrijemeOdlaska) ||
                               (rezervacija.VrijemeDolaska <= r.VrijemeDolaska && rezervacija.VrijemeOdlaska >= r.VrijemeOdlaska)));

                if (roomReserved)
                {
                    ModelState.AddModelError("", "Soba je zauzeta u datom periodu.");
                    return View(rezervacija);
                }

              
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           
            return View(rezervacija);
        }


        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["SobaId"] = new SelectList(_context.Sobe, "ID", "ID", rezervacija.SobaId);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SobaId,VrijemeDolaska,VrijemeOdlaska")] Rezervacija rezervacija)
        {
            if (id != rezervacija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.ID))
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
            ViewData["SobaId"] = new SelectList(_context.Sobe, "ID", "ID", rezervacija.SobaId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacije
                .Include(r => r.Soba)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacije.FindAsync(id);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacije.Any(e => e.ID == id);
        }
    }
}