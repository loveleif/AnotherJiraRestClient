AnotherJiraRestClient
=====================
AnotherJiraRestClient is a(nother) .NET wrapper for the [Jira REST API](http://docs.atlassian.com/jira/REST/latest/) written in C#.

Usage
-----
All access to the Jira API is done via the `JiraClient` 
class.

###### JiraClient.GetIssue(string issueKey)
`JiraClient.GetIssue(string issueKey)` returns the `Issue`
with the specified key. `Issue` matches the JSON object 
returned from the Jira API.
Example usage in C#:
    
    var account = new JiraAccount("https://example.atlassian.net", "user", "password");
    var client = new JiraClient(account);
    var issue = client.GetIssue("TES-1");
    Console.WriteLine(issue.fields.summary);
