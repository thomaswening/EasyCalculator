using System.Collections.Generic;

namespace ConsoleCalculator
{
    /// <summary>
    /// Defines the different kinds of symbols there are.
    /// Defines constants containing the string literals for symbols other than numbers.
    /// Groups symbols together in collections.
    /// </summary>
    internal struct SymbolConst
    {
        public const char SPACE = ' ';
        public const char DOT = '.';
        public const char BRACKET_LEFT = '(';
        public const char BRACKET_RIGHT = ')';

        public const char PLUS = '+';
        public const char MINUS = '-';
        public const char MULTIPLY = '*';
        public const char DIVIDE = '/';

        static public List<char> Operators => new() { '+', '-', '*', '/' };
        static public List<char> PrecedentOperators => new() { '*', '/' };
        static public List<char> Brackets => new List<char> { BRACKET_LEFT, BRACKET_RIGHT };

    }
}
