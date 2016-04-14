namespace AnotherJiraRestClient.JiraModel
{
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
}