using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionLib
{
    public static partial class Matrix2D
    {
        public static double[] GetRow(double[,] matrix, int row)
        {
            var width = matrix.GetLength(1);
            var matrixRow = new double[width];
            for (var i = 0; i < width; i++)
            {
                matrixRow[i] = matrix[row - 1, i];
            }
            return matrixRow;
        }

        public static double[] GetColumn(double[,] matrix, int column)
        {
            var height = matrix.GetLength(0);
            var matrixColumn = new double[height];
            for (var i = 0; i < height; i++)
            {
                matrixColumn[i] = matrix[i, column - 1];
            }
            return matrixColumn;
        }

        public static double[,] CopyRow(double[,] matrix, int rowNumber,  double[] rowData)
        {
            var length = rowData.Length;
            var clone = (double[,])matrix.Clone();
            for (var i = 0; i < length; i++)
            {
                clone[rowNumber - 1, i] = rowData[i];
            }
            return clone;
        }

        public static double[,] CopyColumn(double[,] matrix, int columnNumber, double[] columnData)
        {
            var length = columnData.Length;
            var clone = (double[,]) matrix.Clone();
            for (var i = 0; i < length; i++)
            {
                clone[i, columnNumber - 1] = columnData[i];
            }
            return clone;
        }
    }
}
