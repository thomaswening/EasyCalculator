using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InputQueue inputQueue;
        public MainWindow()
        {
            InitializeComponent();
            inputQueue = new();
        }

        private void UpdateInputDisplay(string input) => InputDisplay.Text = inputQueue.MakeDisplayString(input);
        private void UpdateInputDisplay(int input) => InputDisplay.Text = inputQueue.MakeDisplayString(input);

        #region Events

        private void Zero_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(0);
        private void One_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(1);
        private void Two_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(2);
        private void Three_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(3);
        private void Four_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(4);
        private void Five_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(5);
        private void Six_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(6);
        private void Seven_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(7);
        private void Eight_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(8);
        private void Nine_Click(object sender, RoutedEventArgs e) => UpdateInputDisplay(9);

        #endregion
    }

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
            bool predecessorIsDigit = true;

            foreach (char input in inputs)
            {
                stringBuilder.Append(input);
                if (!predecessorIsDigit) stringBuilder.Append(' ');

                if (Char.IsDigit(input)) predecessorIsDigit = true;
                else predecessorIsDigit = false;
            }

            if (predecessorIsDigit == false) stringBuilder.Remove(stringBuilder.Length - 1, 1);

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
    }
}
