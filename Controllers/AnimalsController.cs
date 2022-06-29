
using DataLib.Data;
using DataLib.Data.OktayDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace WebAppFinal.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Index()
        {
            OktayDS oktayDS = new OktayDS();
            AnimalsTableAdapter antba = new AnimalsTableAdapter();
            antba.Fill(oktayDS.Animals);
           

            return View(oktayDS);
        }

        // GET: Animals/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            OktayDS ds = new OktayDS();
          //  OktayDS.AnimalsRow dr = ds.Animals = NewRow;

            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int id)
        {
            OktayDS oktayDS = new OktayDS();
            AnimalsTableAdapter antba = new AnimalsTableAdapter();
            antba.Fill(oktayDS.Animals);

            OktayDS.AnimalsRow dr = oktayDS.Animals.Where(x => x.AnimalD == id).FirstOrDefault();
            return View(dr);
        }

        public ActionResult Edit(int id, FormCollection collection)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    OktayDS ds = new OktayDS();
                    AnimalsTableAdapter cntryda = new AnimalsTableAdapter();
                    cntryda.Fill(ds.Animals);

                    OktayDS.AnimalsRow dr = ds.Animals.Where(x => x.AnimalD == id).FirstOrDefault();
                    dr.AnimalName = collection["AnimalName"];
                    dr.AnimalType = collection["AnimalType"];
                    cntryda.Update(dr);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Animals/Edit/5
      
        // GET: Animals/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animals/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
