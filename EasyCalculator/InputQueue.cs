﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCalculator
{
    public class InputQueue
    {
        private List<char> inputs = new();
        public List<char> Input => inputs;
        public void AddInput(char input) => inputs.Add(input);
        public void AddInput(string input) => inputs.Add(Convert.ToChar(input));
        public void AddInput(int input) => inputs.Add(Convert.ToChar(input + 48));
        public void RemoveLast() => inputs.RemoveAt(inputs.Count - 1);
        public string MakeDisplayString()
        {
            StringBuilder stringBuilder = new();
            foreach (char input in Input)
            {
                stringBuilder.Append(input);
            }

            return stringBuilder.ToString();
        }
    }
}
