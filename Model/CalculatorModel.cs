namespace Calculator.Model
{
    internal class CalculatorModel
    {
        public string Result { get; private set; }
        public string Input { get; set; }
        List<string> termSeperatorStart = new List<string>();
        
        public CalculatorModel(string input)
        {
            Input = input.Replace(" ", "");
            ListFiller();
            Calculate();
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


        private void ListFiller()
        {
            string k = "";

            if (!string.IsNullOrEmpty(Input))
            {
                for (int i = 0; i < Input.Length; i++)
                {
                    string currentChar = Input[i].ToString();
                    if (OperatorList.Operators.Contains(currentChar))
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
                    "+" => Add(num1, num2),
                    "-" => Sub(num1, num2),
                    "*" => Mul(num1, num2),
                    "/" => Div(num1, num2),
                    _ => throw new NotImplementedException(),
                };

                listA[i] = tempResult.ToString();
                listA.RemoveAt(i + 1);
                listA.RemoveAt(i + 1);
            }

        }

        public double Add(double a, double b) => a + b;
        public double Sub(double a, double b) => a - b;
        public double Mul(double a, double b) => a * b;
        public double Div(double a, double b) => b != 0 ? a / b : double.NaN;
    }
}
