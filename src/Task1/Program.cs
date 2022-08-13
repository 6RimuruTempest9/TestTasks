using System.Globalization;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var size = InputSquareMatrixSize();

            var squareMatrix = InputSquareMatrix(size);

            OutputSquareMatrix(squareMatrix);

            var squareMatrixPriamaryDiagonalSum = GetSquareMatrixPrimaryDiagonalSum(squareMatrix);

            Console.WriteLine("Square matrix primary diagonal sum: {0}", squareMatrixPriamaryDiagonalSum);
        }

        private static float[][] InputSquareMatrix(int sideSize)
        {
            var squareMatrix = new float[sideSize][];

            for (var row = 0; row < sideSize; ++row) 
            {
                squareMatrix[row] = new float[sideSize];

                for (var column = 0; column < sideSize; ++column)
                {
                    var previewText = string.Format("[{0}][{1}]: ", row, column);

                    var number = InputNumber(previewText);

                    squareMatrix[row][column] = number;
                }
            }

            return squareMatrix;
        }

        private static float InputNumber(string previewText)
        {
            var input = string.Empty;
            var number = default(float);

            do
            {
                Console.Write(previewText);

                input = Console.ReadLine();
            }
            while (!float.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out number));

            return number;
        }

        private static int InputSquareMatrixSize()
        {
            var input = string.Empty;
            var size = default(int);

            do
            {
                Console.Write("Matrix size: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1);

            return size;
        }

        private static float GetSquareMatrixPrimaryDiagonalSum(float[][] squareMatrix)
        {
            return squareMatrix.Select((x, i) => x[i]).Sum();
        }

        private static void OutputSquareMatrix(float[][] squareMatrix)
        {
            squareMatrix.ToList().ForEach(row =>
            {
                row.ToList().ForEach(number => Console.Write("{0,-5}", number));

                Console.WriteLine();
            });
        }
    }
}