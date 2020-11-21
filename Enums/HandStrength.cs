using System;
namespace ThreeHandPoker.Enums
{
    public enum HandStrength
    {
        StraightFlush = 100,
        ThreeofKind = 80,
        Straight = 60,
        Flush = 40,
        Pair = 20,
        HighCard = 1,
        None = 0
    }
}
