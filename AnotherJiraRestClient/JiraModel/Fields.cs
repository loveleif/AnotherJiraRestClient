using System.Collections.Generic;

namespace AnotherJiraRestClient.JiraModel
{
    public class Fields
    {
        /// <summary>
        /// Release notes field
        /// </summary>
        public string customfield_10400 { get; set; }

        /// <summary>
        /// Available From field
        /// </summary>
        public Version customfield_10700 { get; set; }
        public Progress progress { get; set; }
        public string summary { get; set; }
        public Timetracking timetracking { get; set; }
        public IssueType issuetype { get; set; }
        public Votes votes { get; set; }
        public Resolution resolution { get; set; }
        public List<fixversion> fixVersions { get; set; }
        public string resolutiondate { get; set; }
        public int timespent { get; set; }
        public Author reporter { get; set; }
        public int aggregatetimeoriginalestimate { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string description { get; set; }
        public Priority priority { get; set; }
        public string duedate { get; set; }
        public List<IssueLink> issuelinks { get; set; }
        public Watches watches { get; set; }
        public Worklogs worklog { get; set; }
        public List<Subtask> subtasks { get; set; }
        public Status status { get; set; }
        public List<string> labels { get; set; }
        public long workratio { get; set; }
        public Author assignee { get; set; }
        public List<object> attachment { get; set; }
        public int aggregatetimeestimate { get; set; }
        public Project project { get; set; }
        public List<object> versions { get; set; }
        public string environment { get; set; }
        public int timeestimate { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public List<Component> components { get; set; }
        public Comments comment { get; set; }
        public int timeoriginalestimate { get; set; }
        public int aggregatetimespent { get; set; }
    }
}