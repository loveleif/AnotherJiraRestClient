using System;

namespace AnotherJiraRestClient.JiraModel
{
    public class Version
    {
        // TODO: Move off the heap?
        public static Version UNKNOWN_VERSION = new Version()
        {
            id = "UNKNOWN",
            name = "Unknown",
            description = "Unknown version",
            archived = false,
            self = string.Empty
        };

        public string self { get; set; }
        public string description { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public DateTime releaseDate { get; set; }
        public string userReleaseDate { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string projectId { get; set; }
    }
}