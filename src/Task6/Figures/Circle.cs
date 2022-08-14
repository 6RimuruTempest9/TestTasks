namespace Task6.Figures
{
    internal class Circle : Figure
    {
        #region Fields

        private readonly float _radius;

        #endregion

        #region Constructors

        public Circle(float radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius can not be less or equals zero!", nameof(radius));
            }

            _radius = radius;
        }

        #endregion

        #region Instance Methods

        public override float GetArea()
        {
            return MathF.PI * _radius * _radius;
        }

        public override float GetPerimeter()
        {
            return 2 * MathF.PI * _radius;
        }

        public override string ToString()
        {
            return $"Circle (radius: {_radius})";
        }

        #endregion

        #region Static Methods

        public static bool CanExist(float radius)
        {
            if (radius <= 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}