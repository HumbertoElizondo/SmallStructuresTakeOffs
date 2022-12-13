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
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();

            return View(await _context.Headwalls.OfType<SD630Headwall>().Where(w => w.HWProjId == id).OrderByDescending(d => d.HeadwallId).ToListAsync());
        }

        // GET: SD630Headwall/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.ProjectName =
                (from r in _context.Headwalls
                 where r.HeadwallId == id
                 select r.Project).FirstOrDefault().ProjectName;

            var hw =
                //(from s in _context.Headwalls.OfType<SD630Headwall>()
                (from s in _context.SD630Headwalls
                 where s.HeadwallId == id
                 select s).FirstOrDefault();
                //.ToList();
                //.FirstOrDefaultAsync(m => m.HeadwallId == id);
            if (hw == null)
            {
                return NotFound();
            }
            ViewBag.HWProjId = hw.HWProjId;
            ViewBag.HWCode = hw.HWcode;
            ViewBag.PourBase = SD630Headwall.D630HWs[hw.ThisHeadwallId].PourBase().ToString("0.00");
            ViewBag.PourWall = SD630Headwall.D630HWs[hw.ThisHeadwallId].PourWall().ToString("0.00");
            ViewBag.FormFab = SD630Headwall.D630HWs[hw.ThisHeadwallId].FormFab().ToString("0.00");
            ViewBag.FormBase = SD630Headwall.D630HWs[hw.ThisHeadwallId].FormBase().ToString("0.00");
            ViewBag.FormWall = SD630Headwall.D630HWs[hw.ThisHeadwallId].FormWall().ToString("0.00");


            var thisStr =
                new ResultsVM
                {
                    
                    ResVMHWcode = hw.HWcode,
                    ResVMHWDescription = hw.HWDescription,
                    ResVMHWStrId = hw.HeadwallId,
                    ResVMId = hw.ThisHeadwallId,
                    ResVMPourBottomCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == hw.ThisHeadwallId).PourBase(),
                    ResVMPourWallCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId ==     hw.ThisHeadwallId).PourWall(),
                    ResVMRebNo4Req = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == hw.ThisHeadwallId).RebNo4Req,
                    ResVMRebNo4Purch = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == hw.ThisHeadwallId).RebNo4Purch,
                    ResVMFormFab =SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId ==     hw.ThisHeadwallId).FormFab(),
                    ResVMFormBase = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == hw.ThisHeadwallId).FormBase(),
                    ResVMFormWall = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == hw.ThisHeadwallId).FormWall(),
                    HWreinforcementsVM = hw.TheReinforcements().ToList()
                    //CBreinforcementsVM = cb.TheReinforcements()
                    //CBreinforcementsVM = (IList<HWreinforcement>)cb.TheReinforcements().ToList()
                    //CBreinforcementsVM = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == cb.ThisHeadwallId).TheReinforcements().ToList()

                };
            return View(thisStr);



            //var sD630Headwall1 = SD630Headwall.D630HWs[sD630Headwall.ThisHeadwallId];
            //return View(sD630Headwall1);



            // This works, but no need to have a Method describing the HW when already hava a 
            // property that does that.
            //var thisOne = sD630Headwall.D630HWs1()[sD630Headwall.ThisHeadwall];
            //return View(thisOne);

        }

        public IActionResult Details1(int id)
        {
            ViewBag.ProjectName =
                (from r in _context.CatchBasins
                 where r.CatchBasinId == id
                 select r.Project).FirstOrDefault().ProjectName;

            var cb = (from r in _context.CBc1510SglT1s
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
                    ResVMRebPurch = cb.CBRebarTakeOfflb(cb.CBHeight) * 1.15m,
                    ResVMRebFandI = cb.CBRebarTakeOfflb(cb.CBHeight),
                    CBreinforcementsVM = cb.TheReinforcements().ToList()

                };
            return View(thisStr);

        }


        // GET: SD630Headwall/Create
        public IActionResult Create(long id)
        {
            var catalogue =
                from c in SD630Headwall.D630HWs
                select c;

            ViewBag.HWList = new SelectList(catalogue, "ThisHeadwallId", "HWDescription");

            ViewBag.ProjectId = id;
            return View();
        }

        // POST: SD630Headwall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HWcode,HWDescription,HWProjId,ThisHeadwallId")] SD630Headwall sD630Headwall)
        {
            if (ModelState.IsValid)
            {
                //sD630Headwall.HWDescription = SD630Headwall.D630HWs[(int)sD630Headwall.ThisHeadwallId].HWDescription;
                _context.Add(sD630Headwall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = sD630Headwall.HWProjId});
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


            ViewBag.HWList = new SelectList(catalogue, "ThisHeadwallId", "HWDescription");

            return View(sD630Headwall);
        }

        // POST: SD630Headwall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("HWCode,HWDescription,HWProjId,ThisHeadwallId")] int id,  SD630Headwall sD630Headwall)
        {
            if (id != sD630Headwall.HeadwallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //sD630Headwall.HWDescription = SD630Headwall.D630HWs[(int)sD630Headwall.ThisHeadwallId].HWDescription;
                    _context.Update(sD630Headwall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SD630HeadwallExists(sD630Headwall.HeadwallId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = sD630Headwall.HWProjId });
            }
            return View(sD630Headwall);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630Headwalls
                .FirstOrDefaultAsync(m => m.HeadwallId == id);
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
            var hw =
                await _context.SD630Headwalls
                .Where(w => w.HeadwallId == id)

                //.Include(i => i.HWreinforcements)
                .FirstOrDefaultAsync();
                //.FindAsync(id);
            var prjId = hw.HWProjId;

            _context.SD630Headwalls.Remove(hw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = prjId });
        }

        private bool SD630HeadwallExists(int id)
        {
            return _context.SD630Headwalls.Any(e => e.HeadwallId == id);
        }

        #region Result Action
        public IActionResult Results(long id)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();

            var HWList =
                from hw in _context.SD630Headwalls.Where(p => p.HWProjId == id).OrderBy(o => o.HWcode)
                select hw;

            List<ResultsVM> results = new();

            foreach (var l in HWList)
            {
                ResultsVM thisStr = new()
                {
                    ResVMHWcode = l.HWcode,
                    ResVMHWDescription = l.HWDescription,
                    ResVMHWStrId = l.HeadwallId,
                    ResVMId = l.ThisHeadwallId,
                    ResVMPourBottomCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).PourBase(),
                    ResVMPourWallCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).PourWall(),
                    ResVMRebNo4Req = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Req,
                    ResVMRebNo4Purch = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Purch,
                    ResVMFormFab =SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormFab(),
                    ResVMFormBase = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormBase(),
                    ResVMFormWall = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormWall()
                };
                results.Add(thisStr);
            }
            return View(results.ToList());
        }
        #endregion
    }
}
