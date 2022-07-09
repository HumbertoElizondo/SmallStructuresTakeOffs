// Used at the very end with Avoiding magic strings
//#define no_suffix
//#if no_suffix
#region snippet1
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallStructuresTakeOffs.Controllers;
using SmallStructuresTakeOffs.Models;

namespace SmallStructuresTakeOffs.ViewComponents
{
    public class WastesList : ViewComponent
    {
        private readonly EFCoreDBcontext db;
        public WastesList(EFCoreDBcontext context)
        {
            db = context;
        }

        //private readonly ToDoContext db;
        //public PriorityList(ToDoContext context)
        //{
        //    db = context;
        //}

        //public IViewComponentResult Invoke()
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = RebarRequestsController.MyMethods.purchases.ToList();
            var items = await GetItemsAsync();
            return View(items);
        }

        private Task<List<RebarWasting>> GetItemsAsync()
        {
            return db.RebarWastings.ToListAsync();
        }


        //private ActionResult<List<RebarToPurchase>> GetItems()
        //private Task<List<RebarToPurchase>> GetItemsAsync()
        //private Task<List<RebarToPurchase>> GetItemsAsync()
        //{
        //return db.ToList();

        //return db.ToDo.Where(x => x.IsDone == isDone &&
        //                     x.Priority <= maxPriority).ToListAsync();
        //}
    }
}
#endregion
//#endif