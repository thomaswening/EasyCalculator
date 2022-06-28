using ConsoleCalculator;
using System.Windows;
using System.Windows.Controls;

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
