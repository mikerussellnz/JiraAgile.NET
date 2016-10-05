using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAgile {
    public class JiraServerException : Exception {
        private string stackTrace;
        private int statusCode;

        public JiraServerException(string message, int statusCode, string detail)
            : base(string.Format("{0} Status Code: {1} Detail:\n{2}", message, statusCode, detail)) {
        }
    }
}
