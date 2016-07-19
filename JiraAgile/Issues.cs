using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;

namespace JiraAgile {
    public class Issues {
        private AgileRestClient _restClient;
        private JiraAgileEntity _parent;

        internal Issues(JiraAgileEntity parent, AgileRestClient restClient) {
            _parent = parent;
            _restClient = restClient;
        }

        public async Task<List<Issue>> GetIssues(CancellationToken token = default(CancellationToken)) {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = string.Format("{0}/issue", _parent.Resource);
            request.RequestFormat = DataFormat.Json;
            var response = await _restClient.ExecuteAsync<ListResponse<Issue>>(request, token).ConfigureAwait(false); 
            return response.Results;
        }
    }
}
