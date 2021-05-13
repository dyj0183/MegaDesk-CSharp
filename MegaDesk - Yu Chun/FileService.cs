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

        // methods
        public FileService()
        {
            LoadAllData();
            
        }

        public List<DeskQuote> GetQuotes()
        {
            if (_quotes == null)
            {
                LoadAllData();
            }

            return _quotes;
        }

        public void AddQuote(DeskQuote deskQuote)
        {
            _quotes.Add(deskQuote);
            SaveAllData();
        }

        private void LoadAllData()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                _quotes = JsonSerializer.Deserialize<List<DeskQuote>>(data);
            } 
            else
            {
                _quotes = new List<DeskQuote>();

            }
        }
        private void SaveAllData()
        {
            string myJson = JsonSerializer.Serialize(_quotes);

          
             // create a file to write to
             File.WriteAllText(path, myJson);
            

          

            Console.WriteLine(myJson);

        }


    }
}
