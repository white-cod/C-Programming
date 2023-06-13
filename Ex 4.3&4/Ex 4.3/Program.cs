using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            var morseCodeDictionary = new Dictionary<char, string>()
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "."},
                {'F', "..-."},
                {'G', "--."},
                {'H', "...."},
                {'I', ".."},
                {'J', ".---"},
                {'K', "-.-"},
                {'L', ".-.."},
                {'M', "--"},
                {'N', "-."},
                {'O', "---"},
                {'P', ".--."},
                {'Q', "--.-"},
                {'R', ".-."},
                {'S', "..."},
                {'T', "-"},
                {'U', "..-"},
                {'V', "...-"},
                {'W', ".--"},
                {'X', "-..-"},
                {'Y', "-.--"},
                {'Z', "--.."}
            };

            Console.Write("Введите текст для преобразования в азбуку Морзе: ");
            string input = Console.ReadLine().ToUpper();

            string morseCode = ConvertTextToMorseCode(input, morseCodeDictionary);

            Console.WriteLine($"Азбука Морзе: {morseCode}");

            Console.Write("Введите азбуку Морзе для преобразования в текст: ");
            string morseCodeInput = Console.ReadLine().Trim();

            string text = ConvertMorseCodeToText(morseCodeInput, morseCodeDictionary);

            Console.WriteLine($"Текст: {text}");
        }

        static string ConvertTextToMorseCode(string text, Dictionary<char, string> morseCodeDictionary)
        {
            string morseCode = "";

            foreach (char letter in text)
            {
                if (morseCodeDictionary.ContainsKey(letter))
                {
                    morseCode += morseCodeDictionary[letter] + " ";
                }
                else
                {
                    morseCode += " ";
                }
            }

            return morseCode.TrimEnd();
        }

        static string ConvertMorseCodeToText(string morseCode, Dictionary<char, string> morseCodeDictionary)
        {
            string[] words = morseCode.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries);

            string text = "";

            foreach (string word in words)
            {
                string[] letters = word.Split(' ');

                foreach (string letter in letters)
                {
                    foreach (var kvp in morseCodeDictionary)
                    {
                        if (letter == kvp.Value)
                        {
                            text += kvp.Key;
                            break;
                        }
                    }
                }

                text += " ";
            }

            return text.TrimEnd();
        }
    }
}