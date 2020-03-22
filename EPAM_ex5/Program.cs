using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var checker = new BracketsChecker();

            foreach (var ch in str)
                checker.Put(ch);

            if (checker.Balanced == false)
            {
                Console.WriteLine("Последовательность верная");
            }
            else
            {
                Console.WriteLine("Последовательность неверная");
            }
        }
    }
    class BracketsChecker
    {
        string opening = "([{";
        string ending = ")]}";

        bool notBalanced;

        private Stack<int> opened = new Stack<int>();

        public bool Balanced => notBalanced && !opened.Any();

        public void Put(char ch)
        {
            if (notBalanced) return;

            int index = opening.IndexOf(ch);

            if (index != -1)
            {
                opened.Push(index);
                return;
            }

            index = ending.IndexOf(ch);

            if (index != -1)
            {
                if (!opened.Any() || opened.Peek() != index)
                {
                    notBalanced = true;
                    opened.Clear();
                    return;
                }

                opened.Pop();
                return;
            }
        }
    }
}
