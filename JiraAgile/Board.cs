using System;

namespace JiraAgile {
    public class Board : JiraAgileEntity {
        private Sprints _sprints;
        private Issues _issues;
        private BacklogIssues _backlogIssues;

        public string Name { get; set; }
        public string Type { get; set; }

        public Sprints Sprints { get { return _sprints; } }
        public Issues Issues { get { return _issues; } }
        public BacklogIssues BacklogIssues { get { return _backlogIssues; } }

        internal override void SetRestClient(AgileRestClient restClient) {
            base.SetRestClient(restClient);
            _sprints = new Sprints(this, restClient);
            _issues = new Issues(this, restClient);
            _backlogIssues = new BacklogIssues(this, restClient);
        }

        public override string ToString() {
            return string.Format("{0} ({1})", Name, Id);
        }
    }
}
