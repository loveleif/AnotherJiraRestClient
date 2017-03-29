﻿using AnotherJiraRestClient.JiraModel;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp.Authenticators;
using Version = AnotherJiraRestClient.JiraModel.Version;

namespace AnotherJiraRestClient
{
    /// <summary>
    /// Class used for all interaction with the Jira API. See 
    /// http://docs.atlassian.com/jira/REST/latest/ for documentation of the
    /// Jira API.
    /// </summary>
    public class JiraClient
    {
        private readonly RestClient _client;

        /// <summary>
        /// Constructs a JiraClient.
        /// </summary>
        /// <param name="account">Jira account information</param>
        public JiraClient(JiraAccount account)
        {
            _client = new RestClient(account.ServerUrl)
            {
                Authenticator = new HttpBasicAuthenticator(account.User, account.Password)
            };
        }

        /// <summary>
        /// Executes a RestRequest and returns the deserialized response. If
        /// the response hasn't got the specified expected response code or if an
        /// exception was thrown during execution a JiraApiException will be 
        /// thrown.
        /// </summary>
        /// <typeparam name="T">Request return type</typeparam>
        /// <param name="request">request to execute</param>
        /// <param name="expectedResponseCode">The expected HTTP response code</param>
        /// <returns>deserialized response of request</returns>
        public T Execute<T>(RestRequest request, HttpStatusCode expectedResponseCode) where T : new()
        {
            // Won't throw exception.
            var response = _client.Execute<T>(request);

            ValidateResponse(response);

            return response.Data;
        }

	    /// <summary>
	    /// Throws exception with details if request was not unsucessful
	    /// </summary>
	    /// <param name="response"></param>
	    private static void ValidateResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed || response.ErrorException != null || response.StatusCode == HttpStatusCode.BadRequest)
                throw new JiraApiException(
	                $"RestSharp response status: {response.ResponseStatus} - HTTP response: {response.StatusCode} - {response.StatusDescription} - {response.Content}");
        }

        /// <summary>
        /// Returns a comma separated string from the strings in the provided
        /// IEnumerable of strings. Returns an empty string if null is provided.
        /// </summary>
        /// <param name="strings">items to put in the output string</param>
        /// <returns>a comma separated string</returns>
        private static string ToCommaSeparatedString(IEnumerable<string> strings)
        {
            if (strings != null)
                return string.Join(",", strings.ToArray());
            else
                return string.Empty;
        }

        /// <summary>
        /// Returns the Issue with the specified key. If the fields parameter
        /// is specified only the given field names will be loaded. Issue
        /// contains the availible field names, for example Issue.SUMMARY. Throws
        /// a JiraApiException if the request was unable to execute.
        /// </summary>
        /// <param name="issueKey">Issue key</param>
        /// <param name="fields">Fields to load</param>
        /// <returns>
        /// The issue with the specified key or null if no such issue was found.
        /// </returns>
        public Issue GetIssue(string issueKey, IEnumerable<string> fields = null)
        {
            var fieldsString = ToCommaSeparatedString(fields);

	        var request = new RestRequest
	        {
		        Resource = $"{ResourceUrls.IssueByKey(issueKey)}?fields={fieldsString}",
		        Method = Method.GET
	        };

	        var issue = Execute<Issue>(request, HttpStatusCode.OK);
            return issue.fields != null ? issue : null;
        }

		public bool UpdateIssueFields(string issuekey, object fields)
		{
			var request = new RestRequest
			{
				Resource = $"{ResourceUrls.IssueByKey(issuekey)}",
				Method = Method.PUT,
				RequestFormat = DataFormat.Json,
			};

			//request.AddBody(
			//	new
			//	{
			//		update = fields
			//	});

			// Alternative for "simple" fields
			//request.AddBody(
			//	new { fields = new { customfield_11421 = "1.0.0" } }
			//);
			request.AddBody(fields);

			// No response expected
			var response = _client.Execute(request);

			ValidateResponse(response);

			return response.StatusCode == HttpStatusCode.NoContent;
		}

		/// <summary>
		/// Searches for Issues using JQL. Throws a JiraApiException if the request 
		/// was unable to execute.
		/// </summary>
		/// <param name="jql">a JQL search string</param>
		/// <param name="startAt"></param>
		/// <param name="maxResults"></param>
		/// <param name="fields"></param>
		/// <returns>The search results</returns>
		public Issues GetIssuesByJql(string jql, int startAt, int maxResults, IEnumerable<string> fields = null)
        {
		    var request = new RestRequest {Resource = ResourceUrls.Search()};
		    request.AddParameter(new Parameter()
                {
                    Name = "jql",
                    Value = jql,
                    Type = ParameterType.GetOrPost
                });
            request.AddParameter(new Parameter()
            {
                Name = "fields",
                Value = ToCommaSeparatedString(fields),
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
            return Execute<Issues>(request, HttpStatusCode.OK);
        }

	    /// <summary>
	    /// Returns the Issues for the specified project.  Throws
	    /// a JiraApiException if the request was unable to execute.
	    /// </summary>
	    /// <param name="projectKey">project key</param>
	    /// <param name="startAt"></param>
	    /// <param name="maxResults"></param>
	    /// <param name="fields"></param>
	    /// <returns>the Issues of the specified project</returns>
	    public Issues GetIssuesByProject(string projectKey, int startAt, int maxResults, IEnumerable<string> fields = null)
        {
            return GetIssuesByJql("project=" + projectKey, startAt, maxResults, fields);
        }

        /// <summary>
        /// Returns all available projects the current user has permision to view. 
        /// Throws a JiraApiException if the request was unable to execute.
        /// </summary>
        /// <returns>Details of all projects visible to user</returns>
        public List<Project> GetProjects()
        {
            var request = new RestRequest()
            {
                Resource = ResourceUrls.Project(),
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            return Execute<List<Project>>(request, HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns a list of all possible priorities.  Throws
        /// a JiraApiException if the request was unable to execute.
        /// </summary>
        /// <returns></returns>
        public List<Priority> GetPriorities()
        {
            var request = new RestRequest();
            request.Resource = ResourceUrls.Priority();
            request.Method = Method.GET;
            return Execute<List<Priority>>(request, HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns the meta data for creating issues. This includes the 
        /// available projects and issue types, but not fields (fields
        /// are supported in the Jira api but not by this wrapper currently).
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns>the meta data for creating issues</returns>
        public ProjectMeta GetProjectMeta(string projectKey)
        {
	        var request = new RestRequest {Resource = ResourceUrls.CreateMeta()};
	        request.AddParameter(new Parameter()
              {
                  Name = "projectKeys",
                  Value = projectKey,
                  Type = ParameterType.GetOrPost
              });
            request.Method = Method.GET;
            var createMeta = Execute<IssueCreateMeta>(request, HttpStatusCode.OK);
            if (createMeta.projects[0].key != projectKey || createMeta.projects.Count != 1)
                // TODO: Error message
                throw new JiraApiException();
            return createMeta.projects[0];
        }

        /// <summary>
        /// Returns a list of all possible issue statuses. Throws
        /// a JiraApiException if the request was unable to execute.
        /// </summary>
        /// <returns></returns>
        public List<Status> GetStatuses()
        {
            var request = new RestRequest();
            request.Resource = ResourceUrls.Status();
            request.Method = Method.GET;
            return Execute<List<Status>>(request, HttpStatusCode.OK);
        }
		
		public Version CreateVersion(NewVersion newVersion)
        {
            var request = new RestRequest()
            {
                Resource = ResourceUrls.Version(),
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };

            request.AddBody(newVersion);

            return Execute<Version>(request, HttpStatusCode.Created);
        }

        public Version UpdateVersion(UpdateVersion version)
        {
            var request = new RestRequest
            {
                Resource = ResourceUrls.Version(),
                RequestFormat = DataFormat.Json,
                Method = Method.PUT
            };

            request.AddBody(version);

            return Execute<Version>(request, HttpStatusCode.OK);
        }

        public IEnumerable<Version> GetVersions(string projectKey)
        {
            var request = new RestRequest
            {
                Resource = ResourceUrls.Versions(projectKey), 
                Method = Method.GET
            };
            return Execute<List<Version>>(request, HttpStatusCode.OK);
        }

        /// <summary>
        /// Creates a new issue. Throws a JiraApiException if the request was 
        /// unable to execute.
        /// </summary>
        /// <returns>the new issue</returns>
        public BasicIssue CreateIssue(CreateIssue newIssue)
        {
            var request = new RestRequest()
            {
                Resource = ResourceUrls.Issue(),
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };

            request.AddBody(newIssue);

            return Execute<BasicIssue>(request, HttpStatusCode.Created);
        }

        /// <summary>
        /// Returns the application property with the specified key.
        /// </summary>
        /// <param name="propertyKey">the property key</param>
        /// <returns>the application property with the specified key</returns>
        public ApplicationProperty GetApplicationProperty(string propertyKey)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = ResourceUrls.ApplicationProperties(),
                RequestFormat = DataFormat.Json
            };

            request.AddParameter(new Parameter()
            {
                Name = "key",
                Value = propertyKey,
                Type = ParameterType.GetOrPost
            });

            return Execute<ApplicationProperty>(request, HttpStatusCode.OK);
        }

        /// <summary>
        /// Returns the attachment with the specified id.
        /// </summary>
        /// <param name="attachmentId">attachment id</param>
        /// <returns>the attachment with the specified id</returns>
        public Attachment GetAttachment(string attachmentId)
        {
            var request = new RestRequest()
            {
                Method = Method.GET,
                Resource = ResourceUrls.AttachmentById(attachmentId),
                RequestFormat = DataFormat.Json
            };

            return Execute<Attachment>(request, HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes the specified attachment.
        /// </summary>
        /// <param name="attachmentId">attachment to delete</param>
        public void DeleteAttachment(string attachmentId)
        {
            var request = new RestRequest()
            {
                Method = Method.DELETE,
                Resource = ResourceUrls.AttachmentById(attachmentId)
            };

            var response = _client.Execute(request);
            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.NoContent)
                throw new JiraApiException("Failed to delete attachment with id=" + attachmentId);
        }

        /// <summary>
        /// Update time tracking estimates
        /// </summary>
        /// <param name="issuekey"></param>
        /// <param name="orginialEstimateMinutes"></param>
        /// <param name="remainingEstimateMinutes"></param>
        /// <returns></returns>
        public bool UpdateTimetracking(string issuekey, int orginialEstimateMinutes, int remainingEstimateMinutes)
        {
            var request = new RestRequest()
            {
                Resource = $"{ResourceUrls.IssueByKey(issuekey)}",
                Method = Method.PUT,
                RequestFormat = DataFormat.Json,
            };

            // Alternative for "simple" fields
            //request.AddBody(
            //    new { fields = new { summary = issue.fields.summary } }
            //);

            request.AddBody(
                new
                {
                    update = new
                    {
                        timetracking = new object[] {new
                        {
                            edit = new
                            {
                                // No entry in seconds possible apparently
                                originalEstimate = $"{orginialEstimateMinutes}m",
                                remainingEstimate= $"{remainingEstimateMinutes}m"
                            }
                        }}
                    }
                }
                );

            // No response expected
            var response = _client.Execute(request);

            ValidateResponse(response);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
