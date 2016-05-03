using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherJiraRestClient
{
    /// <summary>
    /// Class representing a Jira server acount
    /// </summary>
    [Serializable()]
    public class JiraAccount
    {
        /// <summary>
        /// Jira server url, for example https://example.atalassian.net. Please note that the
        /// protocol needs to be https.
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// Jira server user name
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Jira server password
        /// </summary>
        public string Password { get; set; }
    }
}
