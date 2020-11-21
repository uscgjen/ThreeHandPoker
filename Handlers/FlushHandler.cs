using System;
using System.Collections.Generic;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Handlers
{
    public class FlushHandler : BaseHandler
    {
        public override void calc(PlayerHand player)
        {
            if (isHand(player))
            {
                player.HandStrength = HandStrength.Flush;
                player.HandValue = Convert.ToInt16(HandStrength.Flush) + getTopValue(player);
            }
        }

        public override bool isHand(PlayerHand player)
        {
            return areSameSuite(player);
        }
    }
}
