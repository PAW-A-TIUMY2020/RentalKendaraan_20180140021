﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_20180140021.Models;

namespace RentalKendaraan_20180140021.Controllers
{
    public class KondisiKendaraansController : Controller
    {
        private readonly RentalKendaraannContext _context;

        public KondisiKendaraansController(RentalKendaraannContext context)
        {
            _context = context;
        }

        // GET: KondisiKendaraans
        public async Task<IActionResult> Index(string kds, string searchString)
        {
            var kdsList = new List<string>();
            var kdsQuery = from d in _context.KondisiKendaraan orderby d.NamaKondisi select d.NamaKondisi;
            kdsList.AddRange(kdsQuery.Distinct());
            ViewBag.kds = new SelectList(kdsList);
            var menu = from m in _context.KondisiKendaraan.Include(k => k.Pengembalian) select m;
            if (!string.IsNullOrEmpty(kds))
            {
                menu = menu.Where(x => x.NamaKondisi == kds);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                menu = menu.Where(s => s.NamaKondisi.Contains(searchString));
            }

            return View(await menu.ToListAsync());

        }

        // GET: KondisiKendaraans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisiKendaraan = await _context.KondisiKendaraan
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisiKendaraan == null)
            {
                return NotFound();
            }

            return View(kondisiKendaraan);
        }

        // GET: KondisiKendaraans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KondisiKendaraans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKondisi,NamaKondisi")] KondisiKendaraan kondisiKendaraan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kondisiKendaraan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kondisiKendaraan);
        }

        // GET: KondisiKendaraans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisiKendaraan = await _context.KondisiKendaraan.FindAsync(id);
            if (kondisiKendaraan == null)
            {
                return NotFound();
            }
            return View(kondisiKendaraan);
        }

        // POST: KondisiKendaraans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKondisi,NamaKondisi")] KondisiKendaraan kondisiKendaraan)
        {
            if (id != kondisiKendaraan.IdKondisi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kondisiKendaraan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KondisiKendaraanExists(kondisiKendaraan.IdKondisi))
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
            return View(kondisiKendaraan);
        }

        // GET: KondisiKendaraans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisiKendaraan = await _context.KondisiKendaraan
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisiKendaraan == null)
            {
                return NotFound();
            }

            return View(kondisiKendaraan);
        }

        // POST: KondisiKendaraans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kondisiKendaraan = await _context.KondisiKendaraan.FindAsync(id);
            _context.KondisiKendaraan.Remove(kondisiKendaraan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KondisiKendaraanExists(int id)
        {
            return _context.KondisiKendaraan.Any(e => e.IdKondisi == id);
        }
    }
}
