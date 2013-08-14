using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Lists
{
    /// <summary>
    /// Static Segment
    /// </summary>
    [DataContract]
    public class StaticSegment
    {
        /// <summary>
        /// StaticSegment "id" from lists/Static-Segments (either this or name must be present) - 
        /// this id takes precedence and can't change (unlike the name)
        /// </summary>
        [DataMember(Name = "id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// StaticSegment "name" from lists/Static-Segments (either this or id must be present)
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// the total number of subscribed members currently in a segment
        /// </summary>
        [DataMember(Name = "member_count")]
        public string MemberCount
        {
            get;
            set;
        }

        /// <summary>
        /// the date/time the segment was created
        /// </summary>
        [DataMember(Name = "created_date")]
        public string CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// the date/time the segment was last updated (add or del)
        /// </summary>
        [DataMember(Name = "last_update")]
        public string LastUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// the date/time the segment was last reset (ie had all members cleared from it)
        /// </summary>
        [DataMember(Name = "last_reset")]
        public string LastReset
        {
            get;
            set;
        }
    }
}
