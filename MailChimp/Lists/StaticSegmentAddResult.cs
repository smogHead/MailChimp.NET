using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Lists
{
    [DataContract]
    public class StaticSegmentAddResult
    {
        /// <summary>
        /// whether the call worked. reallistically this will always be true as errors will be thrown otherwise.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id
        {
            get;
            set;
        }
    }
}
