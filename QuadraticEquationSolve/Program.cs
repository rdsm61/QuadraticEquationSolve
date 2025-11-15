using System;

namespace QuadraticEquationSolve
{
    enum QuadraticEquationType
    {
        noSoultions = -1,
        oneRoot = 0,
        twoRoots = 1
    }
    class Solve
    {
        public static QuadraticEquationType FindRoots(double a, double b, double c, out double? x1, out double? x2)
        {
            double discriminant = b * b - 4 * a * c;
            QuadraticEquationType q;

            if (discriminant < 0)
            {
                q = QuadraticEquationType.noSoultions;
                x1 = x2 = null;
            } else if(discriminant == 0){
                q = QuadraticEquationType.oneRoot;
                x1 = x2 = -b / (2 * a);
            } else
            {
                q = QuadraticEquationType.twoRoots;
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            }

            return q;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter quadratic equation coefficents: ");
            string temp = Console.ReadLine();
            try
            {
                double a = double.Parse(temp.Split()[0]);
                double b = double.Parse(temp.Split()[1]);
                double c = double.Parse(temp.Split()[2]);
                QuadraticEquationType qe = Solve.FindRoots(a, b, c, out double? x1, out double? x2);
                switch (qe)
                {
                    case QuadraticEquationType.noSoultions:
                        Console.WriteLine("There are no real roots of the equation with coefficients {0}, {1}, {2}",
                            a, b, c);
                        break;
                    case QuadraticEquationType.oneRoot:
                        Console.WriteLine("There is one real double root of the equation with coefficients {0}, {1}, {2}: x1 = {3:N3}",
                            a, b, c, x1);
                        break;
                    case QuadraticEquationType.twoRoots:
                        Console.WriteLine("There are two real roots of the equation with coefficients {0}, {1}, {2}: x1 = {3:N3}, x2 = {4:N3}",
                            a, b, c, x1, x2);
                        break;
                    default:
                        Console.WriteLine("Unrecognized error");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter three numbers");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Enter three coefficient");
            }

        }
            
    }
}
