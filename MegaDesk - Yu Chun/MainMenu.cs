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
    public partial class MainMenu : Form
    {
        // properties
        public FileService FileService { get; set; }

        // constructor
        public MainMenu()
        {
            InitializeComponent();

            // create a new object of FileService, as soon as the FileService object is created, it will load all the data (see FileService constructor)
            FileService = new FileService(); 
        }

        // methods
        private void btnAddNewQuote_Click(object sender, EventArgs e)
        {
            var addQuote = new AddQuote(FileService);
            addQuote.Tag = this; // this refers to the current object which is the main menu
            addQuote.Show(); // pop up a new addQuote window
            this.Hide(); // hide the mainMenu after the addQuote window pops up


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // this will kill the app, and remove everything
        }

        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            var viewQuotes = new ViewAllQuotes();
            viewQuotes.Tag = this;
            viewQuotes.Show();
            this.Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            var searchQuotes = new SearchQuotes();
            searchQuotes.Tag = this;
            searchQuotes.Show();
            this.Hide();
        }
    }
}
