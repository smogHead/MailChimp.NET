﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Lists
{
    [DataContract]
    public class Client
    {
        /// <summary>
        /// the common name of the client
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// a url representing a path to an icon representing this client
        /// </summary>
        [DataMember(Name = "icon_url")]
        public string IconURL
        {
            get;
            set;
        }
    }
}
