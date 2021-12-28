
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFaroShuffle
{
    public static class Cartas
    {
        public static void Main(string[] args)
        {
            var startingDeck = from s in Suits()
                            from r in Ranks()
                            select new { Suit = s, Rank = r };

            foreach (var cards in startingDeck)
            {
                Console.WriteLine(cards);
            }

            var top = startingDeck.Take(24);
            var bottom = startingDeck.Skip(24);
            var shuffle = top.InterleaveSequenceWith(bottom);

            foreach (var cards in shuffle)
            {
                Console.WriteLine(cards);
            }

                    var times = 0;
            // We can re-use the shuffle variable from earlier, or you can make a new one
            shuffle = startingDeck;
            do
            {
                shuffle = shuffle.Take(24).InterleaveSequenceWith(shuffle.Skip(24));

                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

        

        static IEnumerable<string> Suits()
            {
                yield return "basto";
                yield return "oro";
                yield return "copas";
                yield return "espada";
            }

            static IEnumerable<string> Ranks()
            {
                yield return "uno";
                yield return "dos";
                yield return "tres";
                yield return "cuatro";
                yield return "cinco";
                yield return "seis";
                yield return "siete";
                yield return "ocho";
                yield return "nueve";
                yield return "diez";
                yield return "once";
                yield return "doce";
            }
    }
}