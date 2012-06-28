using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    public class Priority
    {
        public static Priority UNKNOWN_PRIORITY = new Priority() 
        {
            name = "Unknown",
            id = "UNKNOWN",
            description = "Unknown priority",
            statusColor = string.Empty,
            iconUrl = string.Empty,
            self = string.Empty
        };

        public string self { get; set; }
        public string statusColor { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
}
