using System;
using System.Collections.Generic;
using System.Linq;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Handlers
{
    public class ThreeofKindHandler : BaseHandler
    {
        public override void calc(PlayerHand player)
        {
            if(isHand(player))
            {
                player.HandStrength = HandStrength.ThreeofKind;
                player.HandValue = Convert.ToInt16(HandStrength.ThreeofKind) + player.Cards.First().CardValue;
            }
        }

        public override bool isHand(PlayerHand player)
        {
            return areSameRank(player);
        }
    }
}
