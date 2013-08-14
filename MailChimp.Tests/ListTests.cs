﻿using System;
using System.Collections.Generic;
using MailChimp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MailChimp.Helper;
using System.Diagnostics;

namespace MailChimp.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void GetLists_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);

            //  Act
            ListResult details = mc.GetLists();

            //  Assert
            Assert.IsNotNull(details.Data);
        }

        [TestMethod]
        public void GetAbuseReport_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            //  Act
            AbuseResult details = mc.GetListAbuseReports(lists.Data[0].Id);

            //  Assert
            Assert.IsNotNull(details.Data);
        }

        [TestMethod]
        public void GetListActivity_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            //  Act
            List<ListActivity> results = mc.GetListActivity(lists.Data[1].Id);

            //  Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public void StaticSegmentAdd_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();
           
            //Get existing segments
            List<StaticSegment> segments = mc.GetStaticSegmentsFromList(lists.Data[1].Id);
            StaticSegmentDeleteResult deleteResult;

            //Check to see if test segment exists, delete if it does.
            if (segments.Where(x => x.Name == "TestSegment").Count() > 0)
                deleteResult = mc.StaticSegmentDelete(lists.Data[1].Id, segments.Where(x => x.Name == "TestSegment").FirstOrDefault().Id);

            //  Act
            StaticSegmentAddResult results = mc.StaticSegmentAdd(lists.Data[1].Id, "TestSegment");

            //  Assert
            Assert.IsTrue(!string.IsNullOrEmpty(results.Id));
        }



        [TestMethod]
        public void StaticSegment_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();
           

            //  Act
            List<StaticSegment> results = mc.GetStaticSegmentsFromList(lists.Data[1].Id);

            //  Assert
            Assert.IsNotNull(results);
        }


        [TestMethod]
        public void Subscribe_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();
            EmailParameter email = new EmailParameter()
            {
                Email = "customeremail@righthere.com"
            };

            //  Act
            EmailParameter results = mc.Subscribe(lists.Data[1].Id, email);

            //  Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(!string.IsNullOrEmpty(results.LEId));
        }

        [TestMethod]
        public void BatchSubscribe_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            List<BatchEmailParameter> emails = new List<BatchEmailParameter>();

            BatchEmailParameter email1 = new BatchEmailParameter()
            {
                Email = new EmailParameter()
                {
                    Email = "customeremail1@righthere.com"
                }
            };

            BatchEmailParameter email2 = new BatchEmailParameter()
            {
                Email = new EmailParameter()
                {
                    Email = "customeremail2@righthere.com"
                }
            };

            emails.Add(email1);
            emails.Add(email2);

            //  Act
            BatchSubscribeResult results = mc.BatchSubscribe(lists.Data[1].Id, emails);

            //  Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.AddCount == 2);
        }

        [TestMethod]
        public void Unsubscribe_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();
            EmailParameter email = new EmailParameter()
            {
                Email = "customeremail@righthere.com"
            };

            //  Act
            UnsubscribeResult results = mc.Unsubscribe(lists.Data[1].Id, email);

            //  Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Complete);
        }

        [TestMethod]
        public void BatchUnsubscribe_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            List<EmailParameter> emails = new List<EmailParameter>();

            EmailParameter email1 = new EmailParameter()
            {
                Email = "customeremail1@righthere.com"
            };

            EmailParameter email2 = new EmailParameter()
            {
                Email = "customeremail2@righthere.com"
            };

            emails.Add(email1);
            emails.Add(email2);

            //  Act
            BatchUnsubscribeResult results = mc.BatchUnsubscribe(lists.Data[1].Id, emails);

            //  Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.SuccessCount == 2);
        }

        [TestMethod]
        public void GetMemberInfo_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            List<EmailParameter> emails = new List<EmailParameter>();

            EmailParameter email1 = new EmailParameter()
            {
                Email = "customeremail1@righthere.com"
            };

            EmailParameter email2 = new EmailParameter()
            {
                Email = "customeremail2@righthere.com"
            };

            emails.Add(email1);
            emails.Add(email2);

            //  Act
            MemberInfoResult results = mc.GetMemberInfo(lists.Data[1].Id, emails);

            //  Assert
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void GetAllMembersForList_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            //  For each list
            foreach(var list in lists.Data)
            {
                //  Write out the list name:
                Debug.WriteLine("Users for the list " + list.Name);

                //  Get the first 100 members of each list:
                MembersResult results = mc.GetAllMembersForList(list.Id, "subscribed", 0, 100);

                //  Write out each member's email address:
                foreach(var member in results.Data)
                {
                    Debug.WriteLine(member.Email);
                }
            }
        }

        [TestMethod]
        public void GetLocationsForList_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            ListResult lists = mc.GetLists();

            //  For each list
            foreach(var list in lists.Data)
            {
                Debug.WriteLine("Information for " + list.Name);

                //  Get the location data for each list:
                List<SubscriberLocation> locations = mc.GetLocationsForList(list.Id);

                //  Write out each of the locations:
                foreach(var location in locations)
                {
                    Debug.WriteLine("Country: {0} - {2} users, accounts for {1}% of list subscribers", location.Country, location.Percent, location.Total);
                }
            }
        }
    }
}
