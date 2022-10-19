using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallStructuresTakeOffs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallStructuresTakeOffs.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly EFCoreDBcontext _context;

        public ProjectsController(EFCoreDBcontext context)
        {
            _context = context;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            return View(_context.Projects.ToList());
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Proj =  _context.Projects
                .FirstOrDefault(m => m.ProjectId == id);
            if (Proj == null)
            {
                return NotFound();
            }

            //ViewBag.ProjId = id;
            return View(Proj);

        }

        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();

            //try
            //{

            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.Projects.Where(w => w.ProjectId == id).FirstOrDefault());
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Update(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = project.ProjectId});
            }
            return View();

            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
