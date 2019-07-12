using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace Hw2_AR_141044073
{
    class Program
    {
        public const int MATRIX_ROWS =5;
        public const int MATRIX_COLUMNS = 9;
        public static DenseMatrix matrix;
        public static double[,] result1 = new double[3, 3];
        public static double[,] result2 = new double[3, 3];
        public static double[,] result3 = new double[3, 3];
        static void Main(string[] args)
        {

            double[] ad = new double[] { 0, 1, 0, 2, 2.01 };
            double[] bd = new double[] { 0, 0, 1, 1, 1.01 };

            double[] x = new double[] { 200, 300, 200, 300 ,400};
            double[] y = new double[] { 5,5, 100, 100 ,100};

            double[] u1 = new double[] { 936, 1169, 936, 1167,1396};
            double[] v1 = new double[] { 524, 528, 758, 762,764 };

            double[] u2 = new double[] { 737, 972, 735, 969 ,1204};
            double[] v2 = new double[] { 493, 487, 731, 728 ,722};

            double[] u3 = new double[] { 997, 1239, 990, 1228,1458 };
            double[] v3 = new double[] { 637, 656, 893, 907,922 };
 

            double[,] tmp_matrix = new double[2 * MATRIX_ROWS, MATRIX_COLUMNS];
            
            for (int i = 0; i < 2 * MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {

                    tmp_matrix[i, j] = 0;
                }
            }
            matrix = DenseMatrix.OfArray(tmp_matrix);
            

            Console.WriteLine("********* PART1 -4 *********\n");

            Console.WriteLine("\nFor Image1 Homography Matrix\n");
            result1=calculateHomographyMatrix(x, y, u1, v1);
            PrintResult(result1);
            Console.WriteLine("\n----------------Image1------------------------\n");
            threePoint1();
            
            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("\nFor Image2 Homography Matrix\n");
            result2=calculateHomographyMatrix(x, y, u2, v2);
            PrintResult(result2);
            Console.WriteLine("\n----------------Image2------------------------\n");

            threePoint2();
            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("\nFor Image3 Homography Matrix\n");
            result3=calculateHomographyMatrix(x, y, u3, v3);
            PrintResult(result3);
            Console.WriteLine("\n----------------Image3------------------------\n");

            threePoint3();

            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("\n********* PART1 -5 *********\n");
            
            double[,] source = new double[3, 1];
            source= setSource(7.5,5.5);
            Console.Write("x = "+ source[0,0].ToString("0.0000") + "     ");
            Console.Write("y = " + source[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, source);

            source = setSource(6.3, 3.3);
            Console.Write("x = " + source[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + source[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, source);

            source = setSource(0.1, 0.1);
            Console.Write("x = " + source[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + source[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, source);

            Console.WriteLine();

            Console.WriteLine("\n********* PART1 -6 *********\n");

            double[,] target = new double[3, 1];
            target = setSource(500, 400);
            Console.Write("u = " + target[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + target[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, target);
            Console.WriteLine();
            target = setSource(86, 167);
            Console.Write("u = " + target[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + target[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, target);
            target = setSource(10, 10);
            Console.Write("u = " + target[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + target[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, target);
            Console.ReadLine();
        }
        public static void threePoint1()
        {

            double[,] img1 = new double[3, 1];
            img1 = setSource(200, 5);
            Console.Write("x = " + img1[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, img1);

            img1 = setSource(936, 524);
            Console.Write("u = " + img1[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, img1);
            Console.WriteLine("");

            img1 = setSource(200, 100);
            Console.Write("x = " + img1[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, img1);

            img1 = setSource(936, 758);
            Console.Write("u = " + img1[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, img1);
            Console.WriteLine("");
            img1 = setSource(300, 100);
            Console.Write("x = " + img1[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result1, img1);

            img1 = setSource(1167, 762);
            Console.Write("u = " + img1[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img1[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result1, img1);
            Console.WriteLine("");

        }


        public static void threePoint2()
        {

            double[,] img2 = new double[3, 1];
            img2 = setSource(200, 5);
            Console.Write("x = " + img2[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result2, img2);

            img2 = setSource(737, 493);
            Console.Write("u = " + img2[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result2, img2);
            Console.WriteLine("");

            img2 = setSource(200, 100);
            Console.Write("x = " + img2[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result2, img2);

            img2 = setSource(735, 731);
            Console.Write("u = " + img2[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result2, img2);
            Console.WriteLine("");

            img2 = setSource(300, 100);
            Console.Write("x = " + img2[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result2, img2);

            img2 = setSource(969, 728);
            Console.Write("u = " + img2[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img2[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result2, img2);
            Console.WriteLine("");

        }
        public static void threePoint3()
        {
            double[,] img3 = new double[3, 1];
            img3 = setSource(200, 5);
            Console.Write("x = " + img3[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result3, img3);

            img3 = setSource(997, 637);
            Console.Write("u = " + img3[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result3, img3);
            Console.WriteLine();

            img3 = setSource(200, 100);
            Console.Write("x = " + img3[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result3, img3);

            img3 = setSource(990,893);
            Console.Write("u = " + img3[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result3, img3);
            Console.WriteLine();

            img3 = setSource(300, 100);
            Console.Write("x = " + img3[0, 0].ToString("0.0000") + "     ");
            Console.Write("y = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateTarget(result3, img3);

            img3 = setSource(1228, 907);
            Console.Write("u = " + img3[0, 0].ToString("0.0000") + "   ");
            Console.Write("v = " + img3[1, 0].ToString("0.0000"));
            Console.WriteLine();
            calculateSource(result3, img3);
            Console.WriteLine();
        }

            public static double[,] setSource(double x_s,double y_s)
        {
            double[,] source = new double[3, 1];
            source[0, 0] = x_s;
            source[1, 0] = y_s;
            source[2, 0] = 1;
            return source;
        }

            public static double[,] calculateHomographyMatrix(double[] x, double[] y, double[] u, double[] v)
        {
            double[,] result = new double[3, 3];
            for (int i = 1; i <= MATRIX_ROWS; i++)
            {
                matrix[2 * i - 1 - 1, 0] = -x[i - 1];
                matrix[2 * i - 1 - 1, 1] = -y[i - 1];
                matrix[2 * i - 1 - 1, 2] = -1;
                matrix[2 * i - 1 - 1, 3] = 0;
                matrix[2 * i - 1 - 1, 4] = 0;
                matrix[2 * i - 1 - 1, 5] = 0;
                matrix[2 * i - 1 - 1, 6] = x[i - 1] * u[i - 1];
                matrix[2 * i - 1 - 1, 7] = u[i - 1] * y[i - 1];
                matrix[2 * i - 1 - 1, 8] = u[i - 1];
                matrix[2 * i - 1, 0] = 0;
                matrix[2 * i - 1, 1] = 0;
                matrix[2 * i - 1, 2] = 0;
                matrix[2 * i - 1, 3] = -x[i - 1];
                matrix[2 * i - 1, 4] = -y[i - 1];
                matrix[2 * i - 1, 5] = -1;
                matrix[2 * i - 1, 6] = x[i - 1] * v[i - 1];
                matrix[2 * i - 1, 7] = v[i - 1] * y[i - 1];
                matrix[2 * i - 1, 8] = v[i - 1];
            }
            var svd = matrix.Svd(true);
            var homgraphy = svd.VT;
            var homography_transpose = homgraphy.Transpose();
            int k = 0;
            for (int i = 0; i < 3; i++)
            { for (int j = 0; j < 3; j++)
                {
                    result[i, j] = homography_transpose[k,8];
                    k++;
                }
            }
            return result;
           // Console.WriteLine("");
        }

        public static double[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s  
            // do error checking here?  
            double[][] res = new double[rows][];
            for (int i = 0; i < rows; ++i)
                res[i] = new double[cols];
            // auto init to 0.0  
            return res;
        }

        public static void calculateTarget(double[,] matrixA,double[,] matrixB)
        {
            int aRows = 3;
            int aCols = 3;
            int bRows = 3;
            int bCols = 1;
            
            double[][] target = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i)
            {
                for (int j = 0; j < bCols; ++j)
                { // each col of B
                    for (int k = 0; k < aCols; ++k)
                    {
                        target[i][j] += matrixA[i,k] * matrixB[k,j];
                        
                    }
                   
                }
               
            }
            target[0][0] = target[0][0] / target[2][0];
            target[1][0] = target[1][0] / target[2][0];

            Console.Write("u = " + target[0][0].ToString("0.0000") + "   ");
            Console.Write("v = " + target[1][0].ToString("0.0000"));
            Console.WriteLine();

            //for (int i=0; i<target.Length-1; i++)
            //{
            //    for(int j=0; j<target[0].Length; j++)
            //    {
            //        Console.Write("u = {0.0000}   ",target[i][j]);
            //    }
            //    Console.WriteLine();
            //}

        }


        public static void calculateSource(double[,] matrixA, double[,] matrixB)
        {
            var tmp = DenseMatrix.OfArray(matrixA);
            var h_inverse = tmp.Inverse();
            calculateSource_(h_inverse.ToArray(), matrixB);
        }
        public static void calculateSource_(double[,] matrixA, double[,] matrixB)
        {
            int aRows = 3;
            int aCols = 3;
            int bRows = 3;
            int bCols = 1;

            double[][] target = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i)
            {
                for (int j = 0; j < bCols; ++j)
                { // each col of B
                    for (int k = 0; k < aCols; ++k)
                    {
                        target[i][j] += matrixA[i, k] * matrixB[k, j];

                    }

                }

            }
            target[0][0] = target[0][0] / target[2][0];
            target[1][0] = target[1][0] / target[2][0];

            Console.Write("x = " + target[0][0].ToString("0.0000") + "   ");
            Console.Write("y = " + target[1][0].ToString("0.0000"));
            Console.WriteLine();

            //for (int i=0; i<target.Length-1; i++)
            //{
            //    for(int j=0; j<target[0].Length; j++)
            //    {
            //        Console.Write("u = {0.0000}   ",target[i][j]);
            //    }
            //    Console.WriteLine();
            //}

        }



        public static void PrintResult(double[,] result)
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                   // result[i, j] = result[i, j] / result[2, 2];
                    Console.Write(result[i, j].ToString("0.0000") + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
