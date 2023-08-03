using System;
using System.Diagnostics.Metrics;

internal class Program
{
    private static void Main(string[] args)
    {
        int Input(string text)
        {
            Console.Write(text);
            return Convert.ToInt32(Console.ReadLine());

        }

        
        void FillArray(int[,] matrix, int minValue = 0, int maxValue = 10)
        {
            maxValue++;
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        void PrintArray(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        void Task54()
        {
            //Задача 54: Задайте двумерный массив.Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //В итоге получается вот такой массив:
            //7 4 2 1
            //9 5 3 2
            //8 4 4 2

            int rows = 6;
            int columns = 5;
            int[,] numbers = new int[rows, columns];
            FillArray(numbers, 1, 10);
            PrintArray(numbers);
            //Console.WriteLine();
            Console.WriteLine("Должно получится:");
            int memory = 0;
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {

                    for (int n = 1; n < numbers.GetLength(1); n++)
                    {
                        if (numbers[i, n] > numbers[i, n - 1])
                        {
                            memory = numbers[i, n - 1];
                            numbers[i, n - 1] = numbers[i, n];
                            numbers[i, n] = memory;
                        }
                    }
                }
                Console.WriteLine();
            }
            PrintArray(numbers);
        }
        //Task54();

        void Task56()
        {
            //Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
            //Например, задан массив:
            //1 4 7 2
            //5 9 2 3
            //8 4 2 4
            //5 2 6 7
            //Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

            int rows = 5;
            int columns = 4;
            int[,] mass = new int[rows, columns];
            FillArray(mass);
            PrintArray(mass);
            int[,] arrSumRows = new int[rows, 2];          
            Console.WriteLine();
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    arrSumRows[i, 0] = i;
                    arrSumRows[i,1] += mass[i,j];
                }
                
            }
            PrintArray(arrSumRows);
            int sum= arrSumRows[0,1];
            int memory=0;
            for (int i = 0; i < arrSumRows.GetLength(0); i++)
            {
                if (sum > arrSumRows[i, 1])
                {
                    sum = arrSumRows[i, 1];
                    memory=i;
                }            
            }
            Console.WriteLine($"наименьшая сумма ={sum} в строке {memory}");
        }
        //Task56();

        void Task58() 
        {
            //Задача 58: Заполните спирально массив 4 на 4 числамиот 1 до 16.
            //01 02 03 04
            //12 13 14 05
            //11 16 15 06
            //10 09 08 07

            int rows = 4;
            int columns = 4;
            int[,] spiral = new int[rows, columns];
            PrintArray(spiral);
            int count = 0;
            int i=0, j=0;
            while (count == rows*columns) 
            {                            
                if (j < columns) j++;
                else i++;
                //spiral[i, j] = count;
                Console.WriteLine($"{count} ");
                count++;                
            }
            //
            //for (int i = 0; i < spiral.GetLength(0); i++)
            //{
            //    for (int j = 0; j < spiral.GetLength(1); j++)
            //    {
            //        spiral[i, j] = count;
            //        count++;
            //    }

            //}
            //Console.WriteLine("//////////////////////////");
            //PrintArray(spiral);
            ///ПОМНЮ, что разбор был сделан, но хочу решить сам 


        }
        //Task58();


        //!!!!!Код, который сгенерировал GPT3.5!!!!!!!!

        static void FillSpiralArray(int[,] arr)
        {
            int value = 1;
            int rowStart = 0;
            int rowEnd = arr.GetLength(0) - 1;
            int colStart = 0;
            int colEnd = arr.GetLength(1) - 1;

            while (value <= arr.GetLength(0) * arr.GetLength(1))
            {
                // Заполнение верхней строки
                for (int col = colStart; col <= colEnd; ++col)
                {
                    arr[rowStart, col] = value++;
                }
                ++rowStart;

                // Заполнение правого столбца
                for (int row = rowStart; row <= rowEnd; ++row)
                {
                    arr[row, colEnd] = value++;
                }
                --colEnd;

                // Заполнение нижней строки
                for (int col = colEnd; col >= colStart; --col)
                {
                    arr[rowEnd, col] = value++;
                }
                --rowEnd;

                // Заполнение левого столбца
                for (int row = rowEnd; row >= rowStart; --row)
                {
                    arr[row, colStart] = value++;
                }
                ++colStart;
            }
        }

        void Main58()
        {
            int M = 4; // Количество строк
            int N = 5; // Количество столбцов
            int[,] spiralArray = new int[M, N];

            FillSpiralArray(spiralArray);

            // Вывод заполненного массива
            for (int i = 0; i < M; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    Console.Write(spiralArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        Main58();


    }
    
}
