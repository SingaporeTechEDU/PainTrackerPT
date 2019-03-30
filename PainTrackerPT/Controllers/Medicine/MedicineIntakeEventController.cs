﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Common.Medicine;
using PainTrackerPT.Models.Medicine;

namespace PainTrackerPT.Controllers.Medicine
{
    public class MedicineIntakeEventController : Controller 
    {
        private readonly IMedicineService<MedicineEvent> _medService;
        private MedicineEvent _medEvent;

        public MedicineIntakeEventController(IMedicineService<MedicineEvent> medService)
        {
            _medService = medService;
        }
       
        // GET: MedicineIntakeEvent
        public ActionResult Index(int id)
        {            
            ViewBag.ID = id;            
            return View(_medService.SelectMedEventById(id));            
        }

        // GET: MedicineIntakeEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicineIntakeEvent/Create
        public ActionResult Create(int medID)
        {
            ViewBag.MedID = medID;
            return View();
        }

        // POST: MedicineIntakeEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int medID, [Bind("EventId,Dosage,TimeStamp,MedId")] MedicineEvent medicineEvent)
        {
            _medService.Insert(medicineEvent);
            //return RedirectToAction(nameof(Index)); 
            return RedirectToAction("Index", "MedicineIntakeEvent", new { id = medicineEvent.MedId });            
        }

        // GET: MedicineIntakeEvent/Edit/5
        public ActionResult Edit(int id, int medID)
        {
            ViewBag.medID = medID;
            ViewBag.eventID = id;

            //enze's function
            var eventList = _medService.GetMedicineEventList(medID);
            ViewBag.eventList = eventList;

            return View();
        }

        //POST: MedicineIntakeEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Dosage,TimeStamp, MedId")] MedicineEvent medicineEvent)
        {
            if (id != medicineEvent.EventId)
            {                
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {                   
                    _medService.Update(medicineEvent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index", "MedicineIntakeEvent", new { id = medicineEvent.MedId });
            }
            return View(medicineEvent);
        }

        // GET: MedicineEvent/Delete/5
        public async Task<IActionResult> Delete(int? id, int medID)
        {
            if (id == null)
            {
                return NotFound();
            }

            _medEvent = _medService.SelectById(id);

            if (_medEvent == null)
            {
                return NotFound();
            }

            return View(_medEvent);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind("EventId,Dosage,TimeStamp, MedId")] MedicineEvent medicineEvent)
            //int id, int medID)
        {
            _medService.Delete(medicineEvent.EventId);
            return RedirectToAction("Index", "MedicineIntakeEvent", new { id = medicineEvent.MedId });
        }

        // GET: Medicines/Event/
        public ActionResult Event(int id)
        {
            return null;
        }
                
    }
}