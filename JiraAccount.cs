using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    [Serializable()]
    public class JiraAccount
    {
        public string ServerUrl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
