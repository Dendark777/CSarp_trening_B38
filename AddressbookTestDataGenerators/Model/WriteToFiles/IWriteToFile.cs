using AddressbookWebTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookTestDataGenerators.Model.WriteToFiles
{
    public interface IWriteToFile
    {
        public void WriteModelsToFile<T>(List<T> models, StreamWriter writer);
    }
}
