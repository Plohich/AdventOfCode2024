namespace QuickSortExercise;

public static class SortWorker
{
    public static int[] ApplyQuickSort(int[] inputArray) => QuickSort(inputArray, 0, inputArray.Length - 1);
    
    private static int[] QuickSort(int[] inputArray, int idxStart, int idxEnd)
    {
        if (idxStart < idxEnd)
        {
            int pi = Partition(inputArray, idxStart, idxEnd);
            QuickSort(inputArray, idxStart, pi - 1);
            QuickSort(inputArray, pi + 1, idxEnd);
        }

        return inputArray;
        
    }

    private static int Partition(int[] inputArray, int idxStart, int idxEnd)
    {
        int pivotIdx = idxEnd;
        int lowerElementIdx = idxStart - 1;
        for (int i = idxStart; i < idxEnd; i++)
        {
            if (inputArray[i] <= inputArray[pivotIdx])
            {
                lowerElementIdx++;
                SwapElements(ref inputArray[lowerElementIdx], ref inputArray[i]);
            }
        }
        
        SwapElements(ref inputArray[lowerElementIdx + 1], ref inputArray[pivotIdx]);
        return lowerElementIdx + 1;
    }

    public static void Print(int[] inputArray)
    {
        foreach (var entry in inputArray)
        {
            Console.Write($"{entry} ");
        }
        Console.WriteLine();
    }

    private static void SwapElements(ref int a, ref int b) => (a, b) = (b, a);   
}