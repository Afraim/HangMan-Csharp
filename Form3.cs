using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Hangman__181014080_
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome to Md. Afraim Zahangir's \n\n\tHANGMAN\nA basic guess the word game.\nAll the words are Coding and CSE related.\nThats All the help I have.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainManu obj = new MainManu();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
