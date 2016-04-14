
namespace AnotherJiraRestClient.JiraModel
{
    /// <summary>
    /// Class representing a Jira issue link
    /// </summary>
    public class IssueLink
    {
        public string id { get; set; }
        public LinkType type { get; set; }
        public Issue outwardIssue { get; set; }
        public Issue inwardIssue { get; set; }
    }
}
