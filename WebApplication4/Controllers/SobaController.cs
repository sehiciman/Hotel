﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class SobaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SobaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Soba
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sobe.ToListAsync());
        }

        // GET: Soba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // GET: Soba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nazivSobe,cijenaSobe,brojOsoba")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soba);
        }

        // GET: Soba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe.FindAsync(id);
            if (soba == null)
            {
                return NotFound();
            }
            return View(soba);
        }

        // POST: Soba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nazivSobe,cijenaSobe,brojOsoba")] Soba soba)
        {
            if (id != soba.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SobaExists(soba.ID))
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
            return View(soba);
        }

        // GET: Soba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soba = await _context.Sobe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soba == null)
            {
                return NotFound();
            }

            return View(soba);
        }

        // POST: Soba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soba = await _context.Sobe.FindAsync(id);
            if (soba != null)
            {
                _context.Sobe.Remove(soba);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SobaExists(int id)
        {
            return _context.Sobe.Any(e => e.ID == id);
        }
    }
}
