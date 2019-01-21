using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    private int[,] matrix;
    public SaddlePoints(int[,] values)
    {
        this.matrix = values;
    }

    public IEnumerable<(int, int)> Calculate()
    {
        var xDimension = matrix.GetUpperBound(0);
        var yDimension = matrix.GetUpperBound(1);
        var maxColumnsPerRow = new List<List<int>>();
        for (int x = 0; x <= xDimension; x++)
        {
            var maxValue = matrix[x, 0];
            maxColumnsPerRow.Add(new List<int>());
            for (int y = 0; y <= yDimension; y++)
            {
                if (maxValue == matrix[x, y]) maxColumnsPerRow[x].Add(y);
                if (maxValue < matrix[x, y])
                {
                    maxValue = matrix[x, y];
                    maxColumnsPerRow[x] = new List<int>() { y };
                }
            }
        }

        for (int rowIndex = 0; rowIndex <= xDimension; rowIndex++)
        {
            foreach (var maxColumnIndex in maxColumnsPerRow[rowIndex])
            {
                var isSaddle = true;
                for (int x = 0; x <= xDimension; x++)
                {
                    if (matrix[rowIndex, maxColumnIndex] > matrix[x, maxColumnIndex])
                    {
                        isSaddle = false;
                        break;
                    }
                }
                if (isSaddle) yield return (rowIndex, maxColumnIndex);
            }
        }
    }
}