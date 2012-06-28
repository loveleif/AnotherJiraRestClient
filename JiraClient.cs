using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AnotherJiraRestClient.JiraModel;
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
        private readonly RestClient client;

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
            client = new RestClient(account.ServerUrl)
            {
                Authenticator = new HttpBasicAuthenticator(account.User, account.Password)
            };
        }

        /// <summary>
        /// Execute a RestRequest using this JiraClient.
        /// </summary>
        /// <typeparam name="T">Request return type</typeparam>
        /// <param name="request">RestRequest to execute</param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
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
        public Issues GetIssuesByJql(string jql, int startAt, int maxResults, IEnumerable<string> fields = null)
        {
            var request = new RestRequest();
            request.Resource = "/rest/api/2/search";
            request.AddParameter(new Parameter()
                {
                    Name = "jql",
                    Value = jql,
                    Type = ParameterType.GetOrPost
                });
            request.AddParameter(new Parameter()
            {
                Name = "fields",
                Value = GetFieldsString(fields),
                Type = ParameterType.GetOrPost
            });
            request.AddParameter(new Parameter()
            {
                Name = "startAt",
                Value = startAt,
                Type = ParameterType.GetOrPost
            });
            request.AddParameter(new Parameter()
            {
                Name = "maxResults",
                Value = maxResults,
                Type = ParameterType.GetOrPost
            });
            request.Method = Method.GET;
            return Execute<Issues>(request);
        }

        /// <summary>
        /// Returns the Issues for the specified project.
        /// </summary>
        /// <param name="projectKey">project key</param>
        /// <returns>the Issues of the specified project</returns>
        public Issues GetIssuesByProject(string projectKey, int startAt, int maxResults, IEnumerable<string> fields = null)
        {
            return GetIssuesByJql("project=" + projectKey, startAt, maxResults, fields);
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

        public ProjectMeta GetProjectMeta(string projectKey)
        {
            var request = new RestRequest();
            request.Resource = "/rest/api/2/issue/createmeta";
            request.Parameters.Add(new Parameter() 
              { Name = "projectKeys", 
                Value = projectKey, 
                Type = ParameterType.GetOrPost });
            request.Method = Method.GET;
            var createMeta = Execute<IssueCreateMeta>(request);
            if (createMeta.projects[0].key != projectKey)
                return null;
            return createMeta.projects[0];
        }

        /// <summary>
        /// Returns a list of all possible statuses.
        /// </summary>
        /// <returns></returns>
        public List<Status> GetStatuses()
        {
            var request = new RestRequest();
            // TODO: Move /rest/api/2 elsewhere
            request.Resource = "/rest/api/2/status";
            request.Method = Method.GET;
            return Execute<List<Status>>(request);
        }

        public string CreateIssue(string projectKey, string summary, string description, string issueTypeId, string priorityId, IEnumerable<string> labels)
        {
            // TODO: Can you add custom fields by using an ExpandoObject??
            var request = new RestRequest(Method.POST);
            request.Resource = "rest/api/2/issue";
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                fields = new
                {
                    project = new { key = projectKey },
                    summary = summary,
                    description = description,
                    issuetype = new { id = issueTypeId },
                    priority = new { id = priorityId },
                    labels = labels
                }
            });
            var response = client.Execute(request);
            return response.Content;
        }
    }
}
