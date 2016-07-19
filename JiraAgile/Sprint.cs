using System;

namespace JiraAgile {
    public class Sprint : JiraAgileEntity {
        private Issues _issues;
    
        public string State { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public int OriginBoardId { get; set; }

        public Issues Issues { get { return _issues; } }

        internal override void SetRestClient(AgileRestClient restClient) {
            base.SetRestClient(restClient);
            _issues = new Issues(this, restClient);
        }

        public override string ToString() {
            return string.Format("{0} ({1})", Name, Id);
        }
    }
}
