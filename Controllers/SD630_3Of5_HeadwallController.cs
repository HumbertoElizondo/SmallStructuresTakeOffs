using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmallStructuresTakeOffs.Models;
using SmallStructuresTakeOffs.Enums;

namespace SmallStructuresTakeOffs.Controllers
{
    public class SD630_3Of5_HeadwallController : Controller
    {
        #region Context Setup
        private readonly EFCoreDBcontext _context;

        public SD630_3Of5_HeadwallController(EFCoreDBcontext context)
        {
            _context = context;
        }

        #endregion

        #region Index Method
        // GET: SD630Headwall
        public async Task<IActionResult> Index(long id)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();

            return View(await _context.Headwalls.OfType<SD630_3Of5_Headwall>().Where(w => w.HWProjId == id).OrderByDescending(d => d.HeadwallId).ToListAsync());
        }

        #endregion

        #region Details Method
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
                //(from s in _context.Headwalls.OfType<SD630_4Of5_Headwall>()
                (from s in _context.SD630_3Of5_Headwalls
                 where s.HeadwallId == id
                 select s).FirstOrDefault();

            if (hw == null)
            {
                return NotFound();
            }
            ViewBag.HWProjId = hw.HWProjId;
            ViewBag.HWCode = hw.HWcode;
            ViewBag.PourBase = hw.GetTheHW().PourBase().ToString("0.00");
            ViewBag.PourWall = hw.GetTheHW().PourWall().ToString("0.00");
            ViewBag.FormFab = hw.GetTheHW().FormFab().ToString("0.00");
            ViewBag.FormBase = hw.GetTheHW().FormBase().ToString("0.00");
            ViewBag.FormWall = hw.GetTheHW().FormWall().ToString("0.00");

            var thisStr =
                new ResultsVM
                {
                    
                    ResVMHWcode = hw.HWcode,
                    ResVMHWDescription = hw.HWDescription,
                    ResVMHWStrId = hw.ThisHeadwallId,
                    ResVMId = hw.HeadwallId,
                    ResVMPourBottomCY = hw.GetTheHW().PourBase(),
                    ResVMPourWallCY = hw.GetTheHW().PourWall(),
                    ResVMFormFab = hw.GetTheHW().FormFab(),
                    ResVMFormBase = hw.GetTheHW().FormBase(),
                    ResVMFormWall = hw.GetTheHW().FormWall(),
                    HWreinforcementsVM = hw.TheReinforcements().ToList()
                };
            ViewBag.ResultVM = thisStr;

            return View(hw);
        }

        #endregion

        #region Create Method
        public IActionResult Create(long id)
        {
            var catalogue =
                from c in SD630_3Of5_Headwall.D630HWs
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
        public async Task<IActionResult> Create([Bind("HWcode,HWDescription,HWProjId,PipeDiameters,Slopes,Skews,FlowSides,PipeNo")] SD630_3Of5_Headwall sD630_3Of5_Headwall)
        {
            if (ModelState.IsValid)
            {
                sD630_3Of5_Headwall.ThisHeadwallId = sD630_3Of5_Headwall.GetTheHW().ThisHeadwallId;
                _context.Add(sD630_3Of5_Headwall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = sD630_3Of5_Headwall.HWProjId});
            }
            return View(sD630_3Of5_Headwall);
        }

        #endregion

        #region Edit Method
        // GET: SD630Headwall/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630_3Of5_Headwalls.FirstOrDefaultAsync(f => f.HeadwallId == id);
            if (sD630Headwall == null)
            {
                return NotFound();
            }

            var catalogue =
                from c in SD630_3Of5_Headwall.D630HWs
                select c;


            ViewBag.HWList = new SelectList(catalogue, "ThisHeadwallId", "HWDescription");

            return View(sD630Headwall);
        }

        // POST: SD630Headwall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("HeadwallId,HWCode,HWDescription,HWProjId,ThisHeadwallId")] int id, SD630_3Of5_Headwall sD630_3Of5_Headwall)
        {
            if (id != sD630_3Of5_Headwall.HeadwallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //sD630_4Of5_Headwall.HWDescription = SD630_4Of5_Headwall.D630HWs[(int)sD630_4Of5_Headwall.ThisHeadwallId].HWDescription;
                    sD630_3Of5_Headwall.ThisHeadwallId = sD630_3Of5_Headwall.GetTheHW().ThisHeadwallId;

                    _context.Update(sD630_3Of5_Headwall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SD630HeadwallExists(sD630_3Of5_Headwall.HeadwallId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = sD630_3Of5_Headwall.HWProjId });
            }
            return View(sD630_3Of5_Headwall);
        }

        #endregion

        #region Delete Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sD630Headwall = await _context.SD630_3Of5_Headwalls
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
            var hw = await _context.SD630_3Of5_Headwalls.FindAsync(id);
            var prjId = hw.HWProjId;

            _context.SD630_3Of5_Headwalls.Remove(hw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = prjId });
        }

        #endregion

        #region Exists Method
        private bool SD630HeadwallExists(int id)
        {
            return _context.SD630_3Of5_Headwalls.Any(e => e.HeadwallId == id);
        }

        #endregion

        #region Result Action
        public IActionResult Results(long id)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();

            var HWList =
                from hw in _context.SD630_3Of5_Headwalls.Where(p => p.HWProjId == id).OrderBy(o => o.HWcode)
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
                    ResVMPourBottomCY = l.GetTheHW().PourBase(),
                    ResVMPourWallCY = SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).PourWall(),
                    ResVMRebNo4Req = SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Req,
                    ResVMRebNo4Purch = SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Purch,
                    ResVMFormFab =SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormFab(),
                    ResVMFormBase = SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormBase(),
                    ResVMFormWall = SD630_3Of5_Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormWall()
                };
                results.Add(thisStr);
            }
            return View(results.ToList());
        }
        #endregion
    }
}
