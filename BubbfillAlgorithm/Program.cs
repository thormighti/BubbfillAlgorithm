using System;

namespace BubbfillAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Bubbfill algortithm. /n Press 1 for bubbfill I and 2 for bubbfill II");
            int userDecision = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the first initial guess ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Input the second initial guess ");
            double x2 = double.Parse(Console.ReadLine());
            double x3 = 0 , x4 = 0;
            double slope = (Function(x1) - Function(2)) / (x1 - x2);


            
            switch (userDecision)
            {
                case 1:
                    while(Function(x1)* Function(x2) < 0)
                    {
                        x3 = x1 - (Function(x1) / slope);
                        double diff = Function(x3) / DeriFunction(x3);
                        
                        x1 = x3 - diff;
                        x2 = x3 + diff;
                       
                    }
                    Console.WriteLine($"The root is {x3}");
                    break;
                case 2: 
                    while(Function(x1) * Function(x2) < 0)
                    {
                        x3 = x1 - (Function(x1) / slope); // using the chinese algorithm
                        double diff = Function(x3) / DeriFunction(x3);
                        x4 = x3 - diff; // renewal of the approximate by newton raphson
                        // replacng the two initials
                        x1 = x3;
                        x2 = x4;
                    }
                    Console.WriteLine($"The root is {x4}");
                    break;
                default: break;
            }
            //Console.WriteLine(Function(0.772880442358979));
            //Console.WriteLine(DeriFunction(0.772880442358979));
            //Console.WriteLine(Function(0.772880442358979)/ DeriFunction(0.772880442358979));
        }
        static double Function(double x)
        {
            return x + 0.5*(1 - Math.Exp(-x)) - 1;
        }
        static double DeriFunction(double x)
        {
            return 1 + (Math.Exp(-x)/2);
        }
    }
}
