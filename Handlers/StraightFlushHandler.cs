using System;
using System.Collections.Generic;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Handlers
{
    public class StraightFlushHandler : BaseHandler
    {
        public override void calc(PlayerHand player)
        {
            if (isHand(player))
            {
                player.HandStrength = HandStrength.StraightFlush;
                player.HandValue = Convert.ToInt16(HandStrength.StraightFlush) + getTopValue(player);
            }
        }

        public override bool isHand(PlayerHand player)
        {
            return areSameSuite(player) && areSequential(player);
        }

    }
}
