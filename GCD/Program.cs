using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Eu
{
    class Program
    {
        List<int> number = new List<int>();

        static void Main(string[] args)
        {
            Program program = new Program();

            program.Input();
            program.ChackNumber();

            Console.ReadLine();
        }

        void Output(int Fgcd)
        {
            Console.WriteLine("\nGCD = {0}", Fgcd);
        }
        void gcdcalculateLevel2(ref int Fgcd,ref int time, ref int modgcd,ref int n)
        {
            do
            {
                time = Fgcd / number[n+1];
                modgcd = Fgcd % number[n+1];

                Console.WriteLine("{0} = {1}({2}) + {3}", Fgcd, number[n+1], time, modgcd);

                Fgcd = number[n+1];
                number[n+1] = modgcd;
                
                if (modgcd == 0)
                {
                    break;
                }
            } while (modgcd > 0);
        }
        void gcdcalculate(ref int Fgcd, ref int Bgcd, ref int time, ref int modgcd)
        {
            do
            {
                time = Fgcd / Bgcd;
                modgcd = Fgcd % Bgcd;

                Console.WriteLine("{0} = {1}({2}) + {3}", Fgcd, Bgcd, time, modgcd);

                Fgcd = Bgcd;
                Bgcd = modgcd;
                if (modgcd == 0)
                {
                    break;
                }
            } while (modgcd > 0);
        }
        void SetotherNumber(ref int Fgcd, ref int Bgcd, ref int startcount0, ref int startcount1,ref int nowgcd)
        {
            Console.WriteLine("{0} {1}", startcount0, startcount1);
            Fgcd = Math.Max(nowgcd,number[startcount0]);
            Bgcd = Math.Min(nowgcd, number[startcount0]);
            startcount0++;
            startcount1++;
        }
        void setonetwo(ref int Fgcd, ref int Bgcd, ref int startcount0, ref int startcount1)
        {
            Console.WriteLine("{0} {1}", startcount0, startcount1);
            Fgcd = Math.Max(number[startcount0], number[startcount1]);
            Bgcd = Math.Min(number[startcount0], number[startcount1]);
            startcount0++;
            startcount1++;
        }
        void Input()
        {

            int a = 1, x = 0, n = 1;
            while (a > 0)
            {
                Console.Write("Enter Number {0} : ", n);
                x = int.Parse(Console.ReadLine());

                number.Add(x);
                n++;
                if (x <= 0)
                {
                    break;
                }
            }
        }
        void ChackNumber()
        {
            int countofInput = number.Count();
            int n = -1;
            foreach (int Runnum in number)
            {
                n++;
            }
            if (n == 2)
                Euclidean1();
            if (n > 2)
                Euclidean2(countofInput);
            if (n < 2)
                Console.WriteLine("Error");

        }
        void Euclidean1()
        {
            int Fgcd = 0, Bgcd = 0, time = 0, startcount0 = 0, startcount1 = 1, modgcd = 0;


            setonetwo(ref Fgcd, ref Bgcd, ref startcount0, ref startcount1);
            gcdcalculate(ref Fgcd, ref Bgcd, ref time, ref modgcd);

            Output(Fgcd);
        }
        void Euclidean2(int countofInput)
        {
            int Fgcd = 0, Bgcd = 0, n = 0, time = 0, startcount0 = 0, startcount1 = 1, modgcd = 0,nowgcd=0;


            Console.WriteLine("\n{0} with {1}", number[n], number[n+1]);

            setonetwo(ref Fgcd, ref Bgcd,ref startcount0, ref startcount1);
            gcdcalculate(ref Fgcd, ref Bgcd, ref time, ref modgcd);
            countofInput--;
            nowgcd = Fgcd;

            while(countofInput > 2)
            {
                countofInput--;
                n++;
                Console.WriteLine(countofInput);

                if(number[n+1] < 0)
                {
                    Console.WriteLine("\n{0} with {0}", nowgcd);
                    Output(nowgcd);
                }
                Console.WriteLine("\n{0} with {1}", nowgcd, number[n+1]);
                SetotherNumber(ref Fgcd, ref Bgcd, ref startcount0, ref startcount1,ref nowgcd);
                gcdcalculateLevel2(ref Fgcd,ref time, ref modgcd,ref n);

            }
            Output(Fgcd);
        }
    }
}
