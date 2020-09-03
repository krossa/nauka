using System;

namespace valid_mountain_array
{
    class Program
    {
        // Given an array A of integers, return true if and only if it is a valid mountain array.
        // Recall that A is a mountain array if and only if:
        // A.length >= 3
        // There exists some i with 0 < i < A.length - 1 such that:
        // A[0] < A[1] < ... A[i-1] < A[i]
        // A[i] > A[i+1] > ... > A[A.length - 1]
        static void Main(string[] args)
        {
            var invalid1 = new int[] { 2, 1 };
            var invalid2 = new int[] { 3, 5, 5 };
            var invalid3 = new int[] { 3, 3, 5 };
            var invalid4 = new int[] { 1, 2, 3 };
            var valid = new int[] { 0, 3, 2, 1 };

            Console.WriteLine(ValidMountainArray(invalid1));
            Console.WriteLine(ValidMountainArray(invalid2));
            Console.WriteLine(ValidMountainArray(invalid3));
            Console.WriteLine(ValidMountainArray(invalid4));
            Console.WriteLine(ValidMountainArray(valid));

            Console.WriteLine("-----------");


            Console.WriteLine(ValidMountainArray2(invalid1));
            Console.WriteLine(ValidMountainArray2(invalid2));
            Console.WriteLine(ValidMountainArray2(invalid3));
            Console.WriteLine(ValidMountainArray2(invalid4));
            Console.WriteLine(ValidMountainArray2(valid));
        }

        public static bool ValidMountainArray(int[] array)
        {
            if (array.Length < 3) return false;
            if (array[1] < array[0]) return false;
            var upHill = true;

            for (int i = 1; i < array.Length; i++)
            {
                if (upHill)
                {
                    if (array[i] == array[i - 1])
                        return false;
                    if (array[i] < array[i - 1])
                        upHill = false;
                    continue;
                }
                if (array[i] >= array[i - 1])
                    return false;
            }

            return !upHill;
        }

        public static bool ValidMountainArray2(int[] array)
        {
            int length = array.Length;
            int i = 0;

            // walk up
            while (i + 1 < length && array[i] < array[i + 1])
                i++;

            // peak can't be first or last
            if (i == 0 || i == length - 1)
                return false;

            // walk down
            while (i + 1 < length && array[i] > array[i + 1])
                i++;

            return i == length - 1;
        }
    }
}
