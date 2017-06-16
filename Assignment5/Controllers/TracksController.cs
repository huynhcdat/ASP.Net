using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TracksController : Controller
    {
        public Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {
            var o = m.TrackGetAll();
            return View(o);
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            var o = new TrackAddForm();
            o.AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title");
            o.MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name");

            return View(o);
            
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(TrackAddForm newItem)
        {

            
            if (!ModelState.IsValid)
            {
                return View(newItem);
                //addedItem = m.TrackAdd(newItem);
            }

            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                //return View(newItem);
                return RedirectToAction("Details", "TrackWithDetail", new { id = addedItem.TrackId });
            }

           
        }
        /*public ActionResult Create(TrackAddForm newItem)
        {
            TrackBase addedItem = null;
            if (ModelState.IsValid)
            {
                addedItem = m.TrackAdd(newItem);
            }
            else
            {
                return View(newItem);
            }
           
            return RedirectToAction("Index"); */
    

    // GET: Tracks/Edit/5
    public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tracks/Edit/5
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

        // GET: Tracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tracks/Delete/5
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
