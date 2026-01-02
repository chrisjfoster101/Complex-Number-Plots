using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Forms_Implicits
{
    internal class LociGenerator
    {
        private Bitmap graph = new Bitmap(512, 512);
        private ComplexNum bottomLeft;
        private double size;
        private string inequality;

        public LociGenerator(ComplexNum centre, double range)
        {
            size = range;
            bottomLeft = ComplexNum.Add(centre, new ComplexNum(-0.5 * size,-0.5 * size));
            createGraphPaper();
        }
        public Bitmap GetGraph() => graph;


        private bool contourPresent(double x, double y, double d, string[] RPN)
        {
            int sign1 = Math.Sign(evaluate(x, y, RPN));
            if (sign1 != Math.Sign(evaluate(x + d, y, RPN))) return true;
            else if (sign1 != Math.Sign(evaluate(x + d, y + d, RPN))) return true;
            else if (sign1 != Math.Sign(evaluate(x, y + d, RPN))) return true;
            return false;
        }
        private double evaluate(double x, double y, string[] RPN) => EvaluateRPN(RPN, x, y);


        public int scaleX(double x)
        {
            int X = (int)((x - bottomLeft.GetRe()) * 512 / size);
            if (X == 512) return 511;
            return X;
        }
        public int scaleY(double y)
        {
            int Y = (int)(512 - (y - bottomLeft.GetIm()) * 512 / size);
            if (Y == 512) return 511;
            return Y;
        }


        public void createGraphPaper()
        {
            for (int i = 0; i < graph.Width; i++)
            {
                for (int j = 0; j < graph.Height; j++)
                {
                    graph.SetPixel(i, j, Color.White);
                }
            }
            for (int i = (int)bottomLeft.GetRe(); i <= bottomLeft.GetRe() + size; i++)
            {
                int scaledX = scaleX(i) == 512 ? 511 : scaleX(i);
                for (int j = 0; j < 512; j++)
                {
                    graph.SetPixel(scaledX, j, Color.FromArgb(50, 50, 50));
                }
            }
            for (int i = (int)bottomLeft.GetIm(); i <= bottomLeft.GetIm() + size; i++)
            {
                int scaledY = scaleY(i) == 512 ? 511 : scaleY(i);
                for (int j = 0; j < 512; j++)
                {
                    graph.SetPixel(j, scaledY, Color.FromArgb(50, 50, 50));
                }
            }
            for (int i = 0; i < 512; i++)
            {
                int scaledY = scaleY(0);
                int scaledX = scaleX(0);
                if (scaledY < 511 & scaledY >= 0)
                {
                    graph.SetPixel(i, scaledY, Color.Black);
                    graph.SetPixel(i, scaledY + 1, Color.Black);
                }
                if (scaledX < 511 & scaledX >= 0)
                {
                    graph.SetPixel(scaledX, i, Color.Black);
                    graph.SetPixel(scaledX + 1, i, Color.Black);
                }
            }
        }


        public static double EvaluateRPN(string[] RPN, double x, double y)
        {
            Stack RPNstack = new Stack();
            ComplexNum o2;
            foreach (string a in RPN)
            {
                switch (a)
                {
                    case "+":
                        o2 = (ComplexNum)RPNstack.Pop();
                        RPNstack.Push(ComplexNum.Add((ComplexNum)RPNstack.Pop(), o2));
                        break;
                    case "-":
                        o2 = (ComplexNum)RPNstack.Pop();
                        if (!RPNstack.IsEmpty())
                        {
                            RPNstack.Push(ComplexNum.Add((ComplexNum)RPNstack.Pop(), ComplexNum.Mul(new ComplexNum(-1, 0), o2)));
                        }
                        else
                        {
                            RPNstack.Push(ComplexNum.Mul(o2, new ComplexNum(-1, 0)));
                        }
                        break;
                    case "*":
                        o2 = (ComplexNum)RPNstack.Pop();
                        RPNstack.Push(ComplexNum.Mul((ComplexNum)RPNstack.Pop(), o2));
                        break;
                    case "/":
                        o2 = (ComplexNum)RPNstack.Pop();
                        RPNstack.Push(ComplexNum.Div((ComplexNum)RPNstack.Pop(), o2));
                        break;
                    case "^":
                        o2 = (ComplexNum)RPNstack.Pop();
                        RPNstack.Push(ComplexNum.Pow((ComplexNum)RPNstack.Pop(), o2.GetRe()));
                        break;
                    case "sin":
                        RPNstack.Push(ComplexNum.Sin((ComplexNum)RPNstack.Pop()));
                        break;
                    case "cos":
                        RPNstack.Push(ComplexNum.Cos((ComplexNum)RPNstack.Pop()));
                        break;
                    case "tan":
                        RPNstack.Push(ComplexNum.Tan((ComplexNum)RPNstack.Pop()));
                        break;
                    case "exp":
                        RPNstack.Push(ComplexNum.Exp((ComplexNum)RPNstack.Pop()));
                        break;
                    case "mod":
                        RPNstack.Push(new ComplexNum(ComplexNum.Mod((ComplexNum)RPNstack.Pop()), 0));
                        break;
                    case "arg":
                        RPNstack.Push(new ComplexNum(ComplexNum.Arg((ComplexNum)RPNstack.Pop()), 0));
                        break;
                    case "re":
                        RPNstack.Push(new ComplexNum(((ComplexNum)RPNstack.Pop()).GetRe(), 0));
                        break;
                    case "im":
                        RPNstack.Push(new ComplexNum(((ComplexNum)RPNstack.Pop()).GetIm(), 0));
                        break;
                    case "z":
                        RPNstack.Push(new ComplexNum(x, y));
                        break;
                    default:
                        if (a.EndsWith("i"))
                        {
                            if (a == "pi")
                            {
                                RPNstack.Push(new ComplexNum(Math.PI, 0));
                            }
                            else if (a == "i")
                            {
                                RPNstack.Push(new ComplexNum(0, 1));
                            }
                            else
                            {
                                RPNstack.Push(new ComplexNum(0, double.Parse(a.TrimEnd('i'))));
                            }
                        }
                        else
                        {
                            RPNstack.Push(new ComplexNum(double.Parse(a), 0));
                        }
                        break;
                }
            }
            double result = ((ComplexNum)RPNstack.Pop()).GetRe();
            return result;
        }
        public static string[] ToRPN(string infix)
        {
            List<string> infixList = new List<string>();
            Stack output = new Stack();
            Stack operators = new Stack();
            Dictionary<string, int> precedence = new Dictionary<string, int>();
            precedence.Add("+", 1);
            precedence.Add("-", 1);
            precedence.Add("*", 2);
            precedence.Add("/", 2);
            precedence.Add("^", 3);
            List<string> functions = new List<string>();
            functions.Add("sin");
            functions.Add("cos");
            functions.Add("tan");
            functions.Add("exp");
            functions.Add("mod");
            functions.Add("arg");
            functions.Add("re");
            functions.Add("im");

            string current = "";
            foreach (char c in infix)
            {
                if (c == ' ') continue;

                if (precedence.ContainsKey(c.ToString()) | c == '(' | c == ')')
                {
                    if (current != "") infixList.Add(current);
                    current = c.ToString();
                }
                else if (current == "(" | current == ")" | precedence.ContainsKey(current.ToString()))
                {
                    infixList.Add(current);
                    current = c.ToString();
                }
                else
                {
                    current += c.ToString();
                }
            }
            infixList.Add(current);

            foreach (string a in infixList)
            {
                if (precedence.ContainsKey(a))
                {
                    while (!operators.IsEmpty())
                    {
                        if ((string)operators.Peek() == "(" || precedence[(string)operators.Peek()] < precedence[a])
                        {
                            break;
                        }
                        output.Push(operators.Pop());
                    }
                    operators.Push(a);
                }
                else if (functions.Contains(a))
                {
                    operators.Push(a);
                }
                else if (a == "(")
                {
                    operators.Push(a);
                }
                else if (a == ")")
                {
                    while ((string)operators.Peek() != "(")
                    {
                        output.Push(operators.Pop());
                    }
                    operators.Pop();
                    if (!operators.IsEmpty())
                    {
                        if (functions.Contains(operators.Peek()))
                        {
                            output.Push(operators.Pop());
                        }
                    }
                }
                else
                {
                    output.Push(a);
                }
            }
            while (!operators.IsEmpty())
            {
                output.Push(operators.Pop());
            }

            List<string> ret1 = new List<string>();
            while (!output.IsEmpty()) ret1.Add((string)output.Pop());
            string[] ret2 = new string[ret1.Count];
            for (int i = 0; i < ret2.Length; i++)
            {
                ret2[ret2.Length - 1 - i] = ret1[i];
            }
            return ret2;
        }


        private void subdivide(int depth, double x, double y, double d, string[] RPN)
        {
            createTree(depth + 1, x, y, d / 2, RPN);
            createTree(depth + 1, x + d / 2, y, d / 2, RPN);
            createTree(depth + 1, x, y + d / 2, d / 2, RPN);
            createTree(depth + 1, x + d / 2, y + d / 2, d / 2, RPN);
        }
        private void createTree(int depth, double x, double y, double d, string[] RPN)
        {
            if (depth < 6)
            {
                subdivide(depth, x, y, d, RPN);
            }
            else if (contourPresent(x, y, d, RPN))
            {
                if (depth < 9)
                {
                    subdivide(depth, x, y, d, RPN);
                }
                else if (Math.Abs(evaluate(x, y, RPN)) < 0.25 & inequality != "<" & inequality != ">")
                {
                    int scaledX = scaleX(x);
                    int scaledY = scaleY(y);
                    graph.SetPixel(scaledX, scaledY, Color.Red);
                    if (scaledX < 511)
                    {
                        graph.SetPixel(scaledX + 1, scaledY, Color.Red);
                    }
                    if (scaledY < 511)
                    {
                        graph.SetPixel(scaledX, scaledY + 1, Color.Red);
                        if (scaledX < 511)
                        {
                            graph.SetPixel(scaledX + 1, scaledY + 1, Color.Red);
                        }
                    }
                }
            }
            else if (Math.Sign(evaluate(x, y, RPN)) > 0)
            {
                if (inequality == "≥" | inequality == ">")
                {
                    for (int i = scaleX(x); i <= scaleX(x + d); i++)
                    {
                        for (int j = scaleY(y + d); j <= scaleY(y); j++)
                        {
                            if (graph.GetPixel(i, j).B == 255)
                            {
                                graph.SetPixel(i, j, Color.FromArgb(255, 170, 170));
                            }
                            else if (graph.GetPixel(i, j).B == 0 & graph.GetPixel(i, j).R == 0)
                            {
                                graph.SetPixel(i, j, Color.FromArgb(100, 0, 0));
                            }
                            else if (graph.GetPixel(i, j).B == 50 & graph.GetPixel(i, j).R == 50)
                            {
                                graph.SetPixel(i, j, Color.FromArgb(128, 0, 0));
                            }
                        }
                    }
                }
            }
            else if (inequality == "≤" | inequality == "<")
            {
                for (int i = scaleX(x); i <= scaleX(x + d); i++)
                {
                    for (int j = scaleY(y + d); j <= scaleY(y); j++)
                    {
                        if (graph.GetPixel(i, j).B == 255)
                        {
                            graph.SetPixel(i, j, Color.FromArgb(255, 170, 170));
                        }
                        else if (graph.GetPixel(i, j).B == 0 & graph.GetPixel(i, j).R == 0)
                        {
                            graph.SetPixel(i, j, Color.FromArgb(100, 0, 0));
                        }
                        else if (graph.GetPixel(i, j).B == 50 & graph.GetPixel(i, j).R == 50)
                        {
                            graph.SetPixel(i, j, Color.FromArgb(128, 0, 0));
                        }
                    }
                }
            }
        }


        public Bitmap Generate(string equation, string inequality)
        {
            this.inequality = inequality;
            string[] RPN;
            try
            {
                RPN = ToRPN(equation);
                createTree(0, bottomLeft.GetRe(), bottomLeft.GetIm(), size, RPN);
            }
            catch
            {
                throw new EquationException();
            }
            return graph;
        }
    }
}
