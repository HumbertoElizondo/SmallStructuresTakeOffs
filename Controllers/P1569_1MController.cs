using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmallStructuresTakeOffs.Models;

namespace SmallStructuresTakeOffs.Controllers
{
    public class P1569_1MController : Controller
    {
        private readonly EFCoreDBcontext _context;

        public P1569_1MController(EFCoreDBcontext context)
        {
            _context = context;
        }

        // GET: C1580CB
        public async Task<IActionResult> Index()
        {
            ViewBag.StructureName = _context.P1569_1Ms.GetType().Name;
            return View(await _context.P1569_1Ms.ToListAsync());
        }

        // GET: C1580CB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c1580CB = await _context.P1569_1Ms
                .FirstOrDefaultAsync(m => m.P1569_1MId == id);
            if (c1580CB == null)
            {
                return NotFound();
            }

            return View(c1580CB);
        }

        // GET: C1580CB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: C1580CB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("P1569_1MCode,P1569_1MDescription,Height")] P1569_1M p1569_1M)
        {
            if (ModelState.IsValid)
            {
                _context.Add(p1569_1M);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(p1569_1M);
        }

        // GET: C1580CB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var p1569_1M = await _context.P1569_1Ms.FindAsync(id);
            if (p1569_1M == null)
            {
                return NotFound();
            }
            return View(p1569_1M);
        }

        // POST: C1580CB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("P1569_1MId,P1569_1MCode,P1569_1MDescription,Height")] P1569_1M p1569_1M)
        {
            if (id != p1569_1M.P1569_1MId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(p1569_1M);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThisStructureExists(p1569_1M.P1569_1MId))
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
            return View(p1569_1M);
        }

        // GET: C1580CB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var p1569_1M = await _context.P1569_1Ms
                .FirstOrDefaultAsync(m => m.P1569_1MId == id);
            if (p1569_1M == null)
            {
                return NotFound();
            }

            return View(p1569_1M);
        }

        // POST: C1580CB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var p1569_1M = await _context.P1569_1Ms.FindAsync(id);
            _context.P1569_1Ms.Remove(p1569_1M);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThisStructureExists(int id)
        {
            return _context.P1569_1Ms.Any(e => e.P1569_1MId == id);
        }

        #region Result Action
        public IActionResult Results()
        {

            var CBList =
                from hw in _context.P1569_1Ms
                select hw;

            List<ResultsVM> results = new();

            foreach (var l in CBList)
            {
                //SD630Headwall thisHDStr = 
                //    from t in SD630Headwall.SeedHWInfo.sD630Headwalls

                //var takeOff =
                //     SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).PourBase();

                ResultsVM thisStr = new()
                {
                    ResVMHWcode = l.P1569_1MCode,
                    ResVMHWDescription = l.P1569_1MDescription,
                    ResVMHWStrId = l.P1569_1MId,
                    ResVMId = l.P1569_1MId,
                    //SqRingRebEa = 0,
                    //SqRingRebL = 0,
                    //VertLsRebEa = 0,
                    //VertLsRebL = 0,
                    ResVMRebNo4Req = l.Reb4FandI,
                    ResVMRebNo4Purch = l.Reb4Purch,
                    ResVMRebNo3Req = l.Reb3FandI,
                    ResVMRebNo3Purch = l.Reb3Purch,
                    ResVMPourWallCY = l.PourBottom(l.Height),
                    ResVMPourBottomCY = l.PourTop(),
                    PourApron = l.PourApron(),
                    PurchConcrete = l.PurchConcrete(l.Height),
                    ResVMFormFab = l.FabForms(l.Height),
                    ResVMFormBase = l.InstBottomForms(l.Height),
                    ResVMFormWall = l.InstTopForms()
                };
                results.Add(thisStr);
            }


            //return View(await _context.SmallStructures.ToListAsync());
            return View(results.ToList());

        }

        #endregion

    }
}
