using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    /// <summary>
    /// Wrapper around the JSON object returned for a JIRA issue.
    /// 
    /// 
    /// </summary>
    public class Issue
    {
        public string id { get; set; }
        public string key { get; set; }

        public Fields fields { get; set; }

        public class Fields
        {
            public string summary { get; set; }
            public string description { get; set; }
            // TODO: Add more fields
        }

        // TODO: Add more fields
    }
}
