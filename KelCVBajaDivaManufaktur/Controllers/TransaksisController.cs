﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KelCVBajaDivaManufaktur.Data;
using KelCVBajaDivaManufaktur.Models;

namespace KelCVBajaDivaManufaktur.Controllers
{
    public class TransaksisController : Controller
    {
        private readonly KelCVBajaDivaManufakturContext _context;

        public TransaksisController(KelCVBajaDivaManufakturContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // Ambil data total penjualan per bulan dari database
            var dataPenjualan = _context.Transaksi
                .GroupBy(t => new { t.TanggalBeli.Year, t.TanggalBeli.Month })
                .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, TotalPenjualan = g.Sum(t => t.TotalBayar) })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            // Kirim data ke view
            return View(dataPenjualan);
        }


        // GET: Transaksis
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Transaksi == null)
            {
                return Problem("Entity set 'KelCVBajaDivaManufakturContext.Transaksi'  is null.");
            }

            var transaksis = from m in _context.Transaksi
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                transaksis = transaksis.Where(s => s.NamaPelanggan!.Contains(searchString));
            }

            return View(await transaksis.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transaksi == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaPelanggan,NamaMenu,TanggalBeli,Jumlah,TotalBayar,CaraBayar")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transaksi == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaPelanggan,NamaMenu,TanggalBeli,Jumlah,TotalBayar,CaraBayar")] Transaksi transaksi)
        {
            if (id != transaksi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.Id))
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
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transaksi == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transaksi == null)
            {
                return Problem("Entity set 'KelCVBajaDivaManufakturContext.Transaksi'  is null.");
            }
            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi != null)
            {
                _context.Transaksi.Remove(transaksi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
          return (_context.Transaksi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
