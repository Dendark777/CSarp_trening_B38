using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressbookTestDataGenerators.Model.WriteToFiles;

namespace AddressbookTestDataGenerators.Model.WriteModel
{
    public interface IWriteModels
    {
        public void WriteModels(int count, IWriteToFile writeToFile, StreamWriter writer);
    }
}
