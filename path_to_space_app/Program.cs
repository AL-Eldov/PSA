using System;
using System.Threading;
using System.Linq;

class Solution
{
    static void Main()
    {

        int[] numbers = Array.ConvertAll(Console.ReadLine()?.Split()!, s => int.Parse(s));
        Console.WriteLine(numbers.Sum());
    }
}
