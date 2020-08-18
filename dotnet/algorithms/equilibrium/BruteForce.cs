namespace equilibrium
{
    public class BruteForce
    {
        public int Run(int[] data)
        {
            int leftSum, rightSum;
            for (int i = 0; i < data.Length; i++)
            {
                leftSum = 0;
                for (int j = 0; j < i; j++)
                    leftSum += data[j];

                rightSum = 0;
                for (int j = i+1; j < data.Length; j++)
                    rightSum += data[j];

                if(leftSum == rightSum)
                    return i;
            }
            return -1;
        }   
    }
}