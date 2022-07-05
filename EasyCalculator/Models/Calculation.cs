using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Represents a calculation that may be evaluated.
    /// </summary>
    internal class Calculation
    {
        public Expression Expression { get; set; }

        public Calculation() => Expression = new Expression();
        public Calculation(string pInput) => Expression = new Expression(pInput);
        public Calculation(Expression pExpression) => Expression = pExpression;

        /// <summary>
        /// Evaluates the expression's subexpressions first, then replaces them with their
        /// value and then evaluates the remaining primitive expression.
        /// </summary>
        /// <returns>The expression's value.</returns>
        public double Evaluate()
        {
            List<Expression> subExpressions = Expression.GetSubExpressions();

            if (subExpressions.Count > 0)
            {
                // The subexpressions must be replaced by their values from right to left
                // in order to maintain the starting indices of the remaining subexpressions
                subExpressions.Reverse();
                foreach (Expression subExpression in subExpressions)
                {
                    Expression.Symbols.RemoveRange(subExpression.StartIndex + 1, subExpression.Length + 1);
                    Expression.Symbols[subExpression.StartIndex].Content = new Calculation(subExpression).Evaluate().ToString();
                    Expression.Symbols[subExpression.StartIndex].Kind = SymbolKind.NUMBER;
                }
            }

            return EvaluatePrimitiveExpression(Expression);
        }

        /// <summary>
        /// Evaluates an expression without subexpressions iteratively. First determines the 
        /// indices of the leftmost precedent operator and then evaluates its binary expression.
        /// When there are none left, it evaluates the remaining expression from left to right.
        /// </summary>
        /// <param name="pExpression">Primitive expression to be evaluated.</param>
        /// <returns>The primitive expression's value.</returns>
        private double EvaluatePrimitiveExpression(Expression pExpression)
        {
            int iFirstPrecedentOperator;
            Symbol num1;
            Symbol num2;
            Symbol operatorSymbol;

            while (pExpression.Length > 1)
            {
                iFirstPrecedentOperator = GetFirstPrecedentOperator(pExpression.Symbols);
                num1 = pExpression.Symbols[iFirstPrecedentOperator - 1];
                num2 = pExpression.Symbols[iFirstPrecedentOperator + 1];
                operatorSymbol = pExpression.Symbols[iFirstPrecedentOperator];

                pExpression.Symbols[iFirstPrecedentOperator - 1].Content = EvaluateBinaryExpression(num1, num2, operatorSymbol).ToString();
                pExpression.Symbols.RemoveRange(iFirstPrecedentOperator, 2);
            }

            return Convert.ToDouble(pExpression.Symbols[0].Content);
        }
        private static double EvaluateBinaryExpression(Symbol pNum1, Symbol pNum2, Symbol pOperator)
        {
            double num1 = Convert.ToDouble(pNum1.Content);
            double num2 = Convert.ToDouble(pNum2.Content);

            switch (Convert.ToChar(pOperator.Content))
            {
                case SymbolConst.PLUS:
                    return num1 + num2;

                case SymbolConst.MINUS:
                    return num1 - num2;

                case SymbolConst.MULTIPLY:
                    return num1 * num2;

                case SymbolConst.DIVIDE:
                    if (num2 == 0) throw new DivideByZeroException();
                    else return num1 / num2;

                default: throw new NotImplementedException();
            }
        }
        private static int GetFirstPrecedentOperator(List<Symbol> pSymbols)
        {
            int i = 0;
            foreach (Symbol symbol in pSymbols)
            {
                if (!symbol.Kind.Equals(SymbolKind.NUMBER))
                {
                    if (SymbolConst.PrecedentOperators.Contains(Convert.ToChar(symbol.Content))) return i;
                }

                i++;
            }

            return 1;
        }
    }
}
