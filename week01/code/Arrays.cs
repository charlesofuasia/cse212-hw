public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // STEPS
        // Initialize a variable (multiple), and set it to the given number
        // Create an empty array (multiples) to store the generated multiples of number
        // Loop length times
        // In each iteration, add the current multiple to multiples and increase multiple by number
        // The loop ends after running length times
        // Return multiples

        double multiple = number;
        var multiples = new List<double>();

        for (int i = 0; i < length; i++)
        {
            multiples.Add(multiple);
            multiple += number;
        }


        return multiples.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        //STEPS
        // Determine the rotation point by getting the difference between the total count of items and the amount to be rotated.
        // Split the data into two sub-arrays
        // Array1 Starts from the rotation point to the end of the array
        // Array2 starts from 0 index to the rotation point
        // clear the data and rebuild by first adding array1, and then add array2

        int rotationPoint = data.Count - amount;
        List<int> arr1 = data.GetRange(rotationPoint, amount);
        List<int> arr2 = data.GetRange(0, rotationPoint);

        data.Clear();
        data.AddRange(arr1);
        data.AddRange(arr2);

    }
}
