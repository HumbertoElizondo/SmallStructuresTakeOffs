using Microsoft.AspNetCore.Mvc;
using SmallStructuresTakeOffs.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SmallStructuresTakeOffs.Controllers
{
    public class HeadWallsController : Controller
    {
        private readonly EFCoreDBcontext _context;

        public HeadWallsController(EFCoreDBcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(long id, string searchString)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();

            var headwalls = from m in _context.Headwalls
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                headwalls = headwalls.Where(s => s.HWcode.Contains(searchString));
            }

            return View(await headwalls.Where(i => i.HWProjId == id).OrderBy(o => o.HWcode).ToListAsync());
        }
        #region Result Action
        public IActionResult Results(long id)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(w => w.ProjectId == id).Select(s => s.ProjectName).FirstOrDefault();


            var CBList =
                from hw in _context.Headwalls.Where(p => p.HWProjId == id).OrderBy(o => o.HWcode)
                select hw;

            List<ResultsVM> results = new();

            foreach (var l in CBList)
            {
                ResultsVM thisStr = new()
                {
                    ResVMHWcode = l.HWcode,
                    ResVMHWDescription = l.HWDescription,
                    ResVMHWStrId = l.HeadwallId,
                    ResVMId = l.GetTheHW().ThisHeadwallId,
                    ResVMPourBottomCY = l.GetTheHW().PourBase(),
                    ResVMPourWallCY = l.GetTheHW().PourWall(),
                    ResVMRebNo4Req = l.GetTheHW().RebNo4Req,
                    ResVMRebNo4Purch = l.GetTheHW().RebNo4Purch,
                    ResVMFormFab = l.GetTheHW().FormFab(),
                    ResVMFormBase = l.GetTheHW().FormBase(),
                    ResVMFormWall = l.GetTheHW().FormWall()
                };
                results.Add(thisStr);
            }
            return View(results.ToList());
        }
        #endregion
    }
}
