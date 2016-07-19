using System;

namespace JiraAgile {
    public class AgileClient {
        private AgileRestClient _restClient;

        public readonly Boards Boards;
                    
        public AgileClient(string server, string user, string password) {
            _restClient = new AgileRestClient(server, user, password);
            Boards = new Boards(_restClient);
        }
    }
}
