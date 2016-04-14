using AnotherJiraRestClient.JiraModel;

namespace AnotherJiraRestClient.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			JiraClient client = Client(args);

			string projectKey = args[3];
			string issueKey = projectKey + "-" + args[4];
			string customFieldToUpdate = args[5];

			ProjectMeta projectMetaData = client.GetProjectMeta(projectKey);
			Issue issueWithAllFields = client.GetIssue(issueKey);

			// https://developer.atlassian.com/jiradev/jira-apis/jira-rest-apis/jira-rest-api-tutorials/jira-rest-api-example-edit-issues
			var updateIssue = new
			{
				fields = new { customfield_11421 = "1.0.0" }
			};
			client.UpdateIssueFields(issueKey, updateIssue);
		}

		private static JiraClient Client(string[] args)
		{
			var jiraUrl = args[0];
			var userName = args[1];
			var password = args[2];

			var client = new JiraClient(new JiraAccount
			{
				ServerUrl = jiraUrl,
				User = userName,
				Password = password
			});
			return client;
		}
	}
}
