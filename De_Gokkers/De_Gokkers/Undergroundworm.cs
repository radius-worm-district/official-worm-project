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
        public Random Randomizer = new Random();               //Een instantie van Random (= Willekeurig) 
        public bool Special = false;

        public bool Run()
        {
            int distance;
            if (Special == true)
            {
                distance = Randomizer.Next(10, 16);
                MyPictureBox.Location = new Point(
                MyPictureBox.Location.X + distance, MyPictureBox.Location.Y);
            }
            else
            {
                distance = Randomizer.Next(8, 10);
                MyPictureBox.Location = new Point(
                MyPictureBox.Location.X + distance, MyPictureBox.Location.Y);
            }
            if (MyPictureBox.Location.X == RaceTrackLength)
            {
                return true;
            }
            return false;
            //Ga willekeurig 1, 2, 3 of 4 posities naar voren.
            //Werk de positie van PictureBox bij op het formulier.
            //Geef de waarde ‘true’ terug als ik de race win.
        }

        public void TakeStartingPosition()
        {
            MyPictureBox.Location = new Point(1, MyPictureBox.Location.Y);
            //Wijzig mijn locatie naar de startlijn.         
        }

    }
}
