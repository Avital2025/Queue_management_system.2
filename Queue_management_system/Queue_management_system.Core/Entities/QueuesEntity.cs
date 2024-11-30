﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_management_system.Service.Entities
{
    public class QueuesEntity
    {
        //תורים: שעה, יום, תאריך, לקוח, רופאה, 
        public int QueueId { get; set; }
        public int Day { get; set; }
        public int hour { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime date { get; set; }
        public PatientsEntity Patient { get; set; }
        public string DoctorName { get; }
        public string RoomName { get; set; }
    }
}