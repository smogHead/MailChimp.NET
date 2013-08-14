using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Helper;

namespace MailChimp.Lists
{
    [DataContract]
    public class StaticSegmentMembersDeleteResult
    {
        /// <summary>
        /// Number of email addresses that were successfully added
        /// </summary>
        [DataMember(Name = "success_count")]
        public int SuccessCount
        {
            get;
            set;
        }

        /// <summary>
        /// Number of email addresses that failed during addition/updating
        /// </summary>
        [DataMember(Name = "error_count")]
        public int ErrorCount
        {
            get;
            set;
        }

        /// <summary>
        /// Error information
        /// </summary>
        [DataMember(Name = "errors")]
        public List<ListError> Errors
        {
            get;
            set;
        }
    }
}
