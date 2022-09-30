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
    public class CBp1572Controller : Controller
    {
        private readonly EFCoreDBcontext _context;

        public CBp1572Controller(EFCoreDBcontext context)
        {
            _context = context;
        }

        // GET: C1580CB
        public async Task<IActionResult> Index(long id)
        {

            ViewBag.ProjectId = id;
            return View(await _context.CatchBasins.OfType<CBp1572>().Where(i => i.ProjId == id).ToListAsync());
        }

        // GET: C1580CB/Details/5
        public IActionResult Details(int id)
        {
            var cb = (from r in _context.CBp1572s
                     where r.CatchBasinId == id
                     select r).FirstOrDefault();


            var thisStr =
            new ResultsVM
            {
                HeightCB = cb.CBHeight,
                ResVMHWcode = cb.CBCode,
                ResVMHWDescription = cb.Description,
                ResVMHWStrId = cb.CatchBasinId,
                ResVMId = cb.CatchBasinId,
                ResVMPourWallCY = cb.PourTop(),
                ResVMPourBottomCY = cb.PourBottom(cb.CBHeight),
                PourApron = cb.PourApron(),
                PurchConcrete = cb.PurchConcrete(cb.CBHeight),
                ResVMFormFab = cb.FabForms(cb.CBHeight),
                ResVMFormBase = cb.InstBottomForms(cb.CBHeight),
                ResVMFormWall = cb.InstTopForms(),
                ResVMRebPurch = cb.CBRebarTakeOfflb(cb.CBHeight)* 1.15m,
                ResVMRebFandI = cb.CBRebarTakeOfflb(cb.CBHeight),
                CBreinforcementsVM = cb.theReinforcements().ToList()

            };
            return View(thisStr);

        }


        // GET: CatchBasin/Create
        public IActionResult Create(long id)
        {
            ViewBag.ProjectId = id;
            return View();
        }
        
        // POST: C1580CB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,CBHeight,CBCode,ProjId,CBp1570Typ1")] CBp1572 cb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = cb.ProjId});
            }
            return View(cb);
        }

        // GET: C1580CB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cb = await _context.CBp1572s.FindAsync(id);
            if (cb == null)
            {
                return NotFound();
            }
            return View(cb);
        }

        // POST: C1580CB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("CatchBasinId,Description,CBHeight,CBCode,CBRebFandI,CBRebPurch,ProjId,CBp1570Typ1")] CBp1572 cb)
        {
            if (id != cb.CatchBasinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //cb.CBreinforcements = null;
                    _context.Update(cb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CBExists(cb.CatchBasinId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = cb.ProjId});
            }
            
            return View(cb);
        }

        // GET: C1580CB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cb = await _context.CBp1572s
                .FirstOrDefaultAsync(m => m.CatchBasinId == id);
            if (cb == null)
            {
                return NotFound();
            }

            return View(cb);
        }

        // POST: C1580CB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cb = await _context.CBp1572s.FindAsync(id);
            var prjId = cb.ProjId;
            _context.CBp1572s.Remove(cb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = prjId });
        }

        private bool CBExists(int id)
        {
            return _context.CBp1572s.Any(e => e.CatchBasinId == id);
        }

        #region Result Action
        public IActionResult Results(long id)
        {
            ViewBag.ProjectId = id;

            var CBList =
                from hw in _context.CBp1572s.Where(p => p.ProjId == id)
                select hw;

            List<ResultsVM> results = new();

            foreach (var l in CBList)
            {
                ResultsVM thisStr = new()
                {
                    HeightCB = l.CBHeight,
                    ResVMHWcode = l.CBCode,
                    ResVMHWDescription = l.Description,
                    ResVMHWStrId = l.CatchBasinId,
                    ResVMId = l.CatchBasinId,
                    SqRingRebEa = l.RebSqRingEa(l.CBHeight),
                    SqRingRebL = l.CBSqRingL,
                    VertLsRebEa = l.CBVertBars,
                    VertLsRebL = l.RebVertLength(l.CBHeight),
                    ResVMRebNo4Req = l.CBRebFandI,
                    ResVMRebNo3Purch = l.CBRebPurch,
                    ResVMPourWallCY = l.PourTop(),
                    ResVMPourBottomCY = l.PourBottom(l.CBHeight),
                    PourApron = l.PourApron(),
                    PurchConcrete = l.PurchConcrete(l.CBHeight),
                    ResVMFormFab = l.FabForms(l.CBHeight),
                    ResVMFormBase = l.InstBottomForms(l.CBHeight),
                    ResVMFormWall = l.InstTopForms(),
                    ResVMRebNo4Purch = l.CBRebPurch,
                    ResVMRebPurch = (decimal)l.CBreinforcements.Where(w => w.CBId == l.CatchBasinId).Select(s => s.TotalWeight).Sum() * 1.15m,
                    ResVMRebFandI = (decimal)l.CBreinforcements.Where(w => w.CBId == l.CatchBasinId).Select(s => s.TotalWeight).Sum(),


                    //ResVMRebPurch = 
                    //    (l.CBSqRingL * l.RebSqRingEa(l.CBHeight) + (decimal)l.CBVertBars * l.RebVertLength(l.CBHeight) + l.RebNo4StrthEa() * l.RebNo4Strth()) * .668m * 1.15m + l.RebNo3Length() * l.RebNo3Qty() * .376m *1.15m,
                    //ResVMRebFandI = 
                    //    (l.CBSqRingL * l.RebSqRingEa(l.CBHeight) + (decimal)l.CBVertBars * l.RebVertLength(l.CBHeight) + l.RebNo4StrthEa() * l.RebNo4Strth()) * .668m + l.RebNo3Length() * l.RebNo3Qty() * .376m,
                    RebNo3Length = l.RebNo3Length(),
                    RebNo3LengthEa = (int)l.RebNo3Qty(),
                    RebNo4StgthEa = (int)l.RebNo4StrthEa(),
                    RebNo4StgthL = l.RebNo4Strth()
                    
                };
                results.Add(thisStr);
            }
            return View(results.ToList());
        }
        #endregion
    }
}
