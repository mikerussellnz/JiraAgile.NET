using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Threading;

namespace JiraAgile {
    public class Sprints {
        private AgileRestClient _restClient;
        private JiraAgileEntity _parent;

        internal Sprints(JiraAgileEntity parent, AgileRestClient restClient) {
            _parent = parent;
            _restClient = restClient;
        }

        public async Task<List<Sprint>> GetSprints(CancellationToken token = default(CancellationToken)) {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = string.Format("{0}/sprint", _parent.Resource);
            request.RequestFormat = DataFormat.Json;
            var response = await _restClient.ExecuteAsync<ListResponse<Sprint>>(request, token).ConfigureAwait(false);
            return response.Results;
        }
    }
}
