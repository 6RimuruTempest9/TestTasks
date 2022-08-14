namespace Task6.Figures
{
    internal class Rhombus : Square
    {
        #region Fields

        private readonly float _angle;

        #endregion

        #region Constructors

        public Rhombus(float sideSize, float angle)
            : base(sideSize)
        {
            _angle = angle;
        }

        #endregion

        #region Instance Methods

        public override float GetArea()
        {
            return Width * Width * MathF.Sin(_angle * MathF.PI / 180);
        }

        public override string ToString()
        {
            return $"Rhombus (side size: {Width}; angle: {_angle})";
        }

        #endregion

        #region Static Methods

        public static new bool CanExist(float sideSize, float angle)
        {
            if (sideSize <= 0 || angle <= 0 || 180 <= angle)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}