﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Doctors;

namespace PainTrackerPT.Controllers.Doctors
{
    public class DoctorsController : Controller
    {
        private readonly PainTrackerPTContext _context;

        public DoctorsController(PainTrackerPTContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public ActionResult DoctorAppointment_Dashboard()
        {

            return View();
        }

        // GET: Doctors
        public async Task<IActionResult> PatientAccount_Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> PatientAccount_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
        // GET: Doctors/PatientAccount_Create
        public ActionResult PatientAccount_Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientAccount_Create([Bind("PatientId,Username,Pin,Firstname,Lastname,EmailAdd")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PatientAccount_Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> PatientAccount_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientAccount_Edit(int id, [Bind("PatientId,Username,Pin,Firstname,Lastname,EmailAdd")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PatientAccount_Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> PatientAccount_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientAccount_DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PatientAccount_Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }


        // appointment 

        // GET: Appointments
        public async Task<IActionResult> DoctorAppointment_Index()
        {
            
            var appointment = await _context.Appointments.Where(u => u.ApptLocation == null).ToListAsync();

            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> DoctorAppointment_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorAppointment_Edit(int id, [Bind("AppointmentId,PatientID,DoctorID,Message,AppDate,ProposedDate,ApptLocation,docCfm,patCfm,pdAttach,miAttach,status")] Appointment appointment)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DoctorAppointment_Index));
            }
            return View(appointment);
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }


        // GET: Doctors
        public async Task<IActionResult> DoctorAppointmentAccepted_Index()
        {
            var id = 666;
            var appointment = await _context.Appointments.Where(u => u.DoctorID == id).ToListAsync();

            return View(appointment);
        }

        public async Task<ActionResult> DoctorAppointmentAccepted_Edit()
        {
            var doctorId = 666;

            var appointment = await _context.Appointments.Where(u => u.DoctorID == doctorId).ToListAsync();

            foreach (var item in appointment)
            {
                if (item.DoctorID == 666)
                {
                    if (item.status == "AwaitingPatCfm")
                    {
                        return View("DoctorAppointmentAcceptedAwaitingPatCfm_Edit", item);
                    }
                    else if(item.status == "AwaitingDocCfm")
                    {
                        return View("DoctorAppointmentAcceptedAwaitingDocCfm_Edit", item);
                    }
                    else if (item.status == "ApptCfm")
                    {
                        return View("DoctorAppointmentAcceptedApptCfm_Edit", item);
                    }
                }
            }
            ViewBag.Error = "appointmentError";
            return View("PatientAppointment_Dashboard");
        }

        // GET: Appointments/Edit/5
        public ActionResult DoctorAppointmentAcceptedAwaitingDocCfm_Edit(Appointment appointment)
        {
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult DoctorAppointmentAcceptedAwaitingPatCfm_Edit(Appointment appointment)
        {
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult DoctorAppointmentAcceptedApptCfm_Edit(Appointment appointment)
        {
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<ActionResult> DoctorAppointmentAcceptedProposeNewDate_Edit()
        {
            var doctorId = 666;

            var appointment = await _context.Appointments.Where(u => u.DoctorID == doctorId).ToListAsync();
            foreach (var item in appointment)
            {
                if (item.DoctorID == 666)
                {
                    return View(item);
                }
            }
            return NotFound();
        }


    }
}