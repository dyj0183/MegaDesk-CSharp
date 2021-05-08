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
        public AddQuote()
        {
            InitializeComponent();
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
    }
}
