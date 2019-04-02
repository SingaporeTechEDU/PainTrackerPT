﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Common.Followups;
using PainTrackerPT.Common.Medicine;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Followups;
using PainTrackerPT.Models.Medicine;
using System.Web;

namespace PainTrackerPT.Controllers.Medicine
{
    public class MedicineLogController : Controller
    {
        private readonly IMedicineService _medService;   
        //private readonly IMediaService _mediaService;
        private MedicineLog _medLog;
        //private Media _media;

        public MedicineLogController(IMedicineService medService)//, IHostingEnvironment IHostingEnvironment)//, IMediaService mediaService)
        {
            //_mediaService = mediaService;
            _medService = medService;
            //_environment = IHostingEnvironment;
        }
              
        
        // GET: MedicineLogs/Details/5
        public ActionResult Details(DateTime dt)
        {            
            return View(_medService.GetLogAt(dt));
            
        }

        //GET: MedicineLogs
        public IActionResult Index()
        {
            return View(_medService.SelectAll());           
        }

        // GET: MedicineLogs/Create
        public IActionResult Create()
        {
            var medNameList = _medService.SelectAll();
            ViewData["medNameList"] = medNameList;
            return View();
        }

        // POST: MedicineLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Type,Img")] MedicineLog medicineLog)
        {
            if (ModelState.IsValid)
            {
                medicineLog.MedGuid = Guid.NewGuid();               
                //createImage(medicineLog.Img);
                _medService.Insert(medicineLog);

                //using API from FollowUp team
                //_media.AnswerId = medicineLog.medGuid;
                //_media.MediaUrl = medicineLog.Img;
                //_mediaService.Create(_media);

                return RedirectToAction(nameof(Index));
            }
            return View(medicineLog);
        }

        // GET: Medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _medLog = _medService.SelectById(id);

            if (_medLog == null)
            {
                return NotFound();
            }
            return View(_medLog);
        }

        //POST: MedicineLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Type")] MedicineLog medicineLog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _medService.Update(medicineLog);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicineLog);
        }

        // GET: MedicineLogs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _medLog = _medService.SelectById(id);

            if (_medLog == null)
            {
                return NotFound();
            }

            return View(_medLog);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _medService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Medicines/Event/
        public ActionResult Event(int id)
        {
            return null;
        }
     
    }
}
