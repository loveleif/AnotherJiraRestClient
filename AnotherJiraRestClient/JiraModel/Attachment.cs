using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient.JiraModel
{
    /// <summary>
    /// Class representing a Jira attachment
    /// </summary>
    public class Attachment
    {
        public string self { get; set; }
        public string filename { get; set; }
        public Author author { get; set; }
        public string created { get; set; }
        public int size { get; set; }
        public string mimeType { get; set; }
        public string content { get; set; }
        public string thumbnail { get; set; }
    }
}
