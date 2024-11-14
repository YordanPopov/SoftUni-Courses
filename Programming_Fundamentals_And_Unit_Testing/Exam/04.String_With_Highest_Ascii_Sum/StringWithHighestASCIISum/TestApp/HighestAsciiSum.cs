using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp;

public class HighestAsciiSum
{
    public static string FindStringWithHighestAsciiSum(List<string> strings)
    {
        if (strings == null || strings.Count == 0)
        {
            return string.Empty; 
        }

        int highestSum = int.MinValue;
        string highestAsciiString = string.Empty;

        foreach (var str in strings)
        {
            int sum = str.Sum(c => (int)c);
            if (sum > highestSum)
            {
                highestSum = sum;
                highestAsciiString = str;
            }
        }

        return highestAsciiString;
    }
}
