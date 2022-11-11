using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WpfApp2.Models
{
    public class JsonReader
    {
        private readonly string fileName = "C:\\Users\\intern\\Desktop\\data.json";

        private List<Data> data;

        public JsonReader()
        {
            this.data = new List<Data>();
        }

        public List<Data> Data { get => data; set => data = value; }

        public void ReadJson()
        {
            string jsonString = File.ReadAllText(fileName);
            Console.WriteLine(jsonString);
            data = JsonConvert.DeserializeObject<List<Data>>(jsonString);
        }

        public void ReadJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            data = JsonConvert.DeserializeObject<List<Data>>(jsonString);
        }
    }
}
