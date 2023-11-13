using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddressbookTestDataGenerators.Model.WriteToFiles
{
    public class WriteToXmlFile : IWriteToFile
    {
        public void WriteModelsToFile<T>(List<T> models, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<T>)).Serialize(writer, models);
        }
    }
}
