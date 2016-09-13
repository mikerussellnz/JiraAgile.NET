using System.Collections.Generic;
using RestSharp.Deserializers;
using System;

namespace JiraAgile {
    public class Issue : JiraAgileEntity {
        public string Key { get; set; }

        [DeserializeAs(Name = "fields.issuetype.name")]
        public string Type { get; set; }

        [DeserializeAs(Name = "fields.issuetype.subtask")]
        public bool IsSubTask { get; set; }

        [DeserializeAs(Name = "fields.summary")]
        public string Summary { get; set; }

        [DeserializeAs(Name = "fields.assignee")]
        public Person Assignee { get; set; }

        [DeserializeAs(Name = "fields.creator")]
        public Person Creator { get; set; }

        [DeserializeAs(Name = "fields.reporter")]
        public Person Reporter { get; set; }
        
        [DeserializeAs(Name = "fields.status.name")]
        public string Status { get; set; }

        [DeserializeAs(Name = "fields.priority.name")]
        public string Priority { get; set; }

        [DeserializeAs(Name = "fields.updated")]
        public DateTime Updated { get; set; }

        [DeserializeAs(Name = "fields.subtasks")]
        public List<Issue> SubTasks { get; set; }

        [DeserializeAs(Name = "fields.comment.comments")]
        public List<Comment> Comments { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public override string ToString() {
            return string.Format("{0} ({1})", Key, Id);
        }
    } 
}
