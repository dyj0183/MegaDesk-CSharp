using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // use to work with the json file 
using System.Text.Json.Serialization;
using System.IO; // use to create a new file

namespace MegaDesk___Yu_Chun
{
    public class FileService
    {
        // constants
        public const string path = @"C:\Users\dyj0183\source\repos\MegaDesk - Yu Chun\MegaDesk - Yu Chun\bin\Debug\quotes.json";
        private List<DeskQuote> _quotes;

        // constructor, as soon as the FileService is created, load all the data into _quotes
        public FileService()
        {
            LoadAllData();
        }

        // methods
        // get all the quotes from quotes.json file, this is like a getter in this class
        public List<DeskQuote> GetQuotes()
        {
            if (_quotes == null)
            {
                LoadAllData();
            }

            return _quotes;
        }

        // add a new quote to the quote list, this is like a setter in this class
        public void AddQuote(DeskQuote deskQuote)
        {
            _quotes.Add(deskQuote);
            SaveAllData(); 
        }

        // retrieve all the data from quotes.json file, use "private" to protect this method
        private void LoadAllData()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path); // data will be in json format
                _quotes = JsonSerializer.Deserialize<List<DeskQuote>>(data); // convert from json to List<DeskQuote>
            } 
            else
            {
                // if the file doesn't even exist, just create a new empty list
                _quotes = new List<DeskQuote>();
            }
        }

        // write all the data into the quotes.json file, use "private" to protect this method
        private void SaveAllData()
        {
            // convert the _quotes which is List<DeskQuote> format to json format
            string myJson = JsonSerializer.Serialize(_quotes);

            // create a file and write the json data into it
            File.WriteAllText(path, myJson);
           
            // console out to see the result when testing
            Console.WriteLine(myJson);
        }
    }
}
