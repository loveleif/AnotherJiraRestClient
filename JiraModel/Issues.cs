using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    /// <summary>
    /// Wrapper around the JSON object returned when searching issues. See 
    /// http://docs.atlassian.com/jira/REST/latest/ for documentation.
    /// </summary>
    public class Issues
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }
}
