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
    public class C1580CBController : Controller
    {
        private readonly EFCoreDBcontext _context;

        public C1580CBController(EFCoreDBcontext context)
        {
            _context = context;
        }

        // GET: C1580CB
        public async Task<IActionResult> Index()
        {
            return View(await _context.C1580CBs.ToListAsync());
        }

        // GET: C1580CB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c1580CB = await _context.C1580CBs
                .FirstOrDefaultAsync(m => m.C1580CBId == id);
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
        public async Task<IActionResult> Create([Bind("C1580CBId,C1580CBDescription,C1580CBHeight,C1580CBCode")] C1580CB c1580CB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c1580CB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(c1580CB);
        }

        // GET: C1580CB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c1580CB = await _context.C1580CBs.FindAsync(id);
            if (c1580CB == null)
            {
                return NotFound();
            }
            return View(c1580CB);
        }

        // POST: C1580CB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("C1580CBId,C1580CBDescription,C1580CBHeight,C1580CBCode,C1580Reb4FandI,C1580Reb4Purch")] C1580CB c1580CB)
        {
            if (id != c1580CB.C1580CBId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c1580CB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!C1580CBExists(c1580CB.C1580CBId))
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
            return View(c1580CB);
        }

        // GET: C1580CB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c1580CB = await _context.C1580CBs
                .FirstOrDefaultAsync(m => m.C1580CBId == id);
            if (c1580CB == null)
            {
                return NotFound();
            }

            return View(c1580CB);
        }

        // POST: C1580CB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var c1580CB = await _context.C1580CBs.FindAsync(id);
            _context.C1580CBs.Remove(c1580CB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool C1580CBExists(int id)
        {
            return _context.C1580CBs.Any(e => e.C1580CBId == id);
        }

        #region Result Action
        public IActionResult Results()
        {

            var CBList =
                from hw in _context.C1580CBs
                select hw;

            List<ResultsVM> results = new List<ResultsVM>();

            foreach (var l in CBList)
            {
                //SD630Headwall thisHDStr = 
                //    from t in SD630Headwall.SeedHWInfo.sD630Headwalls

                //var takeOff =
                //     SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).PourBase();

                ResultsVM thisStr = new ResultsVM()
                {
                    ResVMHWcode = l.C1580CBCode,
                    ResVMHWDescription = l.C1580CBDescription,
                    ResVMHWStrId = l.C1580CBId,
                    ResVMId = l.C1580CBId,
                    ResVMPourBottomCY = l.PourBottom(l.C1580CBHeight),
                    SqRingRebEa = l.RebSqRingEa(l.C1580CBHeight),
                    SqRingRebL = l.C1580SqRingL,
                    VertLsRebEa = l.C1580VertLsEa,
                    VertLsRebL = l.RebVertLength(l.C1580CBHeight),
                    //ResVMPourWallCY = SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).PourWall(),
                    ResVMRebNo4Req = l.C1580Reb4FandI,
                    ResVMRebNo4Purch = l.C1580Reb4Purch
                    //ResVMFormFab = SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).FormFab(),
                    //ResVMFormBase = SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).FormBase(),
                    //ResVMFormWall = SD630Headwall.SeedHWInfo.sD630Headwalls.FirstOrDefault(f => f.SD630Id == l.ThisStructure).FormWall()
                };
                results.Add(thisStr);
            }


            //return View(await _context.SmallStructures.ToListAsync());
            return View(results.ToList());

        }

        #endregion

    }
}
