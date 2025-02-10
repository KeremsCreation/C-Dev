using System;
using Calculator.Model;
using Calculator.MVVM;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        private string calcResult;

        public string CalcResult
        {
            get { return calcResult; }
            set
            {
                if (calcResult != value)
                {
                    calcResult = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ButtonClick(string buttonText)
        {
            CalcResult += buttonText + " ";
        }

        public void ButtonClear()
        {
            CalcResult = "";
        }

        public void ButtonEquals()
        {
            CalculatorModel c = new CalculatorModel(CalcResult);
            CalcResult = c.Result.ToString();
        }
    }
}
