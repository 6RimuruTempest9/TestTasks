namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rowCount = InputRowCount();
            var columnCount = InputColumnCount();
            var twoDimensionArray = InputTwoDimensionArray(rowCount, columnCount);

            var matrix = Matrix.FromTwoDimensionArray(twoDimensionArray);

            Console.WriteLine(matrix);

            var sum = matrix.Sum(row => row.Where(number => number % 3 == 0).Sum());

            Console.WriteLine("Sum of numbers of multiples of three: " + sum);
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

        private static int InputRowCount()
        {
            var input = string.Empty;
            var rowCount = default(int);

            do
            {
                Console.Clear();

                Console.Write("Row count: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out rowCount) || rowCount < 1);

            return rowCount;
        }

        private static int InputColumnCount()
        {
            var input = string.Empty;
            var columnCount = default(int);

            do
            {
                Console.Clear();

                Console.Write("Column count: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out columnCount) || columnCount < 1);

            return columnCount;
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
    }
}