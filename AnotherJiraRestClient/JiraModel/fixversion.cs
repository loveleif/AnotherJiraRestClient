using System;

namespace AnotherJiraRestClient.JiraModel
{
    public class fixversion
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string archived { get; set; }
        public string released { get; set; }
        public DateTime releaseDate { get; set; }
    }
}