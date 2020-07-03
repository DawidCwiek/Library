using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    [Authorize(Roles = "admin")]
    public class InvoicesController : Controller
    {
        private readonly LibraryContext _context;

        public InvoicesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invoice.ToListAsync());
        }


        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 2097152)
                    {
                        Invoice inv = new Invoice();

                        inv.FileName = Path.GetFileName(file.FileName);
                        inv.File = memoryStream.ToArray();

                        _context.Add(inv);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        
        public async Task<FileContentResult> DownloadFile(int? id)
        {
            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            return File(invoice.File, "application/octet-stream");
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
