using System;
using System.Collections.Generic;
using System.Linq;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Handlers;
using ThreeHandPoker.Models;

namespace ThreeHandPoker
{
    public class PlayerHelper
    {
        public void RankPlayers(List<PlayerHand> players)
        {
            StraightFlushHandler straightFlushHandler = new StraightFlushHandler();
            ThreeofKindHandler threeofKindHandler = new ThreeofKindHandler();
            StraightFlushHandler straightFlushHandler1 = new StraightFlushHandler();
            FlushHandler flushHandler = new FlushHandler();
            PairHandler pairHandler = new PairHandler();

            straightFlushHandler.SetNextHandler(threeofKindHandler);
            threeofKindHandler.SetNextHandler(straightFlushHandler);
            straightFlushHandler.SetNextHandler(flushHandler);
            flushHandler.SetNextHandler(pairHandler);

            foreach (var player in players)
            {
                straightFlushHandler.Process(player);
            }
        }

        public void GetWinner(List<PlayerHand> players)
        {
            var sortedPlayers = players.OrderByDescending(x => x.HandValue).Select(x => x).ToList();
            var topValue = sortedPlayers.Select(x => x.HandValue).FirstOrDefault();
            foreach (var player in players)
            {
                if (player.HandValue == topValue)
                {
                    player.Winner = true;
                }
            }
        }

        public List<Card> BuildPlayerCards(string[] values)
            {
             List<string> validRanks = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
             List<string> validSuites = new List<string> { "H", "S", "C", "D" };

            List<Card> cards = new List<Card>();
            for (int j = 1; j < values.Length; j++)
            {
                char[] arr;
                arr = values[j].ToCharArray();

                if (!validRanks.Contains(arr[0].ToString().ToUpper()) || !validSuites.Contains(arr[1].ToString().ToUpper()))
                {
                    throw new Exception();
                }

                cards.Add(new Card
                {
                    Rank = arr[0].ToString(),
                    Suite = (CardSuite)Enum.Parse(typeof(CardSuite), arr[1].ToString().ToLower(), true),
                    CardValue = GetCardValue(arr[0].ToString())
                });
            }

            if (IsLowA(cards))
            {
                foreach (var card in cards)
                {
                    if (card.Rank == "A")
                    {
                        card.CardValue = 1;
                    }
                }
            }
            return cards;
        }

        private int GetCardValue(string Rank)
        {
            switch (Rank)
            {
                case "A":
                    return 14;
                case "K":
                    return 13;
                case "Q":
                    return 12;
                case "J":
                    return 11;
                case "T":
                    return 10;
                default:
                    return Convert.ToInt16(Rank);
            }
        }


        private bool IsLowA(List<Card> cards)
        {
            bool isLowA = false;
            var sortedList = cards.OrderBy(o => o.CardValue).Select(x => x).ToList();
            if (sortedList[0].CardValue == 2 && sortedList[1].CardValue == 3 && sortedList[2].CardValue == 14)
                isLowA = true;

            return isLowA;
        }
    }
}
