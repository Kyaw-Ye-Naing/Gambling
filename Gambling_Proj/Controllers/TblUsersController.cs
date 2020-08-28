using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gambling_Proj.Models;
using Microsoft.AspNetCore.Http;

namespace Gambling_Proj.Controllers
{
    public class TblUsersController : Controller
    {
        //private readonly Gambling_AppContext _context;
        Gambling_AppContext db = new Gambling_AppContext();

      //  public TblUsersController(Gambling_AppContext context)
        //{
       //     _context = context;
       // }

        public IActionResult Index()
        {

            var user = HttpContext.Session.GetString("Username");
            ViewBag.UserName = user;
            return View(db.TblUser.ToList());
        }
        // GET: TblUsers
      //  public async Task<IActionResult> Index()
      //  {
       //     return View(await db.TblUser.ToListAsync());
      //  }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
      //  public IActionResult CreatePartial()
      //  {
      //      return View();
      //  }

        // POST: TblUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Lock,RoleId,CreatedBy,CreatedDate")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblUser);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUser.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("UserId,Username,Password,Lock,RoleId,CreatedBy,CreatedDate")] TblUser tblUser)
        {
            if (id != tblUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblUser);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.UserId))
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
            return View(tblUser);
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: TblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tblUser = await db.TblUser.FindAsync(id);
            db.TblUser.Remove(tblUser);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(decimal id)
        {
            return db.TblUser.Any(e => e.UserId == id);
        }
    }
}
