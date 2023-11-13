using AddressbookTestDataGenerators.Model;
using AddressbookTestDataGenerators.Model.WriteModel;
using AddressbookTestDataGenerators.Model.WriteToFiles;
using AddressbookWebTest;
using AddressbookWebTest.Tests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
namespace AddressbookTestDataGenerators
{
    public class Program
    {
        private static Dictionary<string, IWriteModels> _models = new Dictionary<string, IWriteModels>()
        {
            { "group", new WriteGroups()},
            { "contacts", new WriteGroups()}

        };
        private static Dictionary<string, IWriteToFile> _writeFormat = new Dictionary<string, IWriteToFile>()
        {
            { "xml", new WriteToXmlFile()},
            { "json", new WriteToJsonFile()}

        };
        static void Main(string[] args)
        {
            if (!_models.ContainsKey(args[0]))
            {
                Console.WriteLine($"Не правильно указана модель для записи в файл {args[0]}, правильные {string.Join(", ",_models.Keys)}");
                return;
            }
            if (!_writeFormat.ContainsKey(args[3]))
            {
                Console.WriteLine($"Не правильно указан формат {args[3]}, правильные {string.Join(", ", _writeFormat.Keys)}");
                return;
            }

            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new(args[2]);
            _models[args[0]].WriteModels(count, _writeFormat[args[3]], writer);
            writer.Close();
        }

    }
}
