namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var size = InputSquareMatrixSize();
            
            var twoDimensionArray = InputTwoDimensionArray(size, size);

            var squareMatrix = new SquareMatrix(twoDimensionArray);

            Console.WriteLine(squareMatrix);

            var sum = squareMatrix.PrimaryDiagonalSum();

            Console.WriteLine("Square matrix primary diagonal sum: {0}", sum);
        }

        private static float[][] InputTwoDimensionArray(int rowCount, int columnCount)
        {
            var twoDimensionArray = new float[rowCount][];

            Enumerable.Range(0, rowCount).ToList().ForEach(rowIndex =>
            {
                twoDimensionArray[rowIndex] = new float[columnCount];

                Enumerable.Range(0, columnCount).ToList().ForEach(columnIndex =>
                {
                    var previewText = string.Format("[{0}][{1}]: ", rowIndex + 1, columnIndex + 1);

                    twoDimensionArray[rowIndex][columnIndex] = InputNumber(previewText);
                });
            });

            return twoDimensionArray;
        }

        private static float InputNumber(string previewText)
        {
            var input = string.Empty;
            var number = default(float);

            do
            {
                Console.Clear();

                Console.Write(previewText);

                input = Console.ReadLine();
            }
            while (!float.TryParse(input, out number));

            return number;
        }

        private static int InputSquareMatrixSize()
        {
            var input = string.Empty;
            var size = default(int);

            do
            {
                Console.Clear();

                Console.Write("Square matrix size: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1);

            return size;
        }
    }
}