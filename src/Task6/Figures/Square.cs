namespace Task6.Figures
{
    internal class Square : Rectangle
    {
        #region Constructors

        public Square(float sideSize)
            : base(sideSize, sideSize)
        {
        }

        #endregion

        #region Instance Methods

        public override string ToString()
        {
            return $"Square (side size: {Width})";
        }

        #endregion

        #region Static Methods

        public static bool CanExist(float sideSize)
        {
            if (sideSize <= 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}