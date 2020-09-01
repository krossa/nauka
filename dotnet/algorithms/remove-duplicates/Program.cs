using System;
using System.Collections.Generic;

namespace remove_duplicates
{
    class Program
    {
        // Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 1, 2, 2, 2, 3, 3, 4, 5, 5, 8 };
            foreach (var item in arr)
                Console.WriteLine(item);

            Console.WriteLine("XXXXXXXXXX");
            Console.WriteLine(CountUniqueElements(arr));
            Console.WriteLine("");
            foreach (var item in arr)
                Console.WriteLine(item);

            Console.WriteLine("XXXXXXXXXX");
            arr = new int[] { 1, 1, 2, 2, 2, 3, 3, 4, 5, 5, 8 };
            var result = GetUniqueList(arr);
            Console.WriteLine(result.Count);
            Console.WriteLine("");
            foreach (var item in result)
                Console.WriteLine(item);

        }

        public static int CountUniqueElements(int[] nums)
        {
            var result = new List<int>();
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public static List<int> GetUniqueList(int[] nums)
        {
            var result = new List<int>();
            if (nums.Length == 0) return result;
            var lastValue = nums[0];
            result.Add(lastValue);

            for (int i = 1; i < nums.Length; i++)
            {
                if (lastValue != nums[i])
                {
                    lastValue = nums[i];
                    result.Add(lastValue);
                }
            }
            return result;
        }
    }
}
