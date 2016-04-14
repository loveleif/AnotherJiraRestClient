namespace AnotherJiraRestClient.JiraModel
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
}