using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal struct SymbolKind
    {
        public const string NUMBER = "number";
        public const string OPERATOR = "operator";
        public const string FUNCTION = "function";
        public const string BRACKET_LEFT = "bracket left";
        public const string BRACKET_RIGHT = "bracket right";
        public const string INDETERMINATE = "indeterminate";
    }
}
