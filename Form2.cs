using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace GUI_Hangman__181014080_
{
    
    public partial class GAME : Form
    {
        public int life  = 6;
        static string THE_WORD;
        bool open = false;
        char[] work = new char[100];

        
        SpeechSynthesizer speech;
        private string GetWord()
        {
            int i = 0;
            string words = Properties.Resources.words;
            List<string> MARK = new List<string>();
            string a = "";
            char[] fun = new char[100];
            foreach (char word in words)
            {

                if (word == '\n')
                {
                    for (int j = 0; j < i - 1; j++)
                    {
                        a += fun[j];
                    }
                    MARK.Add(a);
                    a = "";
                    i = 0;
                }
                else
                {
                    fun[i] = word;
                    i++;
                }
                
            }
            Random rnd = new Random();
            int ind = rnd.Next(0, MARK.Count);

            return MARK[ind];
        }
        public GAME()
        {
            InitializeComponent();
            
            speech = new SpeechSynthesizer();
        }

        private void GAME_Load(object sender, EventArgs e)
        {
            THE_WORD = GetWord();
            char[] guess = new char[THE_WORD.Length];
            pictureBox1.Image = Properties.Resources.Image1;
            for (int i = 0; i < THE_WORD.Length; i++)
            {
                guess[i] = '*';
                label1.Text = label1.Text + guess[i] + " ";
                work[i] = '*';
            }

            speech.SelectVoiceByHints(VoiceGender.Female);
            speech.SpeakAsync("Guess The Word");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainManu obj = new MainManu();
            this.Hide();
            obj.ShowDialog();
        }
        private void change_Image()
        {

            life = (life - 1);
            if (life == 5)
            {
                pictureBox1.Image = Properties.Resources.Image2;
            }
            else if (life == 4)
            {
                pictureBox1.Image = Properties.Resources.Image3;
            }
            else if (life == 3)
            {
                pictureBox1.Image = Properties.Resources.Image4;
            }
            else if (life == 2)
            {
                pictureBox1.Image = Properties.Resources.Image5;
            }
            else if (life == 1)
            {
                pictureBox1.Image = Properties.Resources.Image6;
            }
            else if (life == 0)
            {
                pictureBox1.Image = Properties.Resources.Image7;
            }
            else
            {

            }
        }
        private void check_WIN()
        {
            int k = 0;
            for(int i = 0; i < THE_WORD.Length; i++)
            {
                if (work[i] == '*')
                {
                    k++;
                }
                
            }
            if(k==0)
            {
                speech.SelectVoiceByHints(VoiceGender.Female);
                
                speech.SpeakAsync("!YOU WIN!");
                DialogResult DR = MessageBox.Show("WOW YOU WON!!\nLet's Teplay", "!!!Congratulations!!!!", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    this.Hide();
                    GAME obj = new GAME();
                    obj.ShowDialog();
                }
                else
                {
                    this.Hide();
                    MainManu obj = new MainManu();
                    obj.ShowDialog();
                }
            }
        }
        private void check_lose()
        {
            if (life == 0)
            {

                speech.SelectVoiceByHints(VoiceGender.Female);
                speech.SpeakAsync("HANGMAN");
                label1.Text = THE_WORD.ToUpper();
                DialogResult DR = MessageBox.Show("Replay?", "oops sorry you lost!!", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    this.Hide();
                    GAME obj = new GAME();
                    obj.ShowDialog();
                }
                else
                {
                    this.Hide();
                    MainManu obj = new MainManu();
                    obj.ShowDialog();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(open == false)
            {

                label1.Text = "";
                open = true;
            }
            char[] guess = new char[THE_WORD.Length];
            Button button = (Button)sender;
            bool isOk = false;
            char guessed = Convert.ToChar(button.Text);
            for (int i = 0; i < THE_WORD.Length; i++)
            {
                if(THE_WORD[i] == (guessed+32))
                {
                    work[i] = guessed;
                    isOk = true;
                }
            }
            if (isOk == false)
            {
                change_Image();
            }
            label1.Text = "";
            for (int i = 0; i < THE_WORD.Length; i++)
            {
                label1.Text += Convert.ToString(work[i])+" ";
            }
            button.Enabled = false;
            check_lose();
            check_WIN();

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
