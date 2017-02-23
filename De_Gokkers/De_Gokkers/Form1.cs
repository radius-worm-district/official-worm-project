using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Gokkers
{
    public partial class Form1 : Form
    {
        public Player Charar;
        public Form1()
        {
            InitializeComponent();
            Charar = new Player();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            label14.Text = "sietse heeft daarna {0} geld" + Charar.MyBet.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Start_Button.Enabled = false;
            Undergroundworm[] Racers = new Undergroundworm[5];

            for (int i = 0; i < Racers.Length; i++)
            {
                Racers[i] = new Undergroundworm();
            }
            Racers[0].MyPictureBox = Worm;
            Racers[1].MyPictureBox = WormOne;
            Racers[2].MyPictureBox = WormSpecial;
            Racers[3].MyPictureBox = WormTwo;
            Racers[4].MyPictureBox = WormThree;
            do
            {
                for (int i = 0; i < Racers.Length; i++)
                {
                    Racers[i].Run();
                    Application.DoEvents();
                }
            } while (true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
