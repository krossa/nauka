public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];

        var topRow = 0;
        var btnRow = size - 1;
        var leftCol = 0;
        var rightCol = size - 1;
        var value = 1;

        while (topRow <= btnRow && leftCol <= rightCol)
        {
            //left to right
            for (int j = leftCol; j <= rightCol; j++)
                matrix[topRow, j] = value++;
            topRow++;

            //top to bottom
            for (int i = topRow; i <= btnRow; i++)
                matrix[i, rightCol] = value++;
            rightCol--;

            //right to left
            if (topRow <= btnRow)
            {
                for (int j = rightCol; j >= leftCol; j--)
                    matrix[btnRow, j] = value++;
                btnRow--;
            }

            //bottom to top
            if (leftCol <= rightCol)
            {
                for (int i = btnRow; i >= topRow; i--)
                    matrix[i, leftCol] = value++;
                leftCol++;
            }
        }

        return matrix;
    }
}
