namespace Validation
{
    public static class InputValidator
    {
        public static int ReadInt(string input)
        {
            Console.Write(input);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid number, try again.");
                Console.Write(input);
            }
            return result;
        }

        public static decimal ReadDecimal(string input)
        {
            Console.Write(input);
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid price, try again.");
                Console.Write(input);
            }
            return result;
        }

        public static string ReadNonEmptyString(string input)
        {
            Console.Write(input);
            string result = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Value cannot be empty, try again.");
                Console.Write(input);
                result = Console.ReadLine();
            }
            return result;
        }
    }
}