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
    public class StaticSegmentMembersAddResult
    {

        /// <summary>
        /// Number of email addresses that were successfully updated
        /// </summary>
        [DataMember(Name = "success_count")]
        public int UpdateCount
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
