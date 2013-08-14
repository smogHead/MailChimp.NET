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
    public class StaticSegmentBatchEmailParameter
    {
        public StaticSegmentBatchEmailParameter()
        {
        }

        /// <summary>
        /// Email information for the customer
        /// </summary>
        [DataMember(Name = "email")]
        public string Email
        {
            get;
            set;
        }
    }
}
