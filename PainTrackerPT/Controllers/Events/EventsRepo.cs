﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TrackingEvents.Models;
using PainTrackerPT.Models;
using PainTrackerPT.Common.Events;

namespace PainTrackerPT.Controllers.Events
{
    public class EventsRepo: IEventsRepo
    {
        internal PainTrackerPTContext db = new PainTrackerPTContext();
        //private readonly PainTrackerPTContext _context;

        //public EventsRepo(PainTrackerPTContext context)
        //{
        //    _context = context;
        //}

        public async Task<JArray> getAllEvents()
        {
            JArray output = new JArray();

            foreach (var e in await db.Events.ToListAsync())
            {
                JObject evt = new JObject
                {
                    { "title", e.eventTitle },
                    { "start", e.eventStartDate },
                    { "end", e.eventEndDate },
                    { "desc", e.eventDesc }
                };

                output.Add(evt);
            }

            return output;
        }

    }
}
