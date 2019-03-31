﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainTrackerPT.Data.Followups.Repository;
using PainTrackerPT.Data.Followups.Services;
using PainTrackerPT.Models;
using PainTrackerPT.Models.Followups;

namespace PainTrackerPT.Controllers.Followups
{
    public class AdvicesController : Controller
    {
        private readonly IBaseService<Advice> _adviceService;

        public AdvicesController(IBaseService<Advice> baseService)
        {
            _adviceService = baseService;
        }

        // GET: Advices
        public async Task<IActionResult> Index()
        {
            return View(await _adviceService.SelectAll());
        }

        // GET: Advices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _adviceService.Select(id.Value);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // GET: Advices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerId,Description,DateGenerated,Id")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                advice.Id = Guid.NewGuid();
                _adviceService.Create(advice);
                return RedirectToAction(nameof(Index));
            }
            return View(advice);
        }

        // GET: Advices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _adviceService.Select(id.Value);
            if (advice == null)
            {
                return NotFound();
            }
            return View(advice);
        }

        // POST: Advices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AnswerId,Description,DateGenerated,Id")] Advice advice)
        {
            if (id != advice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adviceService.Update(advice);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdviceExists(advice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(advice);
        }

        // GET: Advices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _adviceService.Select(id.Value);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // POST: Advices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var advice = await _adviceService.Select(id);
            _adviceService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdviceExists(Guid id)
        {
            return _adviceService.Exists(id);
        }
    }
}
