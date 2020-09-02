public class MethodOne
{
    //O(N)
    public static int[] Run(int[] nums)
    {
        var length = nums.Length;

        var left = new int[length];
        var right = new int[length];
        
        left[0] = 1;
        for (int i = 1; i < length; i++)
            left[i] = left[i - 1] * nums[i - 1];
        
        right[length - 1] = 1;
        for (int i = length - 2; i >= 0; i--)
            right[i] = right[i + 1] * nums[i + 1];
 
        var result = new int[length];
        for (int i = 0; i < length; i++)
            result[i] = left[i] * right[i];

        return result;
    }
}