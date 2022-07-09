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
    public class PurchasesList : ViewComponent
    {
        //private readonly ToDoContext db;
        //public PriorityList(ToDoContext context)
        //{
        //    db = context;
        //}

        public IViewComponentResult Invoke()
        //public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = RebarRequestsController.MyMethods.purchases.ToList();
            //var items = await GetItemsAsync();
            return View(items);
        }

        //private Task<List<RebarToPurchase>> GetItemsAsync()
        //{
            //return db.ToDo.Where(x => x.IsDone == isDone &&
            //                     x.Priority <= maxPriority).ToListAsync();
        //}
    }
}
#endregion
//#endif