using ConsoleCalculator;
using EasyCalculator.Models;
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

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button source = (Button)e.OriginalSource;
            inputQueue.AddDigit(source.Name);
            UpdateInputDisplay();
        }

        private void BackSpace_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.RemoveLast();
            UpdateInputDisplay();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            inputQueue.Clear();
            UpdateInputDisplay();
        }

        #endregion

    }
}
