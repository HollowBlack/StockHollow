using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionLib
{
    public static partial class Matrix2D
    {
        public static bool CanShrinkMatrixRow(double[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            return matrix.GetLength(0) >= 2;
        }

        public static bool CanShrinkMatrixColumn(double[,] matrix)
        {
            if(matrix == null)
                throw new ArgumentNullException("matrix");

            return matrix.GetLength(1) >= 2;
        }
    }
}
