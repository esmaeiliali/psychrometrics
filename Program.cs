using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            String option;
            String s1;
            Console.WriteLine("please enter the total pressure in atmosphere or bar");
            s = Console.ReadLine();
            double v = Convert.ToDouble(s);
            Console.WriteLine("is the pressure in atmosphere or bar? if it is in atmosphere write atm and if it is in bar please enter bar");
            s = Console.ReadLine();
            if (s == "bar")
            {
                v = v * 0.986923267;
            }
            Console.WriteLine("please give tG in celcius");
            s1 = Console.ReadLine();
            double tg = Convert.ToDouble(s1);
            Console.WriteLine("enter which parameter you would like to enter?");
            Console.WriteLine("1. R.H");
            Console.WriteLine("2. Absolute Humidity");
            Console.WriteLine("3. wet temperature");
            Console.WriteLine("4. humidity percentege");
            Console.WriteLine("1 or 2 or 3 or 4?");
            option = Console.ReadLine();
            int option1 = Convert.ToInt32(option);
            if (option1 == 1)
            {
                Console.WriteLine("enter R.H?");
                double rh = Convert.ToDouble(Console.ReadLine());
                double pa = (CoolProp.PropsSI("P", "T", tg+273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double paprime = (rh/100)*pa;
                double yprime = ((paprime) / (v - paprime)) * 0.62;
                double H = ((1005 + (1884 * yprime)) * tg) + (yprime * 2502300);
                double vp = v * 101325;
                double vh = 8315 * ((tg + 273) / vp) * (0.034 + (0.05 * yprime));
                double tw = tg - 0.01;
            l1: double yprimew = (CoolProp.PropsSI("P", "T", tw+273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double twprime = tg- ((2260*(yprimew-yprime))/950);
                if (twprime != tw)
                {
                    tw = twprime;
                    goto l1;
                }
                double sum1 = ((yprimew) / (v - yprimew));
                double percentage = (yprime / sum1) * 100;
                Console.WriteLine("value of Absolute Humidity is " + yprime.ToString());
                Console.WriteLine("value of wet temperature is " + tw.ToString());
                Console.WriteLine("value of percent humidity is " + percentage.ToString());
                Console.WriteLine("value of Humid Volume is " + vh.ToString());
                Console.WriteLine("value of Enthalpy is " + H.ToString());
                Console.WriteLine("value of partial pressure is " + paprime.ToString());
            }
            if (option1 == 2)
            {
                Console.WriteLine("enter Absolute Humidity?");
                double yprime = Convert.ToDouble(Console.ReadLine());
                double H = ((1005 + (1884 * yprime)) * tg) + (yprime * 2502300);
                double vp = v * 101325;
                double vh = 8315 * ((tg + 273) / vp) * (0.034 + (0.05 * yprime));
                double paprime = (yprime* v) / (0.62+yprime);
                double t1 = ((CoolProp.PropsSI("P", "T", tg+273.15, "Q", 0, "Water")) * 0.00986923267)/1000;

                double rh = (paprime / t1) * 100;
                double tw = tg - 0.01;
            l2: double yprimew = (CoolProp.PropsSI("P", "T", tw + 273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double twprime = tg - ((2260 * (yprimew - yprime)) / 950);
                if (twprime != tw)
                {
                    tw = twprime;
                    goto l2;
                }
                double sum1 = ((yprimew) / (v - yprimew));
                double percentage = (yprime / sum1) * 100;
                //double percentage = (yprime / yprimew) * 100;
                Console.WriteLine("value of R.H is " + rh.ToString());
                Console.WriteLine("value of wet temperature is " + tw.ToString());
                Console.WriteLine("value of percent humidity is " + percentage.ToString());
                Console.WriteLine("value of Humid Volume is " + vh.ToString());
                Console.WriteLine("value of Enthalpy is " + H.ToString());
                Console.WriteLine("value of partial pressure is " + paprime.ToString());
            }
            if (option1 == 3)
            {
                Console.WriteLine("enter wet temperature?");
                double tw = Convert.ToDouble(Console.ReadLine());
                double yprimew = (CoolProp.PropsSI("P", "T", tw + 273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double yprime = (((tw - tg) * 950) / 2260) + yprimew;
                double H = ((1005 + (1884 * yprime)) * tg) + (yprime * 2502300);
                double vp = v * 101325;
                double vh = 8315 * ((tg + 273) / vp) * (0.034 + (0.05 * yprime));
                double paprime = (yprime * v) / (0.62 + yprime);
                double t1 = (CoolProp.PropsSI("P", "T", tg + 273.15, "Q", 0, "Water")* 0.00986923267)/1000;
                double rh = (paprime / t1) * 100;
                double sum1 = ((yprimew) / (v - yprimew));
                double percentage = (yprime / sum1) * 100;
                //double percentage = (yprime / yprimew) * 100;
                Console.WriteLine("value of Absolute Humidity is " + yprime.ToString());
                Console.WriteLine("value of R.H is " + rh.ToString());
                Console.WriteLine("value of percent humidity is " + percentage.ToString());
                Console.WriteLine("value of Humid Volume is " + vh.ToString());
                Console.WriteLine("value of Enthalpy is " + H.ToString());
                Console.WriteLine("value of partial pressure is " + paprime.ToString());
            }
            if (option1 == 4)
            {
                Console.WriteLine("enter humidity percentage?");
                double percentage = Convert.ToDouble(Console.ReadLine());
                double yprimew = (CoolProp.PropsSI("P", "T", tg + 273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double yprimes = (yprimew / (v - yprimew));
                double yprime = (percentage / 100) * yprimes;
                double H = ((1005 + (1884 * yprime)) * tg) + (yprime * 2502300);
                double vp = v * 101325;
                double vh = 8315 * ((tg + 273) / vp) * (0.034 + (0.05 * yprime));
                double paprime = (yprime * v) / (0.62 + yprime);
                double t1 = (CoolProp.PropsSI("P", "T", tg + 273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double rh = (paprime / t1) * 100;
                double tw = tg - 0.01;
            l3: double yprimew1 = (CoolProp.PropsSI("P", "T", tw + 273.15, "Q", 0, "Water") * 0.00986923267)/1000;
                double twprime = tg - ((2260 * (yprimew1 - yprime)) / 950);
                if (twprime != tw)
                {
                    tw = twprime;
                    goto l3;
                }

                Console.WriteLine("value of Absolute Humidity is " + yprime.ToString());
                Console.WriteLine("value of wet temperature is " + tw.ToString());
                Console.WriteLine("value of R.H is " + rh.ToString());
                Console.WriteLine("value of Humid Volume is " + vh.ToString());
                Console.WriteLine("value of Enthalpy is " + H.ToString());
                Console.WriteLine("value of partial pressure is " + paprime.ToString());
            }
            
            Console.WriteLine("please enter any key to exit");
            Console.ReadKey();
        }
    }
}
