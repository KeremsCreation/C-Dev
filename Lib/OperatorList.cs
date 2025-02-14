using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Lib
{

    class OperatorList
    {
        public static string[] BasicOperators = [ButtonLabels.Plus, ButtonLabels.Minus, ButtonLabels.Multiply, ButtonLabels.Divide, ButtonLabels.Mod];
        public static double Add(double a, double b) => a + b;
        public static double Sub(double a, double b) => a - b;
        public static double Mul(double a, double b) => a * b;
        public static double Div(double a, double b) => b != 0 ? a / b : double.NaN;
        public static double Mod(double a, double b) => a % b;
        public static double Squ(double a) => a * a;
        public static double Sqr(double a) => Math.Sqrt(a);
    }
}
