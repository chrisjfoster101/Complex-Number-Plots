using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Implicits
{
    public class ComplexNum
    {
        private double re;
        private double im;

        public ComplexNum(double real, double imaginary)
        {
            re = real;
            im = imaginary;
        }

        public double GetRe() => re;
        public double GetIm() => im;
        public void SetRe(double real) => re = real;
        public void SetIm(double imaginary) => im = imaginary;
        public override string ToString() => $"{re} + {im}i";

        public static double Mod(ComplexNum z) => Math.Sqrt(z.GetRe() * z.GetRe() + z.GetIm() * z.GetIm());
        public static double Arg(ComplexNum z)
        {
            if (z.GetRe() == 0) return z.GetIm() > 0 ? Math.PI/2 : -Math.PI/2;
            double arg = Math.Atan(z.GetIm() / z.GetRe());
            if (z.GetRe() < 0)
            {
                arg += z.GetIm() >= 0 ? Math.PI : -Math.PI;
            }
            return arg;
        }

        public static ComplexNum Add(ComplexNum z1, ComplexNum z2) => new ComplexNum(z1.GetRe() + z2.GetRe(), z1.GetIm() + z2.GetIm());
        public static ComplexNum Mul(ComplexNum z1, ComplexNum z2) => new ComplexNum(z1.GetRe() * z2.GetRe() - z1.GetIm() * z2.GetIm(), z1.GetRe() * z2.GetIm() + z1.GetIm() * z2.GetRe());
        public static ComplexNum Div(ComplexNum z1, ComplexNum z2) => new ComplexNum((z1.GetRe() * z2.GetRe() + z1.GetIm() * z2.GetIm()) / (z2.GetRe() * z2.GetRe() + z2.GetIm() * z2.GetIm()), (z1.GetIm() * z2.GetRe() - z1.GetRe() * z2.GetIm()) / (z2.GetRe() * z2.GetRe() + z2.GetIm() * z2.GetIm()));
        public static ComplexNum Pow(ComplexNum z, double exponent) => new ComplexNum(Math.Pow(Mod(z), exponent) * Math.Cos(exponent * Arg(z)), Math.Pow(Mod(z), exponent) * Math.Sin(exponent * Arg(z)));
        public static ComplexNum Exp(ComplexNum z) => Mul(new ComplexNum(Math.Exp(z.GetRe()), 0), new ComplexNum(Math.Cos(z.GetIm()), Math.Sin(z.GetIm())));
        public static ComplexNum Sin(ComplexNum z) => new ComplexNum(Math.Sin(z.GetRe()) * Math.Cosh(z.GetIm()), Math.Cos(z.GetRe()) * Math.Sinh(z.GetIm()));
        public static ComplexNum Cos(ComplexNum z) => new ComplexNum(Math.Cos(z.GetRe()) * Math.Cosh(z.GetIm()), -Math.Sin(z.GetRe()) * Math.Sinh(z.GetIm()));
        public static ComplexNum Tan(ComplexNum z) => Div(Sin(z), Cos(z));
    }
}
