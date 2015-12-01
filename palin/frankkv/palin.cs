using System;
using System.Linq;

public class Palin
{
    public static void Main()
    {
        // Time: 0.08
        // Memory: 29M
        var T = int.Parse(Console.ReadLine());
        for (var t = 0; t < T; ++t)
        {
            Console.WriteLine(Calc(Console.ReadLine()));
        }
    }

    private static bool NeedToIncrementMiddle(string input)
    {
        var inputRight = input.Substring(input.Length / 2 + input.Length % 2);
        var reverseLeft = new string(input.Substring(0, input.Length / 2).ToCharArray().Reverse().ToArray());

        return string.Compare(inputRight, reverseLeft) != -1;
    }

    private static bool IncrementMiddle(char[] s)
    {
        var carry = false;
        if (s.Length % 2 == 0)
        {
            var middleIndex1 = s.Length / 2 - 1;
            var middleIndex2 = s.Length / 2;

            s[middleIndex1] = s[middleIndex2] = (char)(s[middleIndex1] + 1);
            if (s[middleIndex1] == ':') { carry = true; }
        }
        else
        {
            var middleIndex = s.Length / 2;
            s[middleIndex] = (char)(s[middleIndex] + 1);
            if (s[middleIndex] == ':') { carry = true; }
        }

        return carry;
    }

    private static void Carry(char[] s, bool carry)
    {
        if (!carry) return;

        int index1, index2;
        // Handle strings of different lengths - 1 or 2 middle chars.
        if (s.Length % 2 == 0)
        {
            index1 = s.Length / 2 - 1;
            index2 = s.Length / 2;
        }
        else
        {
            index1 = index2 = s.Length / 2;
        }

        while (index1 != -1)
        {
            if ((s[index1] == '9' || s[index1] == ':'))
            {
                s[index1] = s[index2] = '0';
            }
            else
            {
                s[index1] = s[index2] = (char)(s[index1] + 1);
                return;
            }

            --index1;
            ++index2;
        }
    }

    private static string Calc(string input)
    {
        // Figure out if we need to increment the middle character in the input string.
        var needToIncrementMiddle = NeedToIncrementMiddle(input);

        // Strings are immutable, it's better to work on char array.
        var s = input.ToCharArray();

        // carry = true when IncrementMiddle increments from 9.
        var carry = needToIncrementMiddle && IncrementMiddle(s);

        // Update second half of the string with values from first half.
        for (var n = 0; n <= input.Length / 2 - 1; ++n)
        {
            s[s.Length - 1 - n] = s[n];
        }

        Carry(s, carry);

        // Special handling when all characters are 0.
        if (s.All(c => c == '0'))
        {
            return "1" + new string('0', s.Length - 1) + "1";
        }

        return new string(s);
    }
}