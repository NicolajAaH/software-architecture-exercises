// See https://aka.ms/new-console-template for more information

// Implementing a calculator in
// C# using switch statement.
class Program
    {
        static void Main(string[] args)
        {
            string value;
            do
            {
                double res;
                string symbol = "";
                double num1 = 0;
                double num2 = 0;
                try
                {
                    Console.Write("Enter first number:");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter symbol(/,+,-,*):");
                    symbol = Console.ReadLine();
                    Console.Write("Enter second number:");
                    num2 = Convert.ToDouble(Console.ReadLine());
                } catch (Exception e)
                {
                    Console.WriteLine("Wrong input \n");
                    continue;
                }

                switch (symbol)
                {
                    case "+":
                        res = num1 + num2;
                        Console.WriteLine("Addition:" + res);
                        break;
                    case "-":
                        res = num1 - num2;
                        Console.WriteLine("Subtraction:" + res);
                        break;
                    case "*":
                        res = num1 * num2;
                        Console.WriteLine("Multiplication:" + res);
                        break;
                    case "/":
                        res = num1 / num2;
                        Console.WriteLine("Division:" + res);
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine("\nNext input");
            }
            while (true);
        }
    }
