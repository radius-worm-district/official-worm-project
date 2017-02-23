using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Gokkers
{
    public class Undergroundworm
    {
        public int RaceTrackLength = 1130;
        public PictureBox MyPictureBox = null;
        public Label MyLabel = null;
        public Random Randomizer = new Random();               //Een instantie van Random (= Willekeurig) 
        public bool Special = false;
        public int Place;
        public bool Finished;

        public bool Run(int distance)
        {


            if (MyPictureBox.Location.X >= RaceTrackLength)
            {
                MyPictureBox.Location = new Point(
                MyPictureBox.Location.X, MyPictureBox.Location.Y);
                return true;
            }
            else
            {
                MyPictureBox.Location = new Point(
                MyPictureBox.Location.X + distance, MyPictureBox.Location.Y);
                return false;
            }
            
            //Ga willekeurig 1, 2, 3 of 4 posities naar voren.
            //Werk de positie van PictureBox bij op het formulier.
            //Geef de waarde ‘true’ terug als ik de race win.
        }

        public void TakeStartingPosition()
        {
            MyPictureBox.Location = new Point(1, MyPictureBox.Location.Y);
            //Wijzig mijn locatie naar de startlijn.         
        }

        public string UpdatePlaceLabels(int i, int place)
        {
            string update = "Worm " + ++i + " is geeindigd op plek " + place + ".";
            return update;
        }

        public string ResetLabels()
        {
            string update = "De race is bezig!";
            return update;
        }
    }
}
