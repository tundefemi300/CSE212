```csharp
using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function produces an array of size 'length' starting with
    /// 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) produces {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>Array of doubles that are multiples of the supplied number.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array with enough space to store the requested multiples.
        double[] multiples = new double[length];

        // Step 2: Loop through each position in the array.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate each multiple by multiplying the starting number
            // by the current index plus one.
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the completed array.
        return multiples;
    }

    /// <summary>
    /// Rotates the supplied list to the right by the specified amount.
    /// For example, rotating {1, 2, 3, 4, 5, 6, 7, 8, 9} by 3
    /// produces {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// This function modifies the original list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the index where the last 'amount' items begin.
        // For example, if the list has 9 items and amount is 3,
        // the last 3 items begin at index 6.
        int splitIndex = data.Count - amount;

        // Step 2: Copy the last 'amount' items into a temporary list.
        List<int> itemsToMove = data.GetRange(splitIndex, amount);

        // Step 3: Remove those items from the original list.
        data.RemoveRange(splitIndex, amount);

        // Step 4: Insert the saved items at the beginning of the original list.
        data.InsertRange(0, itemsToMove);

        // Step 5: The original list is now rotated to the right.
    }
}
```

