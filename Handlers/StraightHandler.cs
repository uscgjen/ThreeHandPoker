using System;
using System.Collections.Generic;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Interfaces;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Handlers
{
    public class StraightHandler : BaseHandler
    {
        public override void calc(PlayerHand player)
        {
            if (isHand(player))
            {
                player.HandStrength = HandStrength.Straight;
                player.HandValue = Convert.ToInt16(HandStrength.Straight) + getTopValue(player);
            }
        }

        public override bool isHand(PlayerHand player)
        {
            return areSequential(player);
        }
    }
}
