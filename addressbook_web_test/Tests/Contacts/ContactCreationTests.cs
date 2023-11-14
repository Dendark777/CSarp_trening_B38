using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AddressbookWebTest.Tests.Contacts
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContactList = ContactData.GetAll();

            _applicationManager.Contact.Create(contact);
            List<ContactData> newContactList = ContactData.GetAll();

            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

        }
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Company = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }


        [Test]
        public void ContactCreationTestNoParameter()
        {
            List<ContactData> oldContactList = ContactData.GetAll();
            ContactData contact = new ContactData(GenerateRandomString(30), GenerateRandomString(30))
            {
                Company = GenerateRandomString(100),
                Address = GenerateRandomString(100)
            };
            _applicationManager.Contact.Create(contact);
            List<ContactData> newContactList = ContactData.GetAll();

            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

        }
    }
}
