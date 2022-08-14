using static Task5.PhoneBookConsoleHost;

namespace Task5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var hashtableSize = InputHashtableSize();

            var builder = new PhoneBookConsoleHostBuilder();

            var host = builder.SetHashtableSize(hashtableSize).Build();

            host.Run();
        }

        private static int InputHashtableSize()
        {
            var size = default(int);
            var input = string.Empty;

            do
            {
                Console.Clear();

                Console.Write("Hashtable size: ");

                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1);

            return size;
        }
    }
}