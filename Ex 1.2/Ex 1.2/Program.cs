class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Test 1:");
        int number1 = 1221;
        bool isPalindrome1 = IsPalindrome(number1);
        Console.WriteLine($"{number1} является палиндромом: {isPalindrome1}");

        Console.WriteLine("Test 2:");
        int number2 = 3443;
        bool isPalindrome2 = IsPalindrome(number2);
        Console.WriteLine($"{number2} является палиндромом: {isPalindrome2}");

        Console.WriteLine("Test 3:");
        int number3 = 7854;
        bool isPalindrome3 = IsPalindrome(number3);
        Console.WriteLine($"{number3} является палиндромом: {isPalindrome3}");
    }

    static bool IsPalindrome(int number)
    {
        int reverse = 0;
        int original = number;

        while (number > 0)
        {
            int digit = number % 10;
            reverse = (reverse * 10) + digit;
            number = number / 10;
        }

        return original == reverse;
    }
}