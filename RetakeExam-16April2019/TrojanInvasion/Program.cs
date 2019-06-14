using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Queue<int> spartanDefense = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> trojanWarriors = new Stack<int>();

            for (int i = 1; i <= length; i++)
            {
                trojanWarriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

                while (trojanWarriors.Count > 0 && spartanDefense.Count > 0)
                {
                    if (trojanWarriors.Peek() > spartanDefense.Peek())
                    {
                        int newTrojanValue = trojanWarriors.Pop() - spartanDefense.Dequeue();
                        trojanWarriors.Push(newTrojanValue);
                    }

                    else if (trojanWarriors.Peek() == spartanDefense.Peek())
                    {
                        trojanWarriors.Pop();
                        spartanDefense.Dequeue();
                    }

                    else if (spartanDefense.Peek() > trojanWarriors.Peek())
                    {
                        int trojanValue = trojanWarriors.Pop();
                        List<int> tempSpartanList = spartanDefense.ToList();
                        tempSpartanList[0] -= trojanValue;
                        spartanDefense = new Queue<int>(tempSpartanList);
                    }
                }

                if (i % 3 == 0)
                {
                    spartanDefense.Enqueue(int.Parse(Console.ReadLine()));
                }

                if (spartanDefense.Count == 0)
                {
                    break;
                }
            }

            if (spartanDefense.Count >= trojanWarriors.Count)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", spartanDefense)}");
            }

            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojanWarriors)}");
            }
        }
    }
}