using System.IO;

namespace AnotherJiraRestClient
{
    public static class ResourceUrls
    {
        private const string BaseUrl = "/rest/api/2/";

        public static string IssueByKey(string issueKey)
        {
            return Url($"issue/{issueKey}");
        }

        public static string Issue()
        {
            return Url("issue");
        }

        public static string Search()
        {
            return Url("search");
        }

        public static string Priority()
        {
            return Url("priority");
        }

        public static string CreateMeta()
        {
            return Url("issue/createmeta");
        }

        public static string Status()
        {
            return Url("status");
        }

        public static string Versions(string projectKey)
        {
            return Url($"project/{projectKey}/versions");
        }

        public static string Version()
        {
            return Url("version");
        }

        public static string UpdateVersion(string versionId)
        {
            return Url($"version/{versionId}");
        }

        public static string ApplicationProperties()
        {
            return Url("application-properties");
        }

        public static string AttachmentById(string attachmentId)
        {
            return Url($"attachment/{attachmentId}");
        }

        public static string Project()
        {
            return Url("project");
        }

        private static string Url(string key)
        {
            return Path.Combine(BaseUrl, key);
        }
    }
}