using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressbookTestDataGenerators.Model.WriteToFiles
{
    internal class WriteToJsonFile : IWriteToFile
    {
        public void WriteModelsToFile<T>(List<T> models, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(models, Formatting.Indented));
        }
    }
}
