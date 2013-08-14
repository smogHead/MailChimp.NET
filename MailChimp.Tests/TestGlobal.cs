﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailChimp.Tests
{
    /// <summary>
    /// Global test information is set in this class
    /// </summary>
    [TestClass]
    public class TestGlobal
    {
        /// <summary>
        /// The global mailchimp API key
        /// </summary>
        public static string Test_APIKey = string.Empty;

        [AssemblyInitialize()]
        public static void AllTestInit(TestContext testContext)
        {
            //  Set this to your Mailchimp API key for testing
            //  See http://kb.mailchimp.com/article/where-can-i-find-my-api-key
            //  for help finding your API key
         //   Test_APIKey = "d57fd22b29ec145774847c7709ca5d0f-us2";
            Test_APIKey = "c3e254bdbd81c3df73a8d254131089d0-us7";
        }
    }
}
