namespace Validation
{
    public static class Input
    {
        public static int ReadInt(string text)
        {
            Console.Write(text);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid number, try again.");
                Console.Write(text);
            }
            return result;
        }

        public static decimal ReadDecimal(string text)
        {
            Console.Write(text);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid price, try again.");
                Console.Write(text);
            }
            return result;
        }

        public static string ReadNonEmptyString(string text)
        {
            Console.Write(text);
            string result = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Value cannot be empty, try again.");
                Console.Write(text);
                result = Console.ReadLine();
            }
            return result;
        }
    }
}