using System.Text;
using System.Collections.Generic;

namespace TestApp;

public class MultiplesFinder
{
    public static string FindMultiples(int start, int end, int devisor)
    {
        if (start > end)
        {
            return "Start number should not be greater than end number.";
        }

        List<int> resultNumbers = new List<int>();

        for (int num = start; num <= end; num++)
        {
            if(num % devisor == 0)
            {
                resultNumbers.Add(num);
            }
        }

        return string.Join(" ", resultNumbers);
    }
}

