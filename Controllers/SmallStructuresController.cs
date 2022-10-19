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
    public class SmallStructuresController : Controller
    {
        #region Controller Setup
        private readonly EFCoreDBcontext _context;

        public SmallStructuresController(EFCoreDBcontext context)
        {
            _context = context;
        }

        #endregion

        #region Index Action
        // GET: SmallStructures
        public async Task<IActionResult> Index()
        {
            return View(await _context.SmallStructures.ToListAsync());
        }

        #endregion

        #region Details Action
        // GET: SmallStructures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallStructure = await _context.SmallStructures
                .FirstOrDefaultAsync(m => m.SmStId == id);
            if (smallStructure == null)
            {
                return NotFound();
            }

            return View(smallStructure);
        }

        #endregion

        #region Create Action
        // GET: SmallStructures/Create
        public IActionResult Create()
        {
            //SD630Headwall sD630Headwall = new SD630Headwall();
            //List<SeedHWInfo> HWCatalogue = SD630Headwall.theseSD630Headwalls;
            //var catalogue =
            //    from c in HWCatalogue
            //    select c;

            var catalogue =
                from c in SD630Headwall.D630HWs
                select c;


            ViewBag.HWList = new SelectList(catalogue, "SD630Id", "SD630Description");
                


            return View();
        }

        // POST: SmallStructures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SmStId,ThisStructure,HWcode")] SmallStructure smallStructure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smallStructure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smallStructure);
        }

        #endregion

        #region Edit Action
        // GET: SmallStructures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallStructure = await _context.SmallStructures.FindAsync(id);
            if (smallStructure == null)
            {
                return NotFound();
            }

            //SD630Headwall sD630Headwall = new SD630Headwall();
            //List<SD630Headwall> HWCatalogue = SD630Headwall.TheseSD630Headwalls;

            //var catalogue =
            //    from c in HWCatalogue
            //    select c;

            var catalogue =
                from c in SD630Headwall.D630HWs
                select c;


            ViewBag.HWList = new SelectList(catalogue, "SD630Id", "SD630Description");


            return View(smallStructure);
        }

        // POST: SmallStructures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SmStId,ThisStructure,HWcode")] SmallStructure smallStructure)
        {
            if (id != smallStructure.SmStId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smallStructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmallStructureExists(smallStructure.SmStId))
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
            return View(smallStructure);
        }

        #endregion

        #region Delete Action
        // GET: SmallStructures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallStructure = await _context.SmallStructures
                .FirstOrDefaultAsync(m => m.SmStId == id);
            if (smallStructure == null)
            {
                return NotFound();
            }

            return View(smallStructure);
        }

        // POST: SmallStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smallStructure = await _context.SmallStructures.FindAsync(id);
            _context.SmallStructures.Remove(smallStructure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region SmallStructure Exist Method
        private bool SmallStructureExists(int id)
        {
            return _context.SmallStructures.Any(e => e.SmStId == id);
        }

        #endregion

        #region Result Action
        public IActionResult Results()
        {
            //var catalogue =
            //    from c in SeedHWInfo.sD630Headwalls
            //    select c;

            //ViewBag.HWList = new SelectList(catalogue, "SD630Id", "SD630Description");

            var HWList =
                from hw in _context.SmallStructures
                select hw;

            List<ResultsVM> results = new();

            foreach(var l in HWList)
            {
                //SD630Headwall thisHDStr = 
                //    from t in SD630Headwall.SeedHWInfo.sD630Headwalls

                var takeOff =
                     SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).PourBase();

                     ResultsVM thisStr = new()
                     {
                         ResVMHWcode = l.HWcode,
                         ResVMHWDescription = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).SD630Description,
                         ResVMHWStrId = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).SD630HeadwallId,
                         ResVMId = l.SmStId,
                         ResVMPourBottomCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).PourBase(),
                         ResVMPourWallCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).PourWall(),
                         ResVMRebNo4Req = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).RebNo4Req,
                         ResVMRebNo3Purch = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).RebNo4Purch,
                         ResVMFormFab = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).FormFab(),
                         ResVMFormBase = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).FormBase(),
                         ResVMFormWall = SD630Headwall.D630HWs.FirstOrDefault(f => f.SD630HeadwallId == l.ThisStructure).FormWall()
                     };
                results.Add(thisStr);
            }


            //return View(await _context.SmallStructures.ToListAsync());
            return View( results.ToList());

        }

        #endregion
    }
}
