using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCalculator
{
    public class InputQueue
    {
        private List<char> inputs = new();
        public List<char> Inputs => inputs;
        public void AddInput(char input) => inputs.Add(input);
        public void AddInput(string input) => inputs.Add(Convert.ToChar(input));
        public void AddInput(int input) => inputs.Add(Convert.ToChar(input + 48));
        public string MakeDisplayString()
        {
            StringBuilder stringBuilder = new();

            foreach (char input in inputs)
            {
                stringBuilder.Append(input);
            }

            return stringBuilder.ToString();
        }
        public string MakeDisplayString(string input)
        {
            AddInput(input);
            return MakeDisplayString();
        }
        public string MakeDisplayString(int input)
        {
            AddInput(input);
            return MakeDisplayString();
        }

        public List<string> GetExpression(string input)
        {
            List<string> expression = new();
            StringBuilder stringBuilder = new();
            char lastSign = input[0];
            int index = 0;

            foreach (char sign in input)
            {
                if (!(Char.IsDigit(sign) && Char.IsDigit(lastSign)))
                {
                    expression.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }

                stringBuilder.Append(sign);

                if (index == input.Length - 1) expression.Add(stringBuilder.ToString());

                lastSign = sign;
                index++;
            }

            return expression;
        }

        // TO DO: operator precedence!!!
        public int EvaluateExpression(List<string> expression)
        {
            int parameter1;
            int parameter2;
            string operand;
            int intermediateResult = 0;

            while (expression.Count > 1)
            {
                parameter1 = Convert.ToInt32(expression[0]);
                parameter2 = Convert.ToInt32(expression[2]);
                operand = expression[1];

                switch (operand)
                {
                    case "+":
                        intermediateResult = parameter1 + parameter2;
                        break;

                    case "-":
                        intermediateResult = parameter1 - parameter2;
                        break;

                    case "*":
                        intermediateResult = parameter1 * parameter2;
                        break;

                    case "/":
                        intermediateResult = parameter1 / parameter2;
                        break;
                }

                expression.RemoveRange(0, 2);
                expression[0] = intermediateResult.ToString();
            }

            return intermediateResult;
        }
    }
}
