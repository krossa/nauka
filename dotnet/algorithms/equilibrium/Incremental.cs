namespace equilibrium
{
    public class Incremental
    {
        public int Run(int[] data)
        {
            int leftSum = 0, totalSum = 0;

            for (int i = 0; i < data.Length; i++)
                totalSum += data[i];

            for (int i = 0; i < data.Length; i++)
            {
                totalSum -= data[i];
                var rightSum = totalSum;

                if (leftSum == rightSum)
                    return i;
                
                leftSum += data[i];
            }

            return -1;
        }
    }
}