using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionLib
{
    public static partial class Matrix2D
    {
        /// <summary>
        /// remove the target matrix row and return new matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row">row start from 1</param>
        /// <returns></returns>
        public static double[,] RemoveRow(double[,] matrix, int row)
        {
            if (!CanShrinkMatrixRow(matrix))
                throw new Exception();

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);
            if (row > rowLength || row <= 0)
                throw new Exception();

            var tfMatrix = new double[rowLength - 1, colLength];
            for (var i = 0; i < rowLength; i++)
            {
                var targetRow = i;

                if (i + 1 == row)
                    continue;

                if (i + 1 > row)
                    targetRow = i - 1;

                for (var j = 0; j < colLength; j++)
                {
                    tfMatrix[targetRow, j] = matrix[i, j];
                }
            }
            return tfMatrix;
        }

        /// <summary>
        /// remove the target column and return the new matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="column">column start from 1</param>
        /// <returns></returns>
        public static double[,] RemoveColumn(double[,] matrix, int column)
        {
            if (!CanShrinkMatrixColumn(matrix))
                throw new Exception();

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);
            if (column > colLength || column <= 0)
                throw new Exception();

            var tfMatrix = new double[rowLength, colLength - 1];
            for (var i = 0; i < rowLength; i++)
            {
                for (var j = 0; j < colLength; j++)
                {
                    var targetColumn = j;

                    if (j + 1 == column)
                        continue;

                    if (j + 1 > column)
                        targetColumn = j - 1;

                    tfMatrix[i, targetColumn] = matrix[i, j];
                }
            }
            return tfMatrix;
        }

        /// <summary>
        /// Get the sub matrix which remove the the row and column.
        /// </summary>
        /// <param name="matrix">the 2d matrix</param>
        /// <param name="row">row start from 1 other than 0.</param>
        /// <param name="column">col start from 1 other than 0.</param>
        /// <returns>the new matrix which remove row and column </returns>
        public static double[,] RemoveRowAndColumn(double[,] matrix, int row, int column)
        {
            if (!CanShrinkMatrixRow(matrix) || !CanShrinkMatrixColumn(matrix))
                throw new Exception();

            var rowLength = matrix.GetLength(0);
            var colLength = matrix.GetLength(1);
            if (row > rowLength || row <= 0 || column > colLength || column <= 0)
                throw new Exception();

            var tfMatrix = new double[rowLength - 1, colLength - 1];
            for (var i = 0; i < rowLength; i++)
            {
                var targetRow = i;

                if (i + 1 == row)
                    continue;

                if (i + 1 > row)
                    targetRow = i - 1;

                for (var j = 0; j < colLength; j++)
                {
                    var targetColumn = j;

                    if (j + 1 == column)
                        continue;

                    if (j + 1 > column)
                        targetColumn = j - 1;

                    tfMatrix[targetRow, targetColumn] = matrix[i, j];
                }
            }
            return tfMatrix;
        }

        public static double[,] SwitchRow(double[,] matrix, int row1, int row2)
        {
            return null;
        }

        public static double[,] SwitchColumn(double[,] matrix, int column1, int column2)
        {
            return null;
        }
    }
}
