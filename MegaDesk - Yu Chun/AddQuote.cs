using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json; // use to work with the json file 
using System.Text.Json.Serialization; 
using System.IO; // use to create a new file

namespace MegaDesk___Yu_Chun
{
    public partial class AddQuote : Form
    {
        public FileService FileService { get; set; }

        // constructor
        public AddQuote(FileService fs)
        {
            InitializeComponent();

            FileService = fs;

            // put this here because we want the customers to see the list as soon as they start the app
            // For Desktop Materials
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            deskMaterialComboBox.DataSource = materials;
            // For Delivery Types
            List<Delivery> deliveryTypes = Enum.GetValues(typeof(Delivery)).Cast<Delivery>().ToList();
            deskDeliveryComboBox.DataSource = deliveryTypes;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainMenu)this.Tag).Show(); // we define the tag in mainMenu, but we still need to tell the program about the type (MainMenu)
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // if customer clicked on "cancel", it will close the form which will call the function above
        }

        private void DeskMaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnGetQuote_Click(object sender, EventArgs e)
        {
            // create new Desk object and save user's input into it
            Desk desk = new Desk();
            desk.Width = widthUpDown.Value;
            desk.Depth = depthUpDown.Value;
            desk.NumberOfDrawers = drawerUpDown.Value;
            desk.SurfaceMaterial = (DesktopMaterial)deskMaterialComboBox.SelectedItem;

            // create new DeskQuote object and save user's input into it
            DeskQuote deskQuote = new DeskQuote();
            deskQuote.QuoteDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            deskQuote.CustomerName = customerName.Text;
            deskQuote.DeliveryType = (Delivery)deskDeliveryComboBox.SelectedItem;
            deskQuote.Desk = desk; // comes from above, desk object

            // use a file service class
            FileService.AddQuote(deskQuote);

            //saveToJsonFile(deskQuote); // save the new deskQuote into the json file

            Console.WriteLine(deskQuote.GetQuotePrice()); // don't I need to pass "desk" object into it?
        }

        // this function serializes data from object to json format and append it into the json file
        private void saveToJsonFile(DeskQuote deskQuote)
        {
            string path = @"C:\Users\dyj0183\source\repos\MegaDesk - Yu Chun\MegaDesk - Yu Chun\bin\Debug\quotes.json";
            string myJson = JsonSerializer.Serialize(deskQuote);

            // check if the file exists in the subfolder, if not, then create one
            if (!File.Exists(path))
            {
                // create a file to write to
                File.WriteAllText(path, myJson);
            }

            // If the file already exists, then keep adding data to it
            File.AppendAllText(path, myJson); // this works, however, it will keep rewritting instead of keep adding
            File.AppendAllText(path, ", "); // this works, however, it will keep rewritting instead of keep adding

            Console.WriteLine(myJson);
        }
    }
}
