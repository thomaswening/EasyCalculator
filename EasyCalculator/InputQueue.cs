using EasyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasyCalculator
{
    public class InputQueue
    {
        private List<char> inputs = new();
        public List<char> Input => inputs;
        public void AddInput(char input) => inputs.Add(input);
        public void AddInput(string input) => inputs.Add(Convert.ToChar(input));
        public void AddInput(int input) => inputs.Add(Convert.ToChar(input + 48));
        public void AddDigit(string pButtonName) => AddInput(GetDigit(pButtonName));
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

        public void Clear() => inputs.Clear();

        private int GetDigit(string pButtonName)
        {
            return pButtonName switch
            {
                ButtonConst.ZERO => 0,
                ButtonConst.ONE => 1,
                ButtonConst.TWO => 2,
                ButtonConst.THREE => 3,
                ButtonConst.FOUR => 4,
                ButtonConst.FIVE => 5,
                ButtonConst.SIX => 6,
                ButtonConst.SEVEN => 7,
                ButtonConst.EIGHT => 8,
                ButtonConst.NINE => 9,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
