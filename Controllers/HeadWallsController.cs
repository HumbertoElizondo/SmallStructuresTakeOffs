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
                    //ResVMHWcode = l.HWcode,
                    //ResVMHWDescription = l.HWDescription,
                    //ResVMHWStrId = l.HeadwallId,
                    //ResVMId = l.ThisHeadwallId,
                    ////ResVMPourBottomCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).PourBase(),
                    //ResVMPourBottomCY = l.PourBase(),

                    ////ResVMPourWallCY = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).PourWall(),
                    //ResVMPourWallCY = l.PourWall(),

                    ////ResVMRebNo4Req = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Req,
                    //ResVMRebNo4Req = l.ThisHeadwallId,

                    ////ResVMRebNo4Purch = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).RebNo4Purch,
                    //ResVMRebNo4Purch = l.ThisHeadwallId,

                    ////ResVMFormFab =SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormFab(),
                    //ResVMFormFab =l.FormFab(),

                    ////ResVMFormBase = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormBase(),
                    //ResVMFormBase = l.FormBase(),

                    ////ResVMFormWall = SD630Headwall.D630HWs.FirstOrDefault(f => f.ThisHeadwallId == l.ThisHeadwallId).FormWall()
                    //ResVMFormWall = l.FormWall()

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




                    //HeightCB = l.CBHeight,
                    //ResVMHWcode = l.CBCode,
                    //ResVMHWDescription = l.Description,
                    //ResVMHWStrId = l.CatchBasinId,
                    //ResVMId = l.CatchBasinId,
                    //ResVMRebNo4Req = l.CBRebFandI,
                    //ResVMRebNo3Purch = l.CBRebPurch,
                    //ResVMPourWallCY = l.PourTop(),
                    //ResVMPourBottomCY = l.PourBottom(l.CBHeight),
                    //PourApron = l.PourApron(),
                    //PurchConcrete = l.PurchConcrete(l.CBHeight),
                    //ResVMFormFab = l.FabForms(l.CBHeight),
                    //ResVMFormBase = l.InstBottomForms(l.CBHeight),
                    //ResVMFormWall = l.InstTopForms(),
                    //ResVMRebNo4Purch = l.CBRebPurch,
                    //ResVMRebPurch = (decimal)l.CBreinforcements.Where(w => w.CBId == l.CatchBasinId).Select(s => s.TotalWeight).Sum() * 1.15m,
                    //ResVMRebFandI = (decimal)l.CBreinforcements.Where(w => w.CBId == l.CatchBasinId).Select(s => s.TotalWeight).Sum()
                };
                results.Add(thisStr);
            }
            return View(results.ToList());
        }

        #endregion


    }
}
