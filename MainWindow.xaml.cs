using System.Windows;
using System.Windows.Controls;
using Calculator.ViewModel;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private CalculatorViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new CalculatorViewModel();
            DataContext = vm;
            CreateButtons();
        }

        private void CreateButtons()
        {
            Button button;

            string[,] buttonContent = new string[,]
            {
                {"7", "8", "9", "/"},
                {"4", "5", "6", "*"},
                {"1", "2", "3", "-"},
                {"C", "0", "=", "+"}
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    button = new Button();
                    string buttonText = buttonContent[i, j];
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    button.Content = buttonText;

                    if (buttonText == "C")
                        button.Click += (sender, e) => vm.ButtonClear();
                    else if (buttonText == "=")
                        button.Click += (sender, e) => vm.ButtonEquals();
                    else
                        button.Click += (sender, e) => vm.ButtonClick(buttonText);

                    BtnGrid.Children.Add(button);
                }
            }
        }
    }
}
