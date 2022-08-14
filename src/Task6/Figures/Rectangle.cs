namespace Task6.Figures
{
    internal class Rectangle : Figure
    {
        #region Fields

        private readonly float _width;
        private readonly float _height;

        #endregion

        #region Constructors

        public Rectangle(float width, float height)
        {
            _width = width;
            _height = height;
        }

        #endregion

        #region Properties

        protected float Width => _width;

        protected float Height => _height;

        #endregion

        #region Instance Methods

        public override float GetArea()
        {
            return _width * _height;
        }

        public override float GetPerimeter()
        {
            return 2 * (_width + _height);
        }

        public override string ToString()
        {
            return $"Rectangle (width: {_width}; height: {_height})";
        }

        #endregion

        #region Static Methods

        public static bool CanExist(float width, float height)
        {
            if (width <= 0 || height <= 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}