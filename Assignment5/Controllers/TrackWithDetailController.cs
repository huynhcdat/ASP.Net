﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TrackWithDetailController : Controller
    {
        public Manager m = new Manager();
        // GET: TrackWithDetail
        public ActionResult Index()
        {
            var o = m.TrackGetAllWithDetail();
            return View(o);
        }

        // GET: TrackWithDetail/Details/5
        public ActionResult Details(int? id)
        {
            var o = m.TrackGetByIdWithDetail(id.GetValueOrDefault());
             if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }

        // GET: TrackWithDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackWithDetail/Create
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

        // GET: TrackWithDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrackWithDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackWithDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrackWithDetail/Delete/5
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