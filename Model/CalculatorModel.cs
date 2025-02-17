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
                if (countStart >= 2)
                    GetCalcComponents(termSeperatedList);

                countStart = termSeperatedList.Count;

                if (countStart == 1)
                    result = termSeperatedList[0];
            }
            catch (Exception ex)
            {
                //result = "Error: " + ex.Message;
                result = "Nicht berechenbare Eingabe!";
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
            bool isAdditiveOperator = false;
            if (!string.IsNullOrEmpty(Input))
            {
                for (int i = 0; i < Input.Length; i++)
                {
                    string currentChar = Input[i].ToString();
                    if (OperatorList.AdditiveOperators.Contains(currentChar))
                    {
                        if (!string.IsNullOrEmpty(k))
                        {
                            termSeperatedList.Add(k);
                            k = "";
                        }
                        if (i + 1 < Input.Length && char.IsDigit(Input[i + 1]))
                        {
                            k = currentChar + Input[i + 1];
                            termSeperatedList.Add(k);
                            k = "";
                            i++;
                        }
                        else
                        {
                            termSeperatedList.Add(currentChar);
                        }

                        isAdditiveOperator = true;
                    }

                    else if (OperatorList.MultiplicativeOperators.Contains(currentChar))
                    {
                        if (!string.IsNullOrEmpty(k))
                        {
                            termSeperatedList.Add(k);
                            k = "";
                        }
                        termSeperatedList.Add(currentChar);
                        isAdditiveOperator = false;
                    }
                    else
                    {
                        k += currentChar;
                        if (isAdditiveOperator)
                        {
                            isAdditiveOperator = false;
                        }
                    }
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

            
            while (listA.Count >= 3 && OperatorList.MultiplicativeOperators.Any())
            {
                int index = listA.IndexOf(OperatorList.MultiplicativeOperators.FirstOrDefault(listA.Contains));

                num1 = Convert.ToDouble(listA[index-1]);

                mathOperator = listA[index].ToString();

                num2 = Convert.ToDouble(listA[index + 1]);

                tempResult = mathOperator switch
                {
                    "*" => OperatorList.Mul(num1, num2),
                    "/" => OperatorList.Div(num1, num2),
                    "%" => OperatorList.Mod(num1, num2),
                    _ => throw new NotImplementedException(),
                };

                listA[index-1] = tempResult.ToString();
                listA.RemoveAt(index);
                listA.RemoveAt(index);
            }

            while (listA.Count >= 3 && OperatorList.AdditiveOperators.Any())
            {

                num1 = Convert.ToDouble(listA[i]);

                mathOperator = listA[i + 1].ToString();

                num2 = Convert.ToDouble(listA[i + 2]);

                tempResult = mathOperator switch
                {
                    "+" => OperatorList.Add(num1, num2),
                    "-" => OperatorList.Sub(num1, num2),
                    _ => throw new NotImplementedException(),
                };

                listA[i] = tempResult.ToString();
                listA.RemoveAt(i + 1);
                listA.RemoveAt(i + 1);
            }

            if (listA.All(item => !OperatorList.ArithmeticOperators.Contains(item)))
            {
                double sum = 0;
                foreach (string num in listA)
                {
                    sum += Convert.ToDouble(num);
                }
                listA[0] = sum.ToString();
                listA.RemoveRange(1, listA.Count - 1);
            }



        }
    }
}


//for (int i = 1; i < termSeperatorStart.Count - 1; i++)
//{
//    if (OperatorList.BasicOperators.Contains(termSeperatorStart[i]) &&
//    OperatorList.BasicOperators.Contains(termSeperatorStart[i - 1]))
//    {
//        termSeperatorStart.Insert(i, "0");
//    }
//}

//private void operatorprefixdifferiantiator()
//{
//    //termseperatorstart.insert(0, "0");
//    if (operatorlist.basicoperators.contains(termseperatedlist[0]))
//    {
//        for (int i = termseperatedlist.count; i > 0; i++)
//        {
//            termseperatedlist[i] = termseperatedlist[i - 1];
//        }
//        termseperatedlist[0] = "0";
//    }
//}