using System;
using System.Collections.Generic;
using ThreeHandPoker.Enums;

namespace ThreeHandPoker.Models
{
    public class PlayerHand
    {
        public int PlayerNumber { get; set; }
        public List<Card> Cards = new List<Card>();
        public int HandValue { get; set; }
        public HandStrength HandStrength { get; set; }
        public bool Winner { get; set; } = false;

        public bool IsHandValid()
        {
            if (Cards.Count == 3)
                return true;

            return false;
        }

        public void WriteIfWinner()
        {
            if(Winner)
            {
                Console.WriteLine($"{PlayerNumber} {HandStrength}");
            }
        }
    }
}
