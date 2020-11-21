using System.Collections.Generic;
using ThreeHandPoker.Models;

namespace ThreeHandPoker.Interfaces
{
    public interface IHandRules
    {
         bool isHand(PlayerHand player);
         void calc(PlayerHand player);
    }
}