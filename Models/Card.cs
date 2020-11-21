using System;
using ThreeHandPoker.Enums;

namespace ThreeHandPoker.Models
{
    public class Card
    { 
        public string Rank { get; set; }
        public int CardValue { get; set; }
        public CardSuite Suite { get; set; }
    }
}
