using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Represents a single symbol in a mathematical expression.
    /// </summary>
    internal class Symbol
    {
        public string Content { get; set; }
        public string Kind { get; set; }

        public int Length => Content.Length;
        public Symbol(string pInput)
        {
            Content = pInput;
            Kind = FindSymbolKind(Content);
        }

        static public string FindSymbolKind(string pInput)
        {
            if (IsNumber(pInput)) return SymbolKind.NUMBER;
            else if (pInput.Length == 1)
            {
                if (SymbolConst.Operators.Contains(Convert.ToChar(pInput))) return SymbolKind.OPERATOR;
                else if (SymbolConst.BRACKET_LEFT == Convert.ToChar(pInput)) return SymbolKind.BRACKET_LEFT;
                else if (SymbolConst.BRACKET_RIGHT == Convert.ToChar(pInput)) return SymbolKind.BRACKET_RIGHT;
                else throw new NotImplementedException($"The symbol {pInput} cannot be parsed. Please revise.");
            }
            else throw new NotImplementedException($"The symbol {pInput} cannot be parsed. Please revise.");

        }

        public static bool IsNumber(string pInput)
        {
            if (pInput.Count(element => (element == SymbolConst.DOT)) > 1) return false;

            switch (pInput.Length)
            {
                case 0:
                    return false;

                case 1:
                    return char.IsDigit(pInput[0]);

                case 2:
                    return char.IsDigit(pInput[0]) && char.IsDigit(pInput[1])
                        || (char.IsDigit(pInput[0]) && pInput[1] == SymbolConst.DOT)
                        || (pInput[0] == SymbolConst.DOT && char.IsDigit(pInput[1]))
                        || (pInput[0] == SymbolConst.MINUS && char.IsDigit(pInput[1])
                        || (pInput[0] == SymbolConst.MINUS && pInput[1] == SymbolConst.DOT));

                default:
                    bool areDigitsOrDot = true;
                    foreach (char digit in pInput[2..])
                    {
                        areDigitsOrDot = areDigitsOrDot && (char.IsDigit(digit) || SymbolConst.DOT == digit);
                    }

                    return IsNumber(pInput[..2]) && areDigitsOrDot;
            }
        }

        /// <summary>
        /// Checks if two operators or dots follow one another.
        /// </summary>
        /// <param name="pInput">Input string to be checked.</param>
        /// <exception cref="ArgumentException">Thrown when two operators or dots follow one another.</exception>
        private static void CheckForConsecutiveSymbols(string pInput)
        {
            for (int i = 0; i < pInput.Length - 1; i++)
            {
                char element = pInput[i];
                char predecessor = pInput[i + 1];

                if (SymbolConst.DOT == element && SymbolConst.DOT == predecessor)
                {
                    throw new ArgumentException($"The symbol {element} must not appear twice consecutively. Please revise.", nameof(pInput));
                }

                if (SymbolConst.Operators.Contains(element) && SymbolConst.Operators.Contains(predecessor))
                {
                    throw new ArgumentException($"An operator must not follow after another. Please revise and consider using a pair of brackets.", nameof(pInput));
                }
            }
        }

        /// <summary>
        /// Checks for unmatched brackets.
        /// </summary>
        /// <param name="pInput">Input string to be checked.</param>
        /// <exception cref="ArgumentException">Throw when there are unmatched left or right brackets.</exception>
        private static void CheckForUnmatchedBrackets(string pInput)
        {
            int openBrackets = 0;

            foreach (char element in pInput)
            {
                if (element == SymbolConst.BRACKET_LEFT) openBrackets++;
                if (element == SymbolConst.BRACKET_RIGHT) openBrackets--;
            }

            if (openBrackets > 0) throw new ArgumentException("The input contains unmatched left brackets. Please revise.", nameof(pInput));
            else if (openBrackets < 0) throw new ArgumentException("The input contains unmatched right brackets. Please revise.", nameof(pInput));
        }

        /// <summary>
        /// Tries to parse an input string into a list of symbols.
        /// </summary>
        /// <param name="pInput">Input string to be converted into a list of symbols.</param>
        /// <returns>A list of symbols with the correct content and kind.</returns>
        /// <exception cref="ArgumentException">Thrown when the input string ends in a symbol that cannot be parsed.</exception>
        public static List<Symbol> ConvertToSymbols(string pInput)
        {
            List<Symbol> symbols = new();
            StringBuilder stringBuilder = new();
            int i = 0;

            CheckForConsecutiveSymbols(pInput);
            CheckForUnmatchedBrackets(pInput);

            // Remove spaces
            string inputNoSpaces = pInput.Replace(SymbolConst.SPACE.ToString(), string.Empty);

            foreach (char element in inputNoSpaces)
            {
                if (SymbolConst.Brackets.Contains(element))
                {
                    if (stringBuilder.Length > 0)
                    {
                        symbols.Add(new Symbol(stringBuilder.ToString()));
                        stringBuilder.Clear();
                    }

                    symbols.Add(new Symbol(element.ToString()));
                }
                else
                {
                    string testString = stringBuilder.ToString() + element;
                    if (IsNumber(testString) || i == 0) stringBuilder.Append(element);

                    // The first digit might be a minus sign, so we have to check if the next element
                    // appended yields a number

                    else if (IsNumber(testString + inputNoSpaces[i + 1])) stringBuilder.Append(element);
                    else
                    {
                        if (stringBuilder.Length > 0)
                        {
                            symbols.Add(new Symbol(stringBuilder.ToString()));
                            stringBuilder.Clear();
                        }

                        if (SymbolConst.Operators.Contains(element)) symbols.Add(new Symbol(element.ToString()));
                        else throw new ArgumentException($"The symbol {element} is not allowed as input. Please revise.", nameof(pInput));
                    }
                }

                // The last symbol must be parseable, otherwise throw exception
                if (i == inputNoSpaces.Length - 1)
                {
                    string testString = stringBuilder.ToString();

                    // We have already checked for brackets
                    if (!SymbolConst.Brackets.Contains(element))
                    {
                        if (!IsNumber(testString))
                        {
                            throw new ArgumentException("The input cannot be parsed. Please revise.", nameof(pInput));
                        }
                        else symbols.Add(new Symbol(testString));
                    }
                }

                i++;
            }

            return symbols;
        }
    }
}
