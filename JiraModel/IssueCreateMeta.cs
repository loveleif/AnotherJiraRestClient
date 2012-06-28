using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient.JiraModel
{
    public class IssueCreateMeta
    {
        public string expand { get; set; }
        public List<ProjectMeta> projects { get; set; }
    }

    public class ProjectMeta
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public List<IssueType> issuetypes { get; set; }
    }
}
