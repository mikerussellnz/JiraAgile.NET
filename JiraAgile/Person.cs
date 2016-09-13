using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAgile {
    public class Person : JiraAgileEntity {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public override string ToString() {
            return string.Format("{0} ({1})", DisplayName, Name);
        }
    }
}
