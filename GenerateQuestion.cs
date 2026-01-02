using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Implicits
{
    public class GenerateQuestion
    {
        public string equation;
        public string inequality;
        private static Random rnd = new Random();
        public string type;
        public ComplexNum keyPoint;
        public ComplexNum keyPoint2;

        public GenerateQuestion(string questionType, bool useInequality)
        {
            keyPoint = new ComplexNum(0, 0);
            type = questionType;
            if (questionType == "Circle")
            {
                string[] randomvalues = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    double randnum;
                    if (i < 2)
                    {
                        randnum = rnd.Next(-10, 11) * 0.5;
                        if (i == 0) keyPoint.SetRe(-randnum);
                        else keyPoint.SetIm(-randnum);


                        if (randnum == 0)
                        {
                            randomvalues[i] = "";
                        }
                        else if (randnum > 0)
                        {
                            randomvalues[i] = "+" + randnum;
                        }
                        else
                        {
                            randomvalues[i] = randnum.ToString();
                        }

                        if (i == 1 & randomvalues[1] != "")
                        {
                            randomvalues[1] += "i";
                        }
                    }
                    else
                    {
                        randnum = rnd.Next(1, 11) * 0.5;
                        randomvalues[2] = randnum.ToString();
                    }
                }
                equation = $"mod(z{randomvalues[0]}{randomvalues[1]})-{randomvalues[2]}";
            }
            else if (questionType == "Line")
            {
                string[] randomvalues = new string[4];
                keyPoint2 = new ComplexNum(0, 0);
                for (int i = 0; i < 4; i++)
                {
                    double randnum = rnd.Next(-5, 6);
                    switch (i)
                    {
                        case 0:
                            keyPoint.SetRe(-randnum);
                            break;
                        case 1:
                            keyPoint.SetIm(-randnum);
                            break;
                        case 2:
                            keyPoint2.SetRe(-randnum);
                            break;
                        case 3:
                            keyPoint2.SetIm(-randnum);
                            break;
                    }

                    if (randnum == 0)
                    {
                        randomvalues[i] = "";
                    }
                    else if (randnum > 0)
                    {
                        randomvalues[i] = "+" + randnum;
                    }
                    else
                    {
                        randomvalues[i] = randnum.ToString();
                    }

                    if (i % 2 == 1 & randomvalues[i] != "")
                    {
                        randomvalues[i] += "i";
                    }
                    equation = $"mod(z{randomvalues[0]}{randomvalues[1]})-mod(z{randomvalues[2]}{randomvalues[3]})";
                }
            }
            else if (questionType == "Half-line")
            {
                string[] randomvalues = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    double randnum;
                    if (i < 2)
                    {
                        randnum = rnd.Next(-10, 11) * 0.5;
                        if (i == 0) keyPoint.SetRe(-randnum);
                        else keyPoint.SetIm(-randnum);

                        if (randnum == 0)
                        {
                            randomvalues[i] = "";
                        }
                        else if (randnum > 0)
                        {
                            randomvalues[i] = "+" + randnum;
                        }
                        else
                        {
                            randomvalues[i] = randnum.ToString();
                        }

                        if (i == 1 & randomvalues[1] != "")
                        {
                            randomvalues[1] += "i";
                        }
                    }
                    else
                    {
                        string[] possible = { "pi/6", "pi/4", "pi/3", "pi/2", "2*pi/3", "3*pi/4", "5*pi/6"};
                        randomvalues[2] = possible[rnd.Next(possible.Length)];
                        if (rnd.Next(0,2) == 0)
                        {
                            randomvalues[2] = "+" + randomvalues[2];
                        }
                        else
                        {
                            randomvalues[2] = "-" + randomvalues[2];
                        }
                    }
                }
                equation = $"arg(z{randomvalues[0]}{randomvalues[1]}){randomvalues[2]}";
            }

            if (useInequality)
            {
                string[] inequalities = { "≤", "≥", "<", ">" };
                inequality = inequalities[rnd.Next(0, 4)];
            }
            else
            {
                inequality = "=";
            }
        }
        public override string ToString()
        {
            string LHS = equation.Substring(0, equation.IndexOf(')') + 1);
            string RHS = equation.Substring(equation.IndexOf(')') + 1);
            if (RHS[0] == '-')
            {
                return LHS + inequality + RHS.Substring(1);
            }
            else
            { 
                return LHS + inequality + "-" + RHS.Substring(1);
            }
        }
    }
}
