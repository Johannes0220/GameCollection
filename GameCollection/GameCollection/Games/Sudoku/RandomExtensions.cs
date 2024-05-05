namespace GameCollection.Games.Sudoku;

using System;
using System.Collections.Generic;

public static class RandomExtensions
{
    public static IEnumerable<int> NextUnique(this Random random, int count, int minValue, int maxValue)
    {
        if (count > maxValue - minValue)
        {
            throw new ArgumentOutOfRangeException("count", "Count is greater than the available range.");
        }

        HashSet<int> uniqueNumbers = new();
        while (uniqueNumbers.Count < count)
        {
            int newNumber = random.Next(minValue, maxValue);
            uniqueNumbers.Add(newNumber);
        }

        return uniqueNumbers;
    }
}
