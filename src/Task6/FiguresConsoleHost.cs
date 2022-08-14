using Task6.Figures;

namespace Task6
{
    internal class FiguresConsoleHost
    {
        #region Fields

        private readonly List<Figure> _figures;
        private bool _isRun;

        #endregion

        #region Constructors

        public FiguresConsoleHost()
        {
            _figures = new List<Figure>();
        }

        #endregion

        #region Instance Methods

        public void Run()
        {
            _isRun = true;

            while (_isRun)
            {
                CallMenu();
            }
        }

        public void Stop()
        {
            _isRun = false;
        }

        private void CallMenu()
        {
            Console.Clear();

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add square.");
            Console.WriteLine("2. Check square existing.");
            Console.WriteLine("3. Add rectangle.");
            Console.WriteLine("4. Check rectangle existing.");
            Console.WriteLine("5. Add rhombus.");
            Console.WriteLine("6. Check rhombus existing.");
            Console.WriteLine("7. Add circle.");
            Console.WriteLine("8. Check circle existing.");
            Console.WriteLine("9. Show all figures info.");
            Console.WriteLine("0. Exit.");

            var pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:

                    AddSquare();

                    break;

                case ConsoleKey.D2:

                    CheckSquareExisting();

                    break;

                case ConsoleKey.D3:

                    AddRectangle();

                    break;

                case ConsoleKey.D4:

                    CheckRectangleExisting();

                    break;

                case ConsoleKey.D5:

                    AddRhombus();

                    break;

                case ConsoleKey.D6:

                    CheckRhombusExisting();

                    break;

                case ConsoleKey.D7:

                    AddCircle();

                    break;

                case ConsoleKey.D8:

                    CheckCircleExisting();

                    break;

                case ConsoleKey.D9:

                    ShowAllFiguresInfo();

                    break;

                case ConsoleKey.D0:

                    Stop();

                    break;

                default:
                    break;
            }
        }

        private void ShowAllFiguresInfo()
        {
            Console.Clear();

            foreach (var figure in _figures)
            {
                Console.WriteLine(figure + " | " + $"Area: {figure.GetArea()}" + " | " + $"Perimeter: {figure.GetPerimeter()}");
            }

            Console.ReadKey();
        }

        private void AddSquare()
        {
            var sideSize = default(float);

            do
            {
                sideSize = InputNumber("Side size: ");
            }
            while (!Square.CanExist(sideSize));

            _figures.Add(new Square(sideSize));
        }

        private void AddRectangle()
        {
            var width = default(float);
            var height = default(float);

            do
            {
                width = InputNumber("Width: ");
                height = InputNumber("Height: ");
            }
            while (!Rectangle.CanExist(width, height));

            _figures.Add(new Rectangle(width, height));
        }

        private void AddRhombus()
        {
            var sideSize = default(float);
            var angle = default(float);

            do
            {
                sideSize = InputNumber("Side size: ");
                angle = InputNumber("Angle: ");
            }
            while (!Rhombus.CanExist(sideSize, angle));

            _figures.Add(new Rhombus(sideSize, angle));
        }

        private void AddCircle()
        {
            var radius = default(float);

            do
            {
                radius = InputNumber("Radius: ");
            }
            while (!Circle.CanExist(radius));

            _figures.Add(new Circle(radius));
        }

        private void CheckSquareExisting()
        {
            var sideSize = InputNumber("Side size: ");

            var canExist = Square.CanExist(sideSize);

            Console.WriteLine($"Square with side size {sideSize} is " + (canExist ? "can" : "can not") + " exist.");

            Console.ReadKey();
        }

        private void CheckRectangleExisting()
        {
            var width = InputNumber("Width: ");
            var height = InputNumber("Height: ");

            var canExist = Rectangle.CanExist(width, height);

            Console.WriteLine($"Rectangle with width {width} and height {height} is " + (canExist ? "can" : "can not") + " exist.");

            Console.ReadKey();
        }

        private void CheckRhombusExisting()
        {
            var sideSize = InputNumber("Side size: ");
            var angle = InputNumber("Angle: ");

            var canExist = Rhombus.CanExist(sideSize, angle);

            Console.WriteLine($"Rhombus with side size {sideSize} and one of angle {angle} is " + (canExist ? "can" : "can not") + " exist.");

            Console.ReadKey();
        }

        private void CheckCircleExisting()
        {
            var radius = InputNumber("Radius: ");

            var canExist = Circle.CanExist(radius);

            Console.WriteLine($"Circle with radius {radius} is " + (canExist ? "can" : "can not") + " exist.");

            Console.ReadKey();
        }

        private float InputNumber(string previewText)
        {
            var number = default(float);
            var input = string.Empty;

            do
            {
                Console.Clear();

                Console.Write(previewText);

                input = Console.ReadLine();
            }
            while (!float.TryParse(input, out number));

            return number;
        }

        #endregion
    }
}