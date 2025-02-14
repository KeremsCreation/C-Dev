using Calculator.Lib;

namespace Calculator.Model
{
    internal class CalculatorModel
    {
        public string Result { get; private set; }
        public string Input { get; set; }
        List<string> termSeperatorStart = new List<string>();
        
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
            int countStart = termSeperatorStart.Count;

            string result = "";

            if (countStart > 2)
                GetCalcComponents(termSeperatorStart);

            countStart = termSeperatorStart.Count;

            if (countStart == 1)
                result = termSeperatorStart[0];
            Result = result;
        }

        private void UpdateLastTerm(string operation) 
        {
            double updatedTerm = 0;
            double lastTerm = Convert.ToDouble(termSeperatorStart[termSeperatorStart.Count - 1]);
            if (operation == "sqr()")
                updatedTerm = OperatorList.Sqr(lastTerm);
            switch (operation)
            {
                case "sqr()":
                    updatedTerm = OperatorList.Sqr(lastTerm);
                    break;
                case "^2":
                    updatedTerm = OperatorList.Squ(lastTerm);
                    break;
                default:
                    break;
            }
            termSeperatorStart[termSeperatorStart.Count-1] = updatedTerm.ToString();

            Result = string.Join(" ",termSeperatorStart);
        }

        private void ListFiller()
        {
            string k = "";

            if (!string.IsNullOrEmpty(Input))
            {
                for (int i = 0; i < Input.Length; i++)
                {
                    string currentChar = Input[i].ToString();
                    if (OperatorList.BasicOperators.Contains(currentChar))
                    {
                        termSeperatorStart.Add(k);
                        k = "";
                        termSeperatorStart.Add(currentChar);
                    }
                    else k += currentChar;
                }
                if (!string.IsNullOrEmpty(k))
                    termSeperatorStart.Add(k);
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
