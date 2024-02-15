using System;

class Triangle
{
    static string TriangleType(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return "Не треугольник";

        if (a + b <= c || a + c <= b || b + c <= a)
            return "Не треугольник";

        if (a == b && b == c)
            return "Равносторонний";

        if (a == b || a == c || b == c)
            return "Равнобедренный";

        return "Обычный";
    }

    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Неверное количество аргументов");
            Environment.Exit(1);
        }

        try
        {
            double a = double.Parse(args[0]);
            double b = double.Parse(args[1]);
            double c = double.Parse(args[2]);

            string result = TriangleType(a, b, c);
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат аргументов");
            Environment.Exit(1);
        }
    }
}