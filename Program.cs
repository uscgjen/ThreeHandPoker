using System;
using System.Collections.Generic;
using System.Linq;
using ThreeHandPoker.Enums;
using ThreeHandPoker.Models;

namespace ThreeHandPoker
{
    class Program
    {
        static List<PlayerHand> players = new List<PlayerHand>();
     

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of players {1-24}:");
            string input = Console.ReadLine();
            var NumberofPlayers = 0;
            PlayerHelper playerHelper = new PlayerHelper();

            int.TryParse(input, out NumberofPlayers);
            if (NumberofPlayers == 0)
            {
                Console.WriteLine($"{input} was not recognized as a valid number, please play again");
            }

            Console.WriteLine("Valid Player hands are cards 2-9; T for 10; Q, K or A...h for Hearts, c for Clubs, s for Spades and d for Diamonds");
            Console.WriteLine("Example is 1 Qc Kc 4s");
            for (int i = 0; i < NumberofPlayers; i++)
            {
                Console.WriteLine("Please enter the player# and players hand:");
                input = Console.ReadLine();
                
                string[] values = input.Split(" ");
                int inputplayernumber = -1;
                int.TryParse(values[0], out inputplayernumber);

                if (players.Any(q => q.PlayerNumber == inputplayernumber))
                {
                    throw new Exception("Player Number already in use.");
                }

                try
                {
                    if (values.Count() == 4 && inputplayernumber >= 0)
                    {
                        List<Card> cards = playerHelper.BuildPlayerCards(values);

                        players.Add(new PlayerHand
                        {
                            PlayerNumber = inputplayernumber,
                            Cards = cards,
                            HandStrength = HandStrength.HighCard,
                            HandValue = cards.OrderByDescending(x => x.CardValue).Select(x => x.CardValue).FirstOrDefault(),
                            Winner = false
                        });
                    }
                }
                catch
                {
                    Console.WriteLine($"Player input was not valid, player could not be added, please try again");
                    i--;
                }
            }

           
            playerHelper.RankPlayers(players);
            playerHelper.GetWinner(players);

            var winners = string.Join(" ", players.Where(p => p.Winner == true)
                                 .Select(p => p.PlayerNumber.ToString()));

            Console.WriteLine(winners);
            Console.ReadKey();
        }
    }
}
