﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainTrackerPT.Models.Followups
{
    public class FollowupsLog
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
