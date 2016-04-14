namespace AnotherJiraRestClient.JiraModel
{
    public class NewVersion
    {
        public bool released { get; set; }
        public string name { get; set; }
        public string project { get; set; }
        public string userReleaseDate { get; set; }
        public string userStartDate { get; set; }
        public string description { get; set; }
    }
}