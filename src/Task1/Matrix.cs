namespace Task1
{
    internal class Matrix
    {
        #region Fields

        private float[][] _numbers;

        #endregion

        #region Constructors

        public Matrix(float[][] numbers)
        {
            _numbers = numbers;
        }

        #endregion

        #region Properties

        protected float[][] Numbers => _numbers;

        #endregion

        #region Instance Methods

        public override string ToString()
        {
            return string.Concat(_numbers.Select(row =>
            {
                var rowString = string.Join(' ', row.Select(number => string.Format("{0,-5}", number)));

                return rowString + Environment.NewLine;
            }));
        }

        #endregion
    }
}