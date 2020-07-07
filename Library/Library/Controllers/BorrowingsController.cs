using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Library.Controllers
{
    [Authorize(Roles = "admin")]
    public class BorrowingsController : Controller
    {
        private readonly LibraryContext _context;

        public BorrowingsController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Statistic()
        {
            DateTime[] last7Days = Enumerable.Range(0, 7)
                                    .Select(i => DateTime.Now.Date.AddDays(-i))
                                    .ToArray();


            Dictionary<string, int> data = new Dictionary<string, int>();

            foreach (var i in last7Days) {
                data.Add(i.ToShortDateString(), _context.Borrowing.Where(b => b.StartDate == i).Count());
            }

            return Json(data);
        }

        // GET: Borrowings
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.Borrowing.Include(b => b.ApplicationUser).Include(b => b.Book);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Borrowings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // GET: Borrowings/Create
        public IActionResult Create()
        {
            Borrowing borrowing = new Borrowing();
            borrowing.StartDate = DateTime.Now;
            borrowing.MaxDate = DateTime.Now.AddDays(30);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");

            var AllBooks = _context.Book.Include(b => b.Borrowing);

            List<Book> books = new List<Book>();

            foreach(Book b in AllBooks) {
                if (b.Borrowing.Any())
                {
                    if (b.Borrowing.Last().EndDate != null)
                    {
                        books.Add(b);
                    }
                }
                else {
                    books.Add(b);
                }
               
            }

         
            ViewData["BookId"] = new SelectList(books, "Id", "Title");
            return View(borrowing);
        }

        // POST: Borrowings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,ApplicationUserId,StartDate,MaxDate,EndDate, Description")] Borrowing borrowing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title");
            return View(borrowing);
        }

        // GET: Borrowings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FindAsync(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "UserName", borrowing.ApplicationUserId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", borrowing.BookId);
            return View(borrowing);
        }

        // POST: Borrowings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,ApplicationUserId,StartDate,MaxDate,EndDate, Description")] Borrowing borrowing)
        {
            if (id != borrowing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingExists(borrowing.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "UserName", borrowing.ApplicationUserId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", borrowing.BookId);
            return View(borrowing);
        }

        // GET: Borrowings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowing == null)
            {
                return NotFound();
            }

            return View(borrowing);
        }

        // POST: Borrowings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowing = await _context.Borrowing.FindAsync(id);
            _context.Borrowing.Remove(borrowing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.Id == id);
        }
    }
}
