using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    class CardRotation
    {
        static void Main(string[] args)
        {
            var numberOfTestCases = Convert.ToInt32(Console.ReadLine());
            int[] decks= new int[numberOfTestCases];

            for (int i = 0; i < numberOfTestCases; i++)
            {
                decks[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < numberOfTestCases; i++)
            {
                var queue = GetQueue(decks[i]);
                var sortedCards = new int[decks[i]];
                var popCount = 1;

                while (queue.Count > 0)
                {
                    for (int j = 1; j <= popCount; j++)
                    {
                        var card = queue.Dequeue();
                        queue.Enqueue(card);
                    }
                    var tossedCard = queue.Dequeue();
                    sortedCards[tossedCard - 1] = popCount;
                    popCount += 1;
                }

                Console.WriteLine(string.Join(' ', sortedCards));
            }
        }
        static Queue<int> GetQueue(int numberOfCards)
        {
            var queue = new Queue<int>();

            for (int i = 1; i <= numberOfCards; i++)
            {
                queue.Enqueue(i);
            }

            return queue;
        }
    }
}
