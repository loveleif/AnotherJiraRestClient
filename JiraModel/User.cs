namespace AnotherJiraRestClient.JiraModel
{
	/// <summary>
	///     Class representing a Jira user
	/// </summary>
	public class User
	{
		public string Self { get; set; }
		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public AvatarCollection AvatarUrls { get; set; }
		public string DisplayName { get; set; }
		public bool Active { get; set; }
		public string TimeZone { get; set; }

		public class AvatarCollection
		{
			public string _16x16 { get; set; }
			public string _48x48 { get; set; }
		}
	}
}