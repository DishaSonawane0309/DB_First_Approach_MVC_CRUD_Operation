using DBFirstApproachCRUD_OprationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstApproachCRUD_OprationMVC.Controllers
{
    public class HomeController : Controller
    {

        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        // GET: Home

        public ActionResult Index()
        {
            var data = db.STUDENTSEFs.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(STUDENTSEF s)
        {
            if(ModelState.IsValid == true)
            {
                db.STUDENTSEFs.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted!!')</script>";

                }
            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.STUDENTSEFs.Where(model => model.ID == id).FirstOrDefault();
            return View(row);
         }
        [HttpPost]
        public ActionResult Edit(STUDENTSEF s)
        {
            if(ModelState.IsValid == true) 
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated!!')</script>";

                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var DeletedRow = db.STUDENTSEFs.Where(model => model.ID == id).FirstOrDefault();
            return View(DeletedRow);

        }
        [HttpPost]
        public ActionResult Delete(STUDENTSEF s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Deleted!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Deleted!!')</script>";

            }
            return View();

        }

        public ActionResult Details(int id)
        {
            var Row = db.STUDENTSEFs.Where(model => model.ID == id).FirstOrDefault();
            return View(Row);

        }

    }
}