using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    // TODO: Change to nullable types

    /// <summary>
    /// Wrapper around the JSON object returned for a JIRA issue. See 
    /// http://docs.atlassian.com/jira/REST/latest/ for documentation.
    /// </summary>
    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class IssueFieldNames
    {
        public static const string PROGRESS = "progress";
        public static const string SUMMARY = "summary";
        public static const string TIMETRACKING = "timetracking";
        public static const string ISSUETYPE = "issuetype";
        public static const string VOTES = "votes";
        public static const string RESOLUTION = "resolution";
        public static const string FIXVERSIONS = "fixVersions";
        public static const string RESOLUTIONDATE = "resolutiondate";
        public static const string TIMESPENT = "timespent";
        public static const string REPORTER = "reporter";
        public static const string AGGREGATEIMEORIHINALESTIMATE = "aggregatetimeoriginalestimate";
        public static const string CREATED = "created";
        public static const string UPDATED = "updated";
        public static const string DESCRIPTION = "description";
        public static const string PRIORITY = "priority";
        public static const string DUEDATE = "duedate";
        public static const string ISSUELINKS = "issuelinks";
        public static const string WATCHES = "watches";
        public static const string WORKLOG = "worklog";
        public static const string SUBTASKS = "subtasks";
        public static const string STATUS = "status";
        public static const string LABELS = "labels";
        public static const string WORKRATIO = "workratio";
        public static const string ASSIGNEE = "assignee";
        public static const string ATTACHMENT = "attachment";
        public static const string AGGREGATETIMEESTIMATE = "aggregatetimeestimate";
        public static const string PROJECT = "project";
        public static const string VERSIONS = "versions";
        public static const string ENVIRONMENT = "environment";
        public static const string TIMEESTIMATE = "timeestimate";
        public static const string AGGREGATEPROGESS = "aggregateprogress";
        public static const string COMPONENTS = "components";
        public static const string COMMENT = "comment";
        public static const string TIMEORIGINALESTIMATE = "timeoriginalestimate";
        public static const string AGGREGATETIMESPENT = "aggregatetimespent";
    }


    public class Fields
    {
        public Progress progress { get; set; }
        public string summary { get; set; }
        public Timetracking timetracking { get; set; }
        public Issuetype issuetype { get; set; }
        public Votes votes { get; set; }
        public Resolution resolution { get; set; }
        public List<object> fixVersions { get; set; }
        public string resolutiondate { get; set; }
        public int timespent { get; set; }
        public Author reporter { get; set; }
        public int aggregatetimeoriginalestimate { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string description { get; set; }
        public Priority priority { get; set; }
        public string duedate { get; set; }
        public List<object> issuelinks { get; set; }
        public Watches watches { get; set; }
        public Worklogs worklog { get; set; }
        public List<object> subtasks { get; set; }
        public Status status { get; set; }
        public List<string> labels { get; set; }
        public int workratio { get; set; }
        public Author assignee { get; set; }
        public List<object> attachment { get; set; }
        public int aggregatetimeestimate { get; set; }
        public Project project { get; set; }
        public List<object> versions { get; set; }
        public string environment { get; set; }
        public int timeestimate { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public List<object> components { get; set; }
        public Comments comment { get; set; }
        public int timeoriginalestimate { get; set; }
        public int aggregatetimespent { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int percent { get; set; }
    }

    public class Timetracking
    {
        public string originalEstimate { get; set; }
        public string remainingEstimate { get; set; }
        public string timeSpent { get; set; }
        public int originalEstimateSeconds { get; set; }
        public int remainingEstimateSeconds { get; set; }
        public int timeSpentSeconds { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Resolution
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Worklog
    {
        public string self { get; set; }
        public Author author { get; set; }
        public Author updateAuthor { get; set; }
        public string comment { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
    }

    public class Worklogs
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Worklog> worklogs { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
        public int percent { get; set; }
    }

    public class Author
    {
        public string self { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
    }

    public class Comment
    {
        public string self { get; set; }
        public string id { get; set; }
        public Author author { get; set; }
        public string body { get; set; }
        public Author updateAuthor { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
    }

    public class Comments
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Comment> comments { get; set; }
    }
}