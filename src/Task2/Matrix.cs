namespace Task2
{
    internal class Matrix
    {
        #region Fields

        private float[][] _numbers;

        #endregion

        #region Constructors

        private Matrix(float[][] numbers)
        {
            _numbers = numbers;
        }

        #endregion

        #region Instance Methods

        public float Sum(Func<float[], float> selector)
        {
            return _numbers.Sum(selector);
        }

        public override string ToString()
        {
            return string.Concat(_numbers.Select(row =>
            {
                var rowString = string.Join(' ', row.Select(number => string.Format("{0,-5}", number)));

                return rowString + Environment.NewLine;
            }));
        }

        #endregion

        #region Factory Methods

        public static Matrix FromTwoDimensionArray(float[][] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            return new Matrix(numbers);
        }

        public static Matrix FromOneDimensionArray(int rowCount, int columnCount, float[] numbers)
        {
            if (rowCount < 1)
            {
                throw new ArgumentException("Row count can not be less than 1!", nameof(rowCount));
            }

            if (columnCount < 1)
            {
                throw new ArgumentException("Column count can not be less than 1!", nameof(columnCount));
            }

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length != rowCount * columnCount)
            {
                throw new ArgumentException("The count of numbers must be equal to the multiplication of the row and column!", nameof(numbers));
            }

            var twoDimensionArray = new float[rowCount][];

            for (var row = 0; row < rowCount; ++row)
            {
                twoDimensionArray[row] = new float[columnCount];

                for (var column = 0; column < columnCount; ++column)
                {
                    twoDimensionArray[row][column] = numbers[row * rowCount + column];
                }
            }

            return new Matrix(twoDimensionArray);
        }

        #endregion
    }
}