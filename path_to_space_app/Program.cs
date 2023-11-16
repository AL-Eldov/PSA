using System;
using System.IO;

class Solution
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("input.txt"))
        {
            string[] numbers = reader.ReadLine().Split();
            using (StreamWriter writer = new StreamWriter("output.txt", false))
            {
                string text = (int.Parse(numbers[0]) + int.Parse(numbers[1])).ToString();
                writer.Write(text);
            }
        }
    }
}


