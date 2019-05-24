using ppedv.ADC2019.Logic;
using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.ADC2019.UI.Web.Controllers
{
    public class AutoController : Controller
    {
        Core core = new Core();
        // GET: Auto
        public ActionResult Index()
        {
            return View(core.UnitOfWork.AutoRepository.GetAll());
        }

        // GET: Auto/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UnitOfWork.AutoRepository.GetById(id));
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            return View(new Auto() { Farbe = "weiss" });
        }

        // POST: Auto/Create
        [HttpPost]
        public ActionResult Create(Auto auto)
        {
            try
            {
                core.UnitOfWork.AutoRepository.Add(auto);
                core.UnitOfWork.SaveAll();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UnitOfWork.AutoRepository.GetById(id));
        }

        // POST: Auto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Auto auto)
        {
            try
            {
                core.UnitOfWork.AutoRepository.Update(auto);
                core.UnitOfWork.SaveAll();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UnitOfWork.AutoRepository.GetById(id));
        }

        // POST: Auto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Auto auto)
        {
            try
            {
                var loaded = core.UnitOfWork.AutoRepository.GetById(id);
                if (loaded != null)
                {
                    core.UnitOfWork.AutoRepository.Delete(loaded);
                    core.UnitOfWork.SaveAll();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
