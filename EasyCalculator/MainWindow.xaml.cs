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
}
