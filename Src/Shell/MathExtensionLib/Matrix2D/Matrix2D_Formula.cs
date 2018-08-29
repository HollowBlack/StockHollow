using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionLib
{
    public static partial class Matrix2D
    {
        public static double GetDeterminant(double[,] matrix)
        {
            if(matrix ==null)
                throw new ArgumentNullException();

            return CalculateDeterminant(matrix);
        }

        private static double CalculateDeterminant(double[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            var length = matrix.GetLength(0);
            if (length < 2)
                throw new ArgumentException();

            if (length == 2)
                return Math.Abs(matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1]);

            if (length > 2)
            {
                var rowLength = matrix.GetLength(0);
                for (var i = 0; i < rowLength; i++)
                {

                }
            }
            
            throw new Exception();
        }
    }
}
