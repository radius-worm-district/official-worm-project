﻿using System;
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
        public Player Sietse = new Player();
        public Player Fedde = new Player();
        public Player Fer = new Player();
        public int count;
        public int wormChoice;
        public int StartButtonStatus = 0;

        public Form1()
        {
            InitializeComponent();
            Sietse.Cash = 100;
            Fer.Cash = 100;
            Fedde.Cash = 100;
            PlayerSietse.Checked = true;
            PlayerFedde.Checked = true;
            PlayerFer.Checked = true;
            PlayerFedde.Checked = false;
            PlayerFer.Checked = false;
            PlayerSietse.Checked = false;

            Bet BetSietse = new Bet();
            Sietse.MyBet = BetSietse;
            Sietse.MyBet.Bettor = Sietse;
            Bet BetFedde = new Bet();
            Fedde.MyBet = BetFedde;
            Fedde.MyBet.Bettor = Fedde;
            Bet BetFer = new Bet();
            Fer.MyBet = BetFer;
            Fer.MyBet.Bettor = Fer;

            count = Convert.ToInt32(Inzet_Euro.Value);
            wormChoice = Convert.ToInt32(Choose_Worm.Value);
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {

            Undergroundworm[] Racers = new Undergroundworm[5];

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

            Start_Button.Enabled = false;
            Wed_Button.Enabled = true;
            Inzet_Euro.Enabled = true;
            Choose_Worm.Enabled = true;

            PlayerFedde.Enabled = true;
            PlayerFer.Enabled = true;
            PlayerSietse.Enabled = true;

            if (StartButtonStatus == 0)
            {
                PlayerFedde.Enabled = false;
                PlayerFer.Enabled = false;
                PlayerSietse.Enabled = false;
                Wed_Button.Enabled = false;
                Inzet_Euro.Enabled = false;
                Choose_Worm.Enabled = false;

                Sietse.Cash -= Sietse.MyBet.Amount;
                Fer.Cash -= Fer.MyBet.Amount;
                Fedde.Cash -= Fedde.MyBet.Amount;
                PlayerSietse.Text = Sietse.UpdateLabels("Sietse", Sietse.Cash);
                PlayerFer.Text = Fer.UpdateLabels("Fer", Fer.Cash);
                PlayerFedde.Text = Fedde.UpdateLabels("Fedde", Fedde.Cash);

                for (int i = 0; i < Racers.Length; i++)
                {
                    Racers[i].MyLabel.Text = Racers[i].ResetLabels(StartButtonStatus);
                }

                int finishedWorms = 0;
                int temp = 1;
                bool finish = false;
                Random r = new Random();
                int winner = 0;

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
                            if (Racers[i].Place == 1)
                            {
                                winner = i + 1;
                            }
                        }
                    } while (finish != true);
                } while (finishedWorms != 5);

                //payout collect

                string test = Convert.ToString(winner);
                if(Sietse.MyBet.Worm == winner) {
                    label11.Text = "Sietse heeft gewonnen " + Sietse.Collect(winner) + " euro gewonnen.";
                }
                else
                {
                    label11.Text = "Sietse heeft " + Sietse.MyBet.Amount + " euro verloren.";
                }
                if (Fer.MyBet.Worm == winner)
                {
                    label10.Text = "Fer heeft gewonnen " + Fer.Collect(winner) + " euro gewonnen.";
                }
                else
                {
                    label10.Text = "Fer heeft heeft " + Fer.MyBet.Amount + " euro verloren.";
                }
                if (Fedde.MyBet.Worm == winner)
                {
                    label9.Text = "Fedde heeft gewonnen " + Fedde.Collect(winner) + " euro gewonnen.";
                }
                else
                {
                    label9.Text = "Fedde heeft heeft " + Fedde.MyBet.Amount + " euro verloren.";
                }

                Start_Button.Text = "Reset De Race";
                StartButtonStatus++;
            }

            else if (StartButtonStatus == 1)
            {
                for (int i = 0; i < Racers.Length; i++)
                {
                    Racers[i].TakeStartingPosition();
                    Racers[i].MyLabel.Text = Racers[i].ResetLabels(StartButtonStatus);
                    Racers[i].Finished = false;
                }

                Sietse.ClearBet();
                Fer.ClearBet();
                Fedde.ClearBet();
                label14.Text = "Sietse" + Sietse.MyBet.GetDescription();
                label13.Text = "Fer" + Fer.MyBet.GetDescription();
                label12.Text = "Fedde" + Fedde.MyBet.GetDescription();
                label11.Text = "Resultaten zijn nog niet bekend.";
                label10.Text = "Resultaten zijn nog niet bekend.";
                label9.Text = "Resultaten zijn nog niet bekend.";
                Start_Button.Text = "Start De Race";

                StartButtonStatus = 0;

                PlayerSietse.Checked = true;
                PlayerFedde.Checked = true;
                PlayerFer.Checked = true;
                PlayerFedde.Checked = false;
                PlayerFer.Checked = false;
                PlayerSietse.Checked = false;

            }

            Start_Button.Enabled = true;

        }

        // Players status Begin

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(PlayerSietse.Checked == true)
            {
                PlayerSietse.Text = Sietse.UpdateLabels("Sietse", Sietse.Cash);
                PlayerWedName.Text = "Sietse wed";
            }
            else
            {
                PlayerSietse.Text = Sietse.UpdateLabels("Sietse", Sietse.Cash);
                PlayerWedName.Text = "Geen player gekozen";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayerFer.Checked == true)
            {
                PlayerFer.Text = Fer.UpdateLabels("Fer", Fer.Cash);
                PlayerWedName.Text = "Fer wed";
            }
            else
            {
                PlayerFer.Text = Fer.UpdateLabels("Fer", Fer.Cash);
                PlayerWedName.Text = "Geen player gekozen";
            }
        }

        private void PlayerFedde_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayerFedde.Checked == true)
            {
                
                PlayerFedde.Text = Fedde.UpdateLabels("Fedde", Fedde.Cash);
                PlayerWedName.Text = "Fedde wed";
            }
            else
            {
                PlayerFedde.Text = Fedde.UpdateLabels("Fedde", Fedde.Cash);
                PlayerWedName.Text = "Geen player gekozen";
            }
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

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void Inzet_Euro_ValueChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(Inzet_Euro.Value);
        }

        private void Choose_Worm_ValueChanged(object sender, EventArgs e)
        {
            wormChoice = Convert.ToInt32(Choose_Worm.Value);
        }

        private void Wed_Button_Click(object sender, EventArgs e)
        {
                if(PlayerFedde.Checked == true)
                {

                    Fedde.PlaceBet(count, wormChoice);
                    PlayerFedde.Text = Fedde.UpdateLabels("Fedde", Fedde.Cash);
                    Fedde.MyBet.hasBetted = true;

                    if(Fedde.MyBet.hasBetted == true)
                    {
                        label12.Text = "Fedde" + Fedde.MyBet.GetDescription();
                    }

                }
                else if (PlayerFer.Checked == true) 
                {
                    Fer.PlaceBet(count, wormChoice);
                    PlayerFer.Text = Fer.UpdateLabels("Fer", Fer.Cash);
                    Fer.MyBet.hasBetted = true;

                    if (Fer.MyBet.hasBetted == true)
                    {
                        label13.Text = "Fer" + Fer.MyBet.GetDescription();
                    }
                }
                else if (PlayerSietse.Checked == true)
                {
                    Sietse.PlaceBet(count, wormChoice);
                    PlayerSietse.Text = Sietse.UpdateLabels("Sietse", Sietse.Cash);
                    Sietse.MyBet.hasBetted = true;

                    if (Sietse.MyBet.hasBetted == true)
                    {
                        label14.Text = "Sietse" + Sietse.MyBet.GetDescription();
                    }

            }
        }


    }
}
