using System.Windows;
using System.Windows.Controls;
using Calculator.Lib;
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
        //wurzel mod. quadrat
        private void CreateButtons()
        {
            Button button;


            string[,] buttonContent = new string[,]
            {
                { ButtonLabels.Sqr, ButtonLabels.Square, ButtonLabels.Mod, ButtonLabels.Del },
                { ButtonLabels.Seven, ButtonLabels.Eight, ButtonLabels.Nine, ButtonLabels.Divide },
                { ButtonLabels.Four, ButtonLabels.Five, ButtonLabels.Six, ButtonLabels.Multiply },
                { ButtonLabels.One, ButtonLabels.Two, ButtonLabels.Three, ButtonLabels.Minus },
                { ButtonLabels.Clear, ButtonLabels.Zero, ButtonLabels.Equals, ButtonLabels.Plus }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    button = new Button();
                    string buttonText = buttonContent[i, j];
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    button.Content = buttonText;

                    if (buttonText == ButtonLabels.Clear)
                        button.Click += (sender, e) => vm.ButtonClear();
                    else if (buttonText == ButtonLabels.Equals)
                        button.Click += (sender, e) => vm.ButtonEquals();
                    else if (buttonText == ButtonLabels.Del)
                        button.Click += (sender, e) => vm.ButtonDeleteLast();
                    else if (buttonText == ButtonLabels.Sqr || buttonText == ButtonLabels.Square)
                        button.Click += (sender, e) => vm.ButtonSquareAndRoot(buttonText);
                    else
                        button.Click += (sender, e) => vm.ButtonClick(buttonText);

                    BtnGrid.Children.Add(button);
                }
            }
        }
    }
}
