using ConsoleCalculator;
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
        private InputQueue inputQueue;
        private Calculation calculation;

        public MainWindow()
        {
            InitializeComponent();
            inputQueue = new();
            calculation = new();
        }

        private void UpdateInputDisplay() => InputDisplay.Text = inputQueue.MakeDisplayString();

        #region Events

        #region Digits
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(0);
            UpdateInputDisplay();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(1);
            UpdateInputDisplay();
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(2);
            UpdateInputDisplay();
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(3);
            UpdateInputDisplay();
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(4);
            UpdateInputDisplay();
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(5);
            UpdateInputDisplay();
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(6);
            UpdateInputDisplay();
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(7);
            UpdateInputDisplay();
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(8);
            UpdateInputDisplay();
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.AddInput(9);
            UpdateInputDisplay();
        }

        private void BackSpace_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.RemoveLast();
            UpdateInputDisplay();
        }
        #endregion

        #endregion
    }
}
