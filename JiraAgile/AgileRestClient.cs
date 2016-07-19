using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using System.Threading.Tasks;

namespace JiraAgile {
    internal class AgileRestClient {
        RestClient _restClient;

        internal string BaseUrl { get; private set; }

        public AgileRestClient(string server, string user, string password) {
            BaseUrl = server.TrimEnd('/') + "/rest/agile/1.0";
            _restClient = new RestClient(BaseUrl);
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password)) {
                _restClient.Authenticator = new HttpBasicAuthenticator(user, password);
            }
        }

        internal T Execute<T>(RestRequest request) where T : new() {
            preProcessRequest(request);
            var response = _restClient.Execute<T>(request);
            processResponse(response);
            return response.Data;
        }
        
        internal async Task<T> ExecuteAsync<T>(RestRequest request, CancellationToken token) where T : new() {
            preProcessRequest(request);
            var response = await _restClient.ExecuteTaskAsync<T>(request, token).ConfigureAwait(false);
            processResponse(response);
            return response.Data;
        }

        private void preProcessRequest(RestRequest request) {
            request.AddParameter("maxResults", -1);
        }

        private void processResponse<T>(IRestResponse<T> response) where T : new() {
            ListResponse list = response.Data as ListResponse;
            if (list != null) {
                foreach (var item in list.GetItems()) {
                    JiraAgileEntity entity = item as JiraAgileEntity;
                    if (entity != null) {
                        entity.SetRestClient(this);
                        entity.Resource = entity.Self != null ? entity.Self.Replace(_restClient.BaseUrl.ToString(), "") : null;
                    }
                }
            }
        }
    }
}
