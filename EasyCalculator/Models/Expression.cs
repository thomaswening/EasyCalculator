using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Defines a mathematical expression that may be evaluated in a calculation.
    /// </summary>
    internal class Expression
    {
        public List<Symbol> Symbols = new();
        public int Length => Symbols.Count;
        public int StartIndex { get; set; } = 0;

        public Expression() { }
        public Expression(string pInput)
        {
            Symbols = Symbol.ConvertToSymbols(pInput);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (Symbol symbol in Symbols)
            {
                sb.Append(symbol.Content);
            }

            return sb.ToString();
        }

        public void Clear() => Symbols.Clear();
        public void AddSymbol(Symbol pSymbol) => Symbols.Add(pSymbol);
        public void AddSymbols(List<Symbol> pSymbols) => Symbols.AddRange(pSymbols);

        private void RemoveOuterBrackets()
        {
            Symbols.RemoveAt(0);
            Symbols.RemoveAt(Length - 1);
        }
        private Expression Copy()
        {
            Expression copy = new();
            copy.AddSymbols(Symbols);
            copy.StartIndex = StartIndex;

            return copy;
        }

        /// <summary>
        /// Iterates through the expression's symbols and checks how many 
        /// brackets are opened and then closed in order to determine
        /// how many subexpressions are enclosed in brackets within the expression.
        /// </summary>
        /// <returns>A list of all subexpressions within the expression.</returns>
        public List<Expression> GetSubExpressions()
        {
            int openBrackets = 0;
            int i = 0;

            List<Expression> subExpressions = new();
            Expression subExpression = new();

            foreach (Symbol symbol in Symbols)
            {
                if (symbol.Content == SymbolConst.BRACKET_LEFT.ToString())
                {
                    if (openBrackets == 0) subExpression.StartIndex = i;
                    openBrackets++;
                }

                if (openBrackets > 0) subExpression.AddSymbol(symbol);

                if (symbol.Content == SymbolConst.BRACKET_RIGHT.ToString()) openBrackets--;

                if (openBrackets == 0 && subExpression.Length > 0)
                {
                    subExpression.RemoveOuterBrackets();
                    subExpressions.Add(subExpression.Copy());
                    subExpression.Clear();
                }

                i++;
            }

            return subExpressions;
        }
    }
}
