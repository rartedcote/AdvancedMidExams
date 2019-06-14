using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCap = int.Parse(Console.ReadLine());
            Stack<string> inputStack = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<char> hallsQueue = new Queue<char>();
            Queue<int> companiesQueue = new Queue<int>();

            while (inputStack.Count > 0)
            {
                int parseVal;
                if (int.TryParse(inputStack.Peek(), out parseVal))
                {
                    inputStack.Pop();

                    if (hallsQueue.Count > 0)
                    {
                        if (companiesQueue.Sum() + parseVal <= maxCap)
                        {
                            companiesQueue.Enqueue(parseVal);
                        }

                        else
                        {
                            Console.WriteLine($"{hallsQueue.Dequeue()} -> {string.Join(", ", companiesQueue)}");
                            companiesQueue = new Queue<int>();

                            if (hallsQueue.Count > 0)
                            {
                                companiesQueue.Enqueue(parseVal);
                            }
                        }
                    }
                }

                else
                {
                    hallsQueue.Enqueue(char.Parse(inputStack.Pop()));
                }
            }
        }
    }
}