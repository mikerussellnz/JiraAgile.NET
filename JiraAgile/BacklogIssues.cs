using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JiraAgile {
    public class BacklogIssues {
        private Board _board;
        private AgileRestClient _restClient;

        internal BacklogIssues(Board board, AgileRestClient restClient) {
            _board = board;
            _restClient = restClient;
        }

        public async Task<List<Issue>> GetIssues(CancellationToken token = default(CancellationToken)) {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = string.Format("{0}/backlog", _board.Resource);
            request.RequestFormat = DataFormat.Json;
            var response = await _restClient.ExecuteAsync<ListResponse<Issue>>(request, token).ConfigureAwait(false);
            return response.Results;
        }
    }
}
