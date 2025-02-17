/*
using System;
using Calculator.Lib;

namespace Calculator.Model
{
    internal class CalculatorModel
    {
        public string Result { get; private set; }
        public string Input { get; set; }

        private List<string> termSeperatedList = new List<string>();

        public CalculatorModel(string input, string calculate = "")
        {
            Input = input.Replace(" ", "");
            ListFiller();
            if (calculate == "")
                Calculate();

            else UpdateLastTerm(calculate);

        }


        private void Calculate()
        {
            int countStart = termSeperatedList.Count;

            string result = "";

            try
            {
                if (countStart > 2)
                    GetCalcComponents(termSeperatedList);

                countStart = termSeperatedList.Count;

                if (countStart == 1)
                    result = termSeperatedList[0];
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message;
            }
            Result = result;



        }

        private void UpdateLastTerm(string operation)
        {
            double updatedTerm = 0;
            double lastTerm = Convert.ToDouble(termSeperatedList[termSeperatedList.Count - 1]);
            if (operation == "sqr()")
                updatedTerm = OperatorList.Sqr(lastTerm);
            switch (operation)
            {
                case ButtonLabels.Sqr:
                    updatedTerm = OperatorList.Sqr(lastTerm);
                    break;
                case ButtonLabels.Square:
                    updatedTerm = OperatorList.Squ(lastTerm);
                    break;
                default:
                    break;
            }
            termSeperatedList[termSeperatedList.Count - 1] = updatedTerm.ToString();

            Result = string.Join(" ", termSeperatedList);
        }

        private void ListFiller()
        {
            string k = "";

            if (!string.IsNullOrEmpty(Input))
            {
                for (int i = 0; i < Input.Length; i++)
                {
                    string currentChar = Input[i].ToString();
                    if (OperatorList.ArithmeticOperators.Contains(currentChar))
                    {
                        termSeperatedList.Add(k);
                        k = "";
                        termSeperatedList.Add(currentChar);
                    }
                    else k += currentChar;
                }
                if (!string.IsNullOrEmpty(k))
                    termSeperatedList.Add(k);
            }
        }



        private void GetCalcComponents(List<string> listA)
        {
            double num1;
            string mathOperator;
            double num2;
            double tempResult = 0;
            int i = 0;


            while (listA.Count >= 3)
            {
                num1 = Convert.ToDouble(listA[i]);

                mathOperator = listA[i + 1].ToString();

                num2 = Convert.ToDouble(listA[i + 2]);

                tempResult = mathOperator switch
                {
                    "+" => OperatorList.Add(num1, num2),
                    "-" => OperatorList.Sub(num1, num2),
                    "*" => OperatorList.Mul(num1, num2),
                    "/" => OperatorList.Div(num1, num2),
                    "%" => OperatorList.Mod(num1, num2),
                    _ => throw new NotImplementedException(),
                };

                listA[i] = tempResult.ToString();
                listA.RemoveAt(i + 1);
                listA.RemoveAt(i + 1);
            }

        }


    }
}
*/