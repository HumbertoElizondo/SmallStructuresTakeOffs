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
    public class SD630HeadwallController : Controller
    {
        private readonly EFCoreDBcontext _context;

        public SD630HeadwallController(EFCoreDBcontext context)
        {
            _context = context;
        }

        // GET: SD630Headwall
        public async Task<IActionResult> Index(long id)
        {

            //if (_context.SD630Headwalls.Any(a => a.ProjId == id))

            ////return View(await _context.SD630Headwalls.ToListAsync());
            //{ return View(await _context.SD630Headwalls.ToListAsync()); }

            //else
            //{
            //    return RedirectToAction( "Create");
            //}
            ViewBag.ProjectId = id;
            return View(await _context.SD630Headwalls.Where(w => w.ProjId == id).ToListAsync());

        }

        // GET: SD630Headwall/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630Headwalls
                .FirstOrDefaultAsync(m => m.SD630HeadwallId == id);
            if (sD630Headwall == null)
            {
                return NotFound();
            }

            return View(sD630Headwall);
        }

        // GET: SD630Headwall/Create
        public IActionResult Create(long id)
        {
            var catalogue =
                from c in SD630Headwall.D630HWs
                select c;

            ViewBag.ProjectId = id;


            ViewBag.HWList = new SelectList(catalogue, "SD630HeadwallId", "SD630Description");


            return View();
        }

        // POST: SD630Headwall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HWCode,ThisHeadwall,ProjId")] SD630Headwall sD630Headwall)
        {
            if (ModelState.IsValid)
            {
                sD630Headwall.SD630Description = SD630Headwall.D630HWs[(int)sD630Headwall.ThisHeadwall].SD630Description;
                _context.Add(sD630Headwall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = sD630Headwall.ProjId});
            }
            return View(sD630Headwall);
        }

        // GET: SD630Headwall/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630Headwalls.FindAsync(id);
            if (sD630Headwall == null)
            {
                return NotFound();
            }

            var catalogue =
                from c in SD630Headwall.D630HWs
                select c;


            ViewBag.HWList = new SelectList(catalogue, "SD630HeadwallId", "SD630Description");

            return View(sD630Headwall);
        }

        // POST: SD630Headwall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HWCode,SD630HeadwallId,SD630Description,ProjId,ThisHeadwall")] SD630Headwall sD630Headwall)
        {
            if (id != sD630Headwall.SD630HeadwallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sD630Headwall.SD630Description = SD630Headwall.D630HWs[(int)sD630Headwall.ThisHeadwall].SD630Description;
                    _context.Update(sD630Headwall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SD630HeadwallExists(sD630Headwall.SD630HeadwallId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = sD630Headwall.ProjId });
            }
            return View(sD630Headwall);
        }

        // GET: SD630Headwall/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630Headwalls
                .FirstOrDefaultAsync(m => m.SD630HeadwallId == id);
            if (sD630Headwall == null)
            {
                return NotFound();
            }

            return View(sD630Headwall);
        }

        // POST: SD630Headwall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sD630Headwall = await _context.SD630Headwalls.FindAsync(id);
            _context.SD630Headwalls.Remove(sD630Headwall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SD630HeadwallExists(int id)
        {
            return _context.SD630Headwalls.Any(e => e.SD630HeadwallId == id);
        }

        #region Result Action
        public IActionResult Results()
        {
            //var catalogue =
            //    from c in SeedHWInfo.sD630Headwalls
            //    select c;

            //ViewBag.HWList = new SelectList(catalogue, "SD630Id", "SD630Description");

            var HWList =
                from hw in _context.SD630Headwalls.ToList()
                select hw;

            List<ResultsVM> results = new();

            foreach (var l in HWList)
            {
                //SD630Headwall thisHDStr = 
                //    from t in SD630Headwall.SeedHWInfo.sD630Headwalls

                var takeOff =
                     SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).PourBase();

                ResultsVM thisStr = new()
                {
                    ResVMHWcode = l.HWCode,
                    ResVMHWDescription = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).SD630Description,
                    ResVMHWStrId = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).SD630HeadwallId,
                    ResVMId = l.SD630HeadwallId,
                    ResVMPourBottomCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).PourBase(),
                    ResVMPourWallCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).PourWall(),
                    ResVMRebNo4Req = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).RebNo4Req,
                    ResVMRebNo3Purch = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).RebNo4Purch,
                    ResVMFormFab = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).FormFab(),
                    ResVMFormBase = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).FormBase(),
                    ResVMFormWall = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisHeadwall).FormWall()
                };
                results.Add(thisStr);
            }


            //return View(await _context.SmallStructures.ToListAsync());
            return View(results.ToList());

        }

        #endregion

    }
}
