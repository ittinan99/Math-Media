using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Euclid
{
    class Program
    {
        List<int> ListofInputnumber = new List<int>();

        static void Main(string[] args)
        {
            Program program = new Program();

            for(int n = 1;n>0;n++)
            {
                Console.Write("\nEnter the value more than 0 to start the Program ==> ");
                int StartProgram = int.Parse(Console.ReadLine());

                if (StartProgram > 0)
                {
                    program.Input();
                    program.ChackNumber();
                }
                if (StartProgram <= 0)
                {
                    Console.WriteLine("Enter to close..");
                    break;
                }
            }
            Console.ReadLine();
        }
        void Output(int Ans)
        {
            ListofInputnumber.Clear();
            Console.WriteLine("\nGCD = {0}", Ans);
        }
        void gcdcalculate(ref int Fgcd,ref int TimeOfDivide, ref int modgcd,ref int RunNumberOnList)
        {
            do
            {
                TimeOfDivide = Fgcd / ListofInputnumber[RunNumberOnList + 1];
                modgcd = Fgcd % ListofInputnumber[RunNumberOnList + 1];

                Console.WriteLine("{0} = {1}({2}) + {3}", Fgcd, ListofInputnumber[RunNumberOnList + 1], TimeOfDivide, modgcd);

                Fgcd = ListofInputnumber[RunNumberOnList + 1];
                ListofInputnumber[RunNumberOnList + 1] = modgcd;
                
                if (modgcd == 0)
                {
                    break;
                }
            } while (modgcd > 0);
        }
        void Input()
        {
            int a = 1, InputNumber = 0, ShowNumber = 1;
            while (a > 0)
            {
                Console.Write("Enter Number {0} : ", ShowNumber);
                InputNumber = int.Parse(Console.ReadLine());

                ListofInputnumber.Add(InputNumber);
                ShowNumber++;

                if (InputNumber <= 0)
                {
                    break;
                }
            }
        }
        void ChackNumber()
        {
            int countofInput = ListofInputnumber.Count();
            int n = -1;
            foreach (int Runnum in ListofInputnumber)
            {
                n++;
            }

            if (n >= 2)
                Euclidean(countofInput);
            if (n == 1)
                Console.WriteLine("GCD = {0}",ListofInputnumber[0]);
            if (n < 1)
                Console.WriteLine("Error");
        }
        void Euclidean(int countofInput)
        {
            int Fgcd = ListofInputnumber[0],RunNumberOnList = 0, TimeOfDivide = 0,modgcd = 0;

            Console.WriteLine("\n{0} with {1}", ListofInputnumber[RunNumberOnList], ListofInputnumber[RunNumberOnList + 1]);

            gcdcalculate(ref Fgcd, ref TimeOfDivide, ref modgcd, ref RunNumberOnList);

            countofInput--;
            
            while(countofInput > 2)
            {
                countofInput--;
                
                //Console.WriteLine(countofInput);    เช็คว่าในlistเหลือกี่ตัว

                RunNumberOnList++;  

                if(ListofInputnumber[RunNumberOnList + 1] < 0)
                {
                    Console.WriteLine("\n{0} with {0}", Fgcd, ListofInputnumber[RunNumberOnList + 1]);
                    Output(Fgcd);
                }
                Console.WriteLine("\n{0} with {1}", Fgcd, ListofInputnumber[RunNumberOnList + 1]);
                gcdcalculate(ref Fgcd,ref TimeOfDivide, ref modgcd,ref RunNumberOnList);
            }

            Output(Fgcd);
        }
    }
}
