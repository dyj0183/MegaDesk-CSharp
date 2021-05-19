using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk___Yu_Chun
{
    public partial class AddQuote : Form
    {
        public FileService FileService { get; set; }

        // constructor
        // FileService object was passed from MainMenu which is a higher level
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
            this.Close(); // if customer clicked on "cancel", it will close the form which will call the Show() MainMenu function above
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
            deskQuote.TotalPrice = deskQuote.GetQuotePrice();

            // use a file service class to manage all the file writing and adding
            FileService.AddQuote(deskQuote);

            // to see the result, testing purpose
            Console.WriteLine(deskQuote.GetQuotePrice()); 

            this.Close(); // if customer clicked on "cancel", it will close the form which will call the Show() MainMenu function above
        }
    }
}
