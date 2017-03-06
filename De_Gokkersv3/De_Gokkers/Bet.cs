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
    public class Bet
    {
        public int Amount; //Het bedrag van de weddenschap.
        public int Worm; //Het nummer van de hond waarop weddenschap is afgesloten.
        public Player Bettor; //De gokkker die gewed heeft.
        public int Cash;
        public bool hasBetted = false;
        

        public string GetDescription()
        {
            if(hasBetted == true)
            {
                string betted = Bettor.Name + " heeft " + Amount + " ingezet op worm " + Worm;
                return betted;
            }
            else if (Amount == 0 && Worm == 0)
            {
                string notBetted = Bettor.Name + " heeft geen weddeschap gedaan.";
                return notBetted;
            }
            else
            {
                return null;
            }
            //Retourneer een string die aangeeft wie de weddenschap heeft gedaan,
            //voor welk bedrag er is gewed en op welke hond er is gewed.
            //Bijv. “Sietse wedt 8 euro op hond 4”.
            //Als het bedrag 0 is, is er geen weddenschap geplaatst.
            //De string die dan geretourneerd wordt is bijv.
            //“Sietse heeft geen weddenschap geplaatst.”)
        }

        public int PayOut(int Winner)
        {

            return 1;
            //De parameter van deze methode is de winnaar van de race.
            //Als de hond gewonnen heeft, retourneer dan het bedrag dat gewed is
            //Anders, retourneer het tegengestelde van het gewedde bedrag.
        }
    }
}
