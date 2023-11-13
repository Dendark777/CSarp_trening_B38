using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AddressbookWebTest.Tests.Groups
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header= parts[1],
                    Footer= parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }
        
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        [Test]
        public void BadGroupCreationTest()
        {
            var group = new GroupData(name: "a`a", header: "", footer: "");

            List<GroupData> oldGroupList = _applicationManager.Group.GetGroupList();

            _applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, _applicationManager.Group.GetGroupCount());

            List<GroupData> newGroupList = _applicationManager.Group.GetGroupList();
            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }
}
