AnotherJiraRestClient
=====================
AnotherJiraRestClient is a(nother) .NET wrapper for the [Jira REST API](http://docs.atlassian.com/jira/REST/latest/) written in C#.

Usage examples
--------------
All access to the Jira API is done via the `JiraClient` 
class. See XML documentation for more details, this document only captues a few example use cases.

###### JiraClient.GetIssue(string issueKey)
`JiraClient.GetIssue(string issueKey)` returns the `Issue`
with the specified key. `Issue` matches the JSON object 
returned from the Jira API.
Example usage in C#:
    
    var account = new JiraAccount("https://example.atlassian.net", "user", "password");
    var client = new JiraClient(account);
	// Retrieve issue with key TES-1
    var issue = client.GetIssue("TES-1");

###### GetIssuesByJql(string jql, int startAt, int maxResults, IEnumerable<string> fields = null)
`GetIssuesByJql(...)` returns the `Issues`
by searching using the specified jql query (see Jira API documentation).
Example usage in C#:
    
    var account = new JiraAccount("https://example.atlassian.net", "user", "password");
    var client = new JiraClient(account);
	// Retrieve issues in project TES and priority 1, 2 or 3.
    var issues = client.GetIssuesByJql(
		"project=TES AND priority in (1, 2, 3)", 
		0, 
		25, 
		new string[] {AnotherJiraRestClient.Issue.FIELD_SUMMARY, AnotherJiraRestClient.Issue.FIELD_STATUS, AnotherJiraRestClient.Issue.FIELD_PRIORITY});

###### CreateIssue(CreateIssue newIssue)
`CreateIssue(CreateIssue newIssue)` creates a new issue in Jira and returns the created issue.

Example usage in C#:

    var account = new JiraAccount("https://example.atlassian.net", "user", "password");
    var client = new JiraClient(account);
	
	// Create object representation of a new issue
	var newIssue = new CreateIssue("TES", "Summary text", "Description text", "1", "1", new string[] { "label1", "label2" });
	// Upload the new issue to Jira and store the new issue in createdIssue (contains for example the assigned key)
	var createdIssue = client.CreateIssue(newIssue);	