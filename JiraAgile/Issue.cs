using System.Collections.Generic;

namespace JiraAgile {
    public class Issue : JiraAgileEntity {
        public string Key { get; set; }
        public Dictionary<string, object> Fields { get; set; }

        public override string ToString() {
            return string.Format("{0} ({1})", Key, Id);
        }
    } 
}
