using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AnotherJiraRestClient
{
    public class JiraClient
    {
        private readonly string baseUrl;
        private readonly string userName;
        private readonly string password;

        public JiraClient(string baseUrl, string userName, string password)
        {
            this.baseUrl = baseUrl;
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// Execute a RestRequest using this JiraClient. See https://github.com/restsharp/RestSharp/wiki/Recommended-Usage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            // TODO: Make client a class member?
            var client = new RestClient(baseUrl);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public Issue GetIssue(string issueKey)
        {
            var request = new RestRequest();
            // TODO: Move /rest/api/2 elsewhere
            request.Resource = "/rest/api/2/issue/" + issueKey;
            request.Method = Method.GET;
            return Execute<Issue>(request);
        }

        public Issues GetIssuesByJql(string jql)
        {
            var request = new RestRequest();
            request.Resource = "/rest/api/2/search?jql=" + jql;
            request.Method = Method.GET;
            return Execute<Issues>(request);
        }

        public Issues GetIssuesByProject(string projectKey)
        {
            return GetIssuesByJql("project=" + projectKey);
        }
    }
}
