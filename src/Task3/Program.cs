namespace Task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = InputOrdinalNumber();

            var number = FibonacciNumber(n);

            Console.WriteLine(number);
        }

        private static long FibonacciNumber(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("Ordinal number must be more then 0!", nameof(n));
            }

            if (n == 1)
            {
                return 0;
            }

            return (n == 2) ? 1 : FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        }

        private static int InputOrdinalNumber()
        {
            var input = string.Empty;
            var number = default(int);

            do
            {
                Console.Clear();

                Console.Write("Ordinal number: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number) || number < 1);

            return number;
        }
    }
}