using AddressbookTestDataGenerators.Model.WriteToFiles;
using AddressbookWebTest.Tests;
using AddressbookWebTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookTestDataGenerators.Model.WriteModel

{
    public class WriteContacts : IWriteModels
    {
        public void WriteModels(int count, IWriteToFile writeToFile, StreamWriter writer)
        {
            List<ContactData> contacts = new();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData
                {
                    FirstName = TestBase.GenerateRandomString(10),
                    MiddleName = TestBase.GenerateRandomString(10),
                    LastName = TestBase.GenerateRandomString(10),
                    Company = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(10)
                });
            }
            writeToFile.WriteModelsToFile(contacts, writer);
        }
    }
}
