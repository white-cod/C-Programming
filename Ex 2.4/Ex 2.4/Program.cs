using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите логическое выражение: ");
        string expression = Console.ReadLine();

        try
        {
            bool result = Evaluate(expression);
            Console.WriteLine("Результат: {0}", result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }

        Console.ReadLine();
    }

    static bool Evaluate(string expression)
    {
        string[] parts = expression.Split(new[] { "<=", ">=", "==", "!=", "<", ">" }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2) throw new ArgumentException("Недопустимое выражение.");

        int leftOperand = int.Parse(parts[0].Trim());
        int rightOperand = int.Parse(parts[1].Trim());

        string op = expression.Replace(leftOperand.ToString(), "").Replace(rightOperand.ToString(), "").Trim();

        switch (op)
        {
            case "<":
                return leftOperand < rightOperand;
            case "<=":
                return leftOperand <= rightOperand;
            case ">":
                return leftOperand > rightOperand;
            case ">=":
                return leftOperand >= rightOperand;
            case "==":
                return leftOperand == rightOperand;
            case "!=":
                return leftOperand != rightOperand;
            default:
                throw new ArgumentException("Недопустимое выражение.");
        }
    }
}