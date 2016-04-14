using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient.JiraModel
{
    public class StatusCategory
    {
        public string self { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
        public string id { get; set; }            
    }
}
