using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient.JiraModel
{
    public class Status
    {
        // TODO: Move off the heap?
        public static Status UNKNOWN_STATUS = new Status()
        {
            id = "UNKNOWN",
            name = "Unknown",
            description = "Unknown status",
            iconUrl = string.Empty,
            self = string.Empty
        };

        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
}
