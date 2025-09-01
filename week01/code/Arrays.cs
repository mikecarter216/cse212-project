using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new double array of size 'length'.
        // 2. Loop from i = 0 to length - 1.
        // 3. For each i, calculate multiple = number * (i + 1)
        // 4. Assign multiple to array[i].
        // 5. After the loop, return the array.

        double[] multiples = new double[length]; // Step 1

        for (int i = 0; i < length; i++) // Step 2
        {
            multiples[i] = number * (i + 1); // Step 3 & 4
        }

        return multiples; // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Calculate the starting index for the rotation: startIndex = data.Count - amount
        // 2. Get the last 'amount' elements using GetRange(startIndex, amount)
        // 3. Remove these elements from the original list using RemoveRange
        // 4. Insert the removed elements at the beginning of the list using InsertRange
        // 5. The original 'data' list is now rotated in place

        int startIndex = data.Count - amount; // Step 1
        List<int> tail = data.GetRange(startIndex, amount); // Step 2
        data.RemoveRange(startIndex, amount); // Step 3
        data.InsertRange(0, tail); // Step 4
    }
}
