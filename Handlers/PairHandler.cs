using System;
using System.Collections.Generic;
using System.Linq;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Handlers
{
    public class PairHandler : BaseHandler
    {
        public override void calc(PlayerHand player)
        {
            if (isHand(player))
            {
                player.HandStrength = HandStrength.Pair;
                player.HandValue = Convert.ToInt16(HandStrength.Pair) + GetPairValue(player);
            }
        }

        public override bool isHand(PlayerHand player)
        {
            return player.Cards.GroupBy(x => x.Rank)
                .Count(group => group.Count() == 2) == 1;
        }

        public int GetPairValue(PlayerHand player)
        {
            var pair = player.Cards.GroupBy(x => x.Rank)
                .FirstOrDefault()
                .Select(x => x.CardValue);
                
            return pair.FirstOrDefault();
        }
    }
}
