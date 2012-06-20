using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AnotherJiraRestClient
{
    // TODO: Exception handling. When Jira service is unavailible, when response code is
    // unexpected, etc.

    // TODO: Check if response.ResponseStatus == ResponseStatus.Error

    // TODO: What if URL is too long?

    /// <summary>
    /// Class used for all interaction with the Jira API. See 
    /// http://docs.atlassian.com/jira/REST/latest/ for documentation of the
    /// Jira API.
    /// </summary>
    public class JiraClient
    {
        private readonly JiraAccount account;

        /// <summary>
        /// Constructs a JiraClient. Please note, the baseUrl needs to be https
        /// (not http), otherwise Jira will response with unauthorized.
        /// </summary>
        /// <param name="baseUrl">The domain part of the Jira 
        /// installation. For example https://example.atlassian.net/. Please 
        /// note, if you don't use https Jira will response with unauthorized.
        /// </param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        public JiraClient(JiraAccount account)
        {
            this.account = account;
        }

        /// <summary>
        /// Execute a RestRequest using this JiraClient.
        /// </summary>
        /// <typeparam name="T">Request return type</typeparam>
        /// <param name="request">RestRequest to execute</param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            // TODO: Make client a class member?
            var client = new RestClient(account.ServerUrl);
            client.Authenticator = new HttpBasicAuthenticator(account.User, account.Password);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        private static string GetFieldsString(IEnumerable<string> fields)
        {
            string fieldsString;
            if (fields != null)
                fieldsString = string.Join(",", fields);
            else
                fieldsString = "";
            return fieldsString;
        }

        /// <summary>
        /// Returns the Issue with the specified key. If the fields parameter
        /// is specified only the given field names will be loaded. Issue
        /// contains the availible field names, for example Issue.SUMMARY.
        /// </summary>
        /// <param name="issueKey">Issue key</param>
        /// <param name="fields">Fields to load</param>
        /// <returns>The issue with the specified key</returns>
        public Issue GetIssue(string issueKey, IEnumerable<string> fields = null)
        {
            var fieldsString = GetFieldsString(fields);
            
            var request = new RestRequest();
            // TODO: Move /rest/api/2 elsewhere
            request.Resource = "/rest/api/2/issue/" + issueKey + "?fields=" + fieldsString;
            request.Method = Method.GET;
            return Execute<Issue>(request);
        }

        /// <summary>
        /// Searches for Issues using JQL.
        /// </summary>
        /// <param name="jql">a JQL search string</param>
        /// <returns>searchresults</returns>
        public Issues GetIssuesByJql(string jql, IEnumerable<string> fields = null)
        {
            var fieldsString = GetFieldsString(fields);

            var request = new RestRequest();
            request.Resource = "/rest/api/2/search?jql=" + jql + "&fields=" + fieldsString;
            request.Method = Method.GET;
            return Execute<Issues>(request);
        }

        /// <summary>
        /// Returns the Issues for the specified project.
        /// </summary>
        /// <param name="projectKey">project key</param>
        /// <returns>the Issues of the specified project</returns>
        public Issues GetIssuesByProject(string projectKey, IEnumerable<string> fields = null)
        {
            return GetIssuesByJql("project=" + projectKey, fields);
        }

        /// <summary>
        /// Returns a list of all possible priorities.
        /// </summary>
        /// <returns></returns>
        public List<Priority> GetPriorities()
        {
            var request = new RestRequest();
            // TODO: Move /rest/api/2 elsewhere
            request.Resource = "/rest/api/2/priority";
            request.Method = Method.GET;
            return Execute<List<Priority>>(request);
        }
    }
}
