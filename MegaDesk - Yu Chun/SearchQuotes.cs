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
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {
           
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainMenu)this.Tag).Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
