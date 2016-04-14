namespace AnotherJiraRestClient.JiraModel
{
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
}