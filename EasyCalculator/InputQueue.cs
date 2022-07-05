using Models;
using EasyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyCalculator
{
    public class InputQueue
    {
        public List<Symbol> Input { get; } = new();

        public void AddInput(int input, string pKind) => Input.Add(new Symbol(input.ToString(), pKind));
        public void AddInput(char input, string pKind) => Input.Add(new Symbol(input.ToString(), pKind));

        public void AddDigit(string pButtonName)
        {
            if (Input.Count != 0 && Input[^1].Kind == SymbolKind.NUMBER)
            {
                Input[^1].AddToContent(GetDigit(pButtonName).ToString());
            }
            else
            {
                AddInput(GetDigit(pButtonName), SymbolKind.NUMBER);
            }

        }

        public void AddDot()
        {
            if (Input.Count > 0 
                && Input[^1].Kind == SymbolKind.NUMBER
                && !Input[^1].Content.Contains(SymbolConst.DOT))
            {
                Input[^1].AddToContent(SymbolConst.DOT.ToString());
            }
            else if ((Input.Count != 0 && Input[^1].Kind == SymbolKind.OPERATOR)
                || Input.Count == 0)
            {
                Input.Add(new Symbol(SymbolConst.DOT.ToString(), SymbolKind.NUMBER));
            }
        }

        public void AddOperator(string pButtonName)
        {
            if (Input.Count != 0 && (Input[^1].Kind == SymbolKind.NUMBER || Input[^1].Kind == SymbolKind.BRACKET_RIGHT))
            {
                AddInput(GetOperator(pButtonName), SymbolKind.OPERATOR);
            }
        }

        public void Negate()
        {
            if (Input.Count > 0 && Input[^1].Kind == SymbolKind.NUMBER)
            {
                Symbol lastSymbol = Input[^1];
                if (lastSymbol.Content[0] == SymbolConst.MINUS)
                {
                    lastSymbol.Content = lastSymbol.Content.Substring(1);
                }
                else
                {
                    Input[^1].Content = SymbolConst.MINUS.ToString() + Input[^1].Content;
                }
            }
            else if ((Input.Count != 0 && Input[^1].Kind == SymbolKind.OPERATOR)
                || Input.Count == 0)
            {
                Input.Add(new Symbol(SymbolConst.MINUS.ToString(), SymbolKind.NUMBER));
            }
        }

        public void RemoveLast()
        {
            if (Input.Count > 0)
            {
                Symbol lastSymbol = Input[^1];
                if (lastSymbol.Content.Length > 1)
                {
                    lastSymbol.Content = lastSymbol.Content[0..^1];
                }
                else
                {
                    Input.RemoveAt(Input.Count - 1);
                }
            }
        }

        public string MakeDisplayString()
        {
            StringBuilder stringBuilder = new();
            foreach (Symbol symbol in Input)
            {
                stringBuilder.Append(symbol.Content);
                stringBuilder.Append(SymbolConst.SPACE);
            }

            return stringBuilder.ToString();
        }

        public void Clear() => Input.Clear();

        private static int GetDigit(string pButtonName)
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

        private static char GetOperator(string pButtonName)
        {
            return pButtonName switch
            {
                ButtonConst.PLUS => '+',
                ButtonConst.MINUS => '-',
                ButtonConst.MULTIPLY => '*',
                ButtonConst.DIVIDE => '/',
                
                _ => throw new NotImplementedException(),
            };
        }

    }
}
