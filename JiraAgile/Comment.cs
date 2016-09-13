using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAgile {
    public class Comment : JiraAgileEntity {
        public Person Author { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}
