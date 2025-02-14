using System;
using Calculator.Model;
using Calculator.MVVM;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        private int remover = 1;
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

        public void ButtonDeleteLast()
        {
            
            //remover = CalcResult.Length > 1 ? 2 : 1;
            CalcResult = CalcResult.Length > 0 ? CalcResult.Remove(CalcResult.Length - remover) : ""; 
        }

        public void ButtonSquareAndRoot(string buttonText)
        {
            CalculatorModel c = new CalculatorModel(CalcResult, buttonText);
            CalcResult = c.Result.ToString();
        }
    }
}
