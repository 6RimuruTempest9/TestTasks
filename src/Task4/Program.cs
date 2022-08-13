namespace Task4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var @base = InputBase();
            var degree = InputDegree();

            var number = Pow(@base, degree);

            Console.WriteLine("Result: " + number);
        }

        private static float Pow(float @base, int degree)
        {
            return (degree == 0) ? 1
                : (degree < 0) ? (1 / @base) * Pow(@base, degree + 1)
                : @base * Pow(@base, degree - 1);
        }

        private static float InputBase()
        {
            var input = string.Empty;
            var @base = default(float);

            do
            {
                Console.Clear();

                Console.Write("Base: ");

                input = Console.ReadLine();
            }
            while (!float.TryParse(input, out @base));

            return @base;
        }

        private static int InputDegree()
        {
            var input = string.Empty;
            var degree = default(int);

            do
            {
                Console.Clear();

                Console.Write("Degree: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out degree));

            return degree;
        }
    }
}