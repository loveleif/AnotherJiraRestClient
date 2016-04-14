using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient.JiraModel
{
    /// <summary>
    /// Class representing an Jira application property.
    /// </summary>
    public class ApplicationProperty
    {
        public string id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public string defaultValue { get; set; }
    }
}
