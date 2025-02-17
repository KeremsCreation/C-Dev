using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lib
{

    class OperatorList
    {
        public static string[] AdditiveOperators = [ButtonLabels.Plus, ButtonLabels.Minus];

        public static string[] MultiplicativeOperators = [ButtonLabels.Multiply, ButtonLabels.Divide, ButtonLabels.Mod];

        public static string[] ArithmeticOperators = AdditiveOperators.Concat(MultiplicativeOperators).ToArray();
        public static double Add(double a, double b) => a + b;
        public static double Sub(double a, double b) => a - b;
        public static double Mul(double a, double b) => a * b;
        public static double Div(double a, double b) => b != 0 ? a / b : double.NaN;
        public static double Mod(double a, double b) => a % b;
        public static double Squ(double a) => a * a;
        public static double Sqr(double a) => Math.Sqrt(a);
    }
}
