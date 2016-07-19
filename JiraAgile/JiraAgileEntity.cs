namespace JiraAgile {
    public class JiraAgileEntity {
        internal string Resource { get; set; }

        public int Id { get; set; }
        public string Self { get; set; }

        internal virtual void SetRestClient(AgileRestClient restClient) {
        }
    }
}
