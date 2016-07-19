using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JiraAgile {
    public class Boards {
        private AgileRestClient _restClient;

        internal Boards(AgileRestClient restClient) {
            _restClient = restClient;
        }

        public async Task<List<Board>> GetBoards(CancellationToken token = default(CancellationToken)) {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = string.Format("/board");
            request.RequestFormat = DataFormat.Json;
            var response = await _restClient.ExecuteAsync<ListResponse<Board>>(request, token).ConfigureAwait(false);
            return response.Results;
        }
    }
}
