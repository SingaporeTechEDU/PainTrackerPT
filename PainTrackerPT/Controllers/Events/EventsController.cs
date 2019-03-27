﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PainTrackerPT.Common.Events;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsRepo _eRepo;

        public EventsController(IEventsRepo eRepo)
        {
            _eRepo = eRepo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            JArray output = await _eRepo.getAllEvents();
            return Json(output);

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
