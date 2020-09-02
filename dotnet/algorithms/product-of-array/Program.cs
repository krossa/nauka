using System;

namespace product_of_array
{
    class Program
    {
        // Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
        // Example:
        // Input:  [1,2,3,4]
        // Output: [24,12,8,6]
        // solve without devision

        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 3, 4 };
            Print(input);
            var output = MethodOne.Run(input);
            Print(output);

            var output2 = MethodTwo.Run(input);
            Print(output2);
            
        }

        private static void Print(int[] nums)
        {
            foreach (var item in nums)
                Console.Write($"{item} ");

            Console.WriteLine();
        }
    }
}
