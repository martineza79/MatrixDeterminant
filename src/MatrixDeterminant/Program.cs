using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixDeterminant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // asks user to input order of determinant
                Console.Write("Enter the order of determinant: ");
                int n = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Order of determinant entered: " + n.ToString() + "\n");
                if (n > 0)
                {
                    double[,] thisMatrix = new double[n, n];

                    // inputs the matrix elements
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write("Enter element [" + (i + 1) + "]" + "[" + (j + 1) + "]: ");
                            thisMatrix[i, j] = double.Parse(Console.ReadLine().ToString());
                        }
                    }
                    // display the entered matrix
                    Console.WriteLine("Matrix entered: ");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(thisMatrix[i, j].ToString() + " ");
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("Value of the determinant is: " + Determinant(thisMatrix));
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Order should be a positive integer.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadLine();
            }
        }

        //this method determines the sign of the elements
        static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
                return 1;
            
            else
                return -1;
        }

        // CreateSmallerMatrix method determines the sub matrix corresponding to a given element
        static double[,] CreateSmallerMatrix(double[,] input, int i, int j)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            double[,] output = new double[order - 1, order - 1];
            int x = 0, y = 0; 
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }

        // Determinant method determines the value of determinant using recursion
        static double Determinant(double[,] input)
        {
            int order = int.Parse(System.Math.Sqrt(input.Length).ToString());
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j< order; j++)
                {
                    double[,] Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * Determinant(Temp));                    
                }
                return value;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }
    }        
}
