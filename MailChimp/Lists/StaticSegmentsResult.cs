using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Lists
{
    [DataContract]
    public class StaticSegmentsResult
    {
    
        /// <summary>
        /// The list of static segments
        /// </summary>
        [DataMember(Name = "data")]
        public List<StaticSegment> Data
        {
            get;
            set;
        }
    }
}
