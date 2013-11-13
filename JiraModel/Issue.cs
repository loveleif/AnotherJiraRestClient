using AnotherJiraRestClient.JiraModel;
using System.Collections.Generic;

namespace AnotherJiraRestClient
{
    // TODO: Change to nullable types?

    /// <summary>
    /// Wrapper around the JSON object returned for a JIRA issue. See 
    /// http://docs.atlassian.com/jira/REST/latest/ for documentation.
    /// </summary>
    public class Issue : BasicIssue
    {
        // Field names
        public const string FIELD_PROGRESS = "progress";
        public const string FIELD_SUMMARY = "summary";
        public const string FIELD_TIMETRACKING = "timetracking";
        public const string FIELD_ISSUETYPE = "issuetype";
        public const string FIELD_VOTES = "votes";
        public const string FIELD_RESOLUTION = "resolution";
        public const string FIELD_FIXVERSIONS = "fixVersions";
        public const string FIELD_RESOLUTIONDATE = "resolutiondate";
        public const string FIELD_TIMESPENT = "timespent";
        public const string FIELD_REPORTER = "reporter";
        public const string FIELD_AGGREGATEIMEORIHINALESTIMATE = "aggregatetimeoriginalestimate";
        public const string FIELD_CREATED = "created";
        public const string FIELD_UPDATED = "updated";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_PRIORITY = "priority";
        public const string FIELD_DUEDATE = "duedate";
        public const string FIELD_ISSUELINKS = "issuelinks";
        public const string FIELD_WATCHES = "watches";
        public const string FIELD_WORKLOG = "worklog";
        public const string FIELD_SUBTASKS = "subtasks";
        public const string FIELD_STATUS = "status";
        public const string FIELD_LABELS = "labels";
        public const string FIELD_WORKRATIO = "workratio";
        public const string FIELD_ASSIGNEE = "assignee";
        public const string FIELD_ATTACHMENT = "attachment";
        public const string FIELD_AGGREGATETIMEESTIMATE = "aggregatetimeestimate";
        public const string FIELD_PROJECT = "project";
        public const string FIELD_VERSIONS = "versions";
        public const string FIELD_ENVIRONMENT = "environment";
        public const string FIELD_TIMEESTIMATE = "timeestimate";
        public const string FIELD_AGGREGATEPROGESS = "aggregateprogress";
        public const string FIELD_COMPONENTS = "components";
        public const string FIELD_COMMENT = "comment";
        public const string FIELD_TIMEORIGINALESTIMATE = "timeoriginalestimate";
        public const string FIELD_AGGREGATETIMESPENT = "aggregatetimespent";

        public Fields fields { get; set; }
    }

    public class BasicIssue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
    }

    public class Fields
    {
        public Progress progress { get; set; }
        public string summary { get; set; }
        public Timetracking timetracking { get; set; }
        public IssueType issuetype { get; set; }
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

    public class Subtask
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public List<object> fields { get; set; }
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

    public class IssueType
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

    public class Component
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}