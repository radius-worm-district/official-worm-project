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
        public Player Sietse;
        public Player Fer;
        public Player Fedde;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            Undergroundworm[] Racers = new Undergroundworm[5];
            
            Start_Button.Enabled = false;

            for (int i = 0; i < Racers.Length; i++)
            {
                Racers[i] = new Undergroundworm();
            }

            Racers[0].MyPictureBox = Worm;
            Racers[0].MyLabel = WedLblWorm1;
            Racers[1].MyPictureBox = WormOne;
            Racers[1].MyLabel = WedLblWorm2;
            Racers[2].MyPictureBox = WormSpecial;
            Racers[2].MyLabel = WedLblWorm3;
            Racers[3].MyPictureBox = WormTwo;
            Racers[3].MyLabel = WedLblWorm4;
            Racers[4].MyPictureBox = WormThree;
            Racers[4].MyLabel = WedLblWorm5;

            Racers[2].Special = true;

            for (int i = 0; i < Racers.Length; i++)
            {
                Racers[i].TakeStartingPosition();
                Racers[i].MyLabel.Text = Racers[i].ResetLabels();
                Racers[i].Finished = false;
            }

            int finishedWorms = 0;
            int temp = 1;
            bool finish = false;
            Random r = new Random();

            do
            {
                do
                {
                    Application.DoEvents();
                    for (int i = 0; i < Racers.Length; i++)
                    {
                        if (Racers[i].Finished == false)
                        {
                            if (Racers[i].Special == true)
                            {
                                finish = Racers[i].Run(r.Next(0, 6));
                            }
                            else
                            {
                                finish = Racers[i].Run(r.Next(1, 5));
                            }

                            if (finish == true)
                            {
                                Racers[i].Place = temp++;
                                Racers[i].MyLabel.Text = Racers[i].UpdatePlaceLabels(i, Racers[i].Place);
                                Racers[i].Finished = true;
                                finishedWorms++;
                            }
                        }
                    }
                } while (finish != true);
            } while (finishedWorms != 5);


            Start_Button.Enabled = true;

        }

        // Players status Begin

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Sietse = new Player();

            Sietse.Name = "Sietse";
            PlayerSietse.Text = "Sietse heeft " + Sietse.Cash + " geld.";

            if (PlayerSietse.Checked == true)
            {
                PlayerWedName.Text = Sietse.Name + " wed";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PlayerFedde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
