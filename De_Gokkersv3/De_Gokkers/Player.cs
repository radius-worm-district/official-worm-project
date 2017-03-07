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
    public class Player
    {

        public string Name;  // De naam van de gokker
        public Bet MyBet;    // Een instantie van Bet()
        public int Cash;     // Het saldo van de gokker

        public string UpdateLabels(string Name, int Cash)
        {

            string updatebutton = Name + " heeft " + Cash + ".";

            return updatebutton;
            

            //Verander mijn label in de omschrijving van mijn weddenschap.  DONE
            //Verander de label op mijn radioknop zodat deze mijn saldo laat zien. DONE
            //(Bijv. “Lidy heeft 43 euro.”) DONE
        }

        public bool PlaceBet(int amount, int worm)
        {
            if(Cash >= amount )
            {
                MyBet.Worm = worm;
                MyBet.Amount = amount;
                return true;
            }
            else
            {
                return false;
            }

            //Plaats een nieuwe weddenschap en sla het op in de variabele MyBet.
            //Retourneer een true als de gokker genoeg geld heeft om te wedden.

            //Onderstaande regel staat er tijdelijk om foutmeldingen te voorkomen. 
            //Haal deze regel later weg.

        }

        public void ClearBet()
        {
            MyBet.hasBetted = false;
            MyBet.Amount = 0;
            MyBet.Worm = 0;
            //Maak de weddenschap leeg.

        }

        public int Collect(int Winner)
        {
            int winnings =  MyBet.PayOut(Winner);

            Cash += winnings;
            //Betaal mijn weddenschap uit.
            //Maak mijn weddenschap leeg.
            //Werk mijn labels bij.
            return winnings;
        }

    }
}
