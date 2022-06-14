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
    }
}
