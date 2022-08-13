namespace Task1
{
    internal class SquareMatrix : Matrix
    {
        #region Constructors

        public SquareMatrix(float[][] numbers)
            : base(numbers)
        {
            numbers.ToList().ForEach(row =>
            {
                if (row.Length != numbers.Length)
                {
                    throw new ArgumentException("Row count and column count must be equals!", nameof(numbers));
                }
            });
        }

        #endregion

        #region Instance Methods
        
        public float PrimaryDiagonalSum()
        {
            return Numbers.Select((x, i) => x[i]).Sum();
        }
        
        #endregion
    }
}