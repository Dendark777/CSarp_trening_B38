using AddressbookTestDataGenerators.Model.WriteToFiles;
using AddressbookWebTest;
using AddressbookWebTest.Tests;
using System.Collections.Generic;
using System.IO;

namespace AddressbookTestDataGenerators.Model.WriteModel
{
    public class WriteGroups : IWriteModels
    {
        public void WriteModels(int count, IWriteToFile writeToFile, StreamWriter writer)
        {
            List<GroupData> groups = new();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            writeToFile.WriteModelsToFile(groups, writer);
        }
    }
}
