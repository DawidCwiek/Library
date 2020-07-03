using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Areas.Identity.Data;
using Library.Data;
using Library.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly LibraryContext _context;

        public UserController(LibraryContext context)
        {
            _context = context;
        }


        // GET: UserController
        [Authorize]
        public ActionResult Index()
        {
            var users_borrowing = _context.Borrowing.Include(b => b.ApplicationUser).Include(b => b.Book).Where(b => b.ApplicationUser.UserName == User.Identity.Name);
            if (users_borrowing == null)
                return NotFound();
            return View(users_borrowing.ToList());
        }

        
    }
}
