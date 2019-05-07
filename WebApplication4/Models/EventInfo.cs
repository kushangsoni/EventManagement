using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class EventInfo
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventLevel { get; set; }
        public string EventName { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; }
        public DateTime EventRegistrationDate { get; set; }
        public string EventCoName { get; set; }
        public string EventCoNo { get; set; }
        public string EventDesc { get; set; }
    }
}
