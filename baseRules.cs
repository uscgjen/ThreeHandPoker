using System;
using System.Linq;
using ThreeHandPoker.Interfaces;
using ThreeHandPoker.Models;

namespace ThreeHandPoker
{
    public abstract class baseRules : IHandRules
    {
        public abstract void calc(PlayerHand player);
        public abstract bool isHand(PlayerHand player);

        public bool areSameRank(PlayerHand player)
        {
            var currentrank = player.Cards[0].Rank;
            foreach(var card in player.Cards)
            {
                if (card.Rank != currentrank)
                    return false;
            }
            return true;
        }

        public bool areSameSuite(PlayerHand player)
        {
            var currentSuite = player.Cards[0].Suite;
            foreach (var card in player.Cards)
            {
                if (card.Suite != currentSuite)
                    return false;
            }
            return true;
        }

        public bool areSequential(PlayerHand player)
        {
            var sortedList = player.Cards.OrderBy(o => o.CardValue).Select(x => x);
            int currentRank = 0;
            foreach(var card in sortedList)
            {
                if(currentRank > 0)
                {
                    if (card.CardValue != (currentRank + 1))
                    {
                        return false;
                    }
                }
                currentRank = card.CardValue;
            }
            return true;
        }

        public int getTopValue(PlayerHand player)
        {
            return player.Cards
                .OrderByDescending(x => x.CardValue)
                .Select(x => x.CardValue)
                .FirstOrDefault();
        }

        
    }
}