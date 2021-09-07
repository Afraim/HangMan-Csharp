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
    public partial class MainManu : Form
    {
        public MainManu()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GAME obj = new GAME();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help obj = new Help();
            this.Hide();
            obj.ShowDialog();
        }
    }
}
