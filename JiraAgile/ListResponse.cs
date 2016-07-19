using System.Collections;
using System.Collections.Generic;

namespace JiraAgile {
    public abstract class ListResponse {
        public abstract IList GetItems();
    }

    public class ListResponse<T> : ListResponse {
        public int MaxResults { get; set; }
        public int StartAt { get; set; }
        public bool IsLast { get; set; }
        public List<T> Values { get; set; }
        public List<T> Issues { get; set; }

        public List<T> Results {
            get { return Values != null ? Values : Issues; }
        }

        public override IList GetItems() {
            return Results;
        }
    }
}
