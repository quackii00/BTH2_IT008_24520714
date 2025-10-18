using System;

namespace BTH02_Bai03
{
    class program
    {
        static void Main(string[] args)
        {
            int m, n,k;
            int[,] arr =InputArr(out m, out n);
            Console.Write("Nhap phan tu muon tim: ");
            k = int.Parse(Console.ReadLine());
            OutArr(arr, m, n);
            FindItem(arr, k);
            OutPrimeItems(arr);
            MaxPrimeRow(arr);

        }


        //(a) Nhập ma trận 2 chiều các số nguyên
        static int[,] InputArr(out int m, out int n)
        {
            Console.Write("Nhap so hang: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] parts = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = int.Parse(parts[j]);
                }
            }
            return arr;
        }

        //(a) Xuất ma trận
        static void OutArr(int[,] arr,int m, int n)
        {
            Console.WriteLine($"(a) Ma tran {m}x{n}");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j]+" ");
                }
                Console.WriteLine();
            }
        }

        //(b)Tìm kiếm 1 phần tử trong ma trận
        static void FindItem(int[,] arr, int item)
        {
            Console.WriteLine($"(b) Phan tu {item} nam o vi tri: ");
            for(int i = 0;i < arr.GetLength(0);i++)
            {
                for(int j=0; j < arr.GetLength(1);j++)
                {
                    if (arr[i,j] == item)
                    {
                        Console.WriteLine($"({i},{j})");
                    }    
                }    
            }
        }
        //Kiểm tra số nguyên tố
        static bool isPrime(int x)
        {
            if ( x <2 ) return false;
            for (int i =2; i <= (int)Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        //(c) Xuất các phần tử là số nguyên tố
        static void OutPrimeItems(int[,] arr)
        {
            Console.WriteLine("(c) Cac so nguyen to trong mang: ");
            int temp = 0;
            for (int i =0; i < arr.GetLength(0); i++)
            {
                for(int j=0 ; j < arr.GetLength(1); j++)
                {
                    if(isPrime(arr[i,j]))
                    {
                        Console.Write(arr[i,j]+" ");
                        temp++;
                    }                       
                }    
            }
            if (temp == 0) Console.WriteLine("trong!");
        }
        //Tìm Tổng số nguyên tố lớn nhất có trong 1 dòng
        static int MaxCountPrimeinRow(int[,] arr)
        {
            int MaxCount = 0;
            for (int i=0; i < arr.GetLength(0);i++) 
                {
                    int count = 0;
                    for(int j=0; j < arr.GetLength(1);j++)
                    {
                        if (isPrime(arr[i, j])) count++;
                    }  
                    if (count>MaxCount) MaxCount = count;
                }
                return MaxCount;
        }

        //(d) Tìm dòng có nhiều số nguyên tố nhất
        static void MaxPrimeRow(int[,] arr)
        {
            int MaxCount = MaxCountPrimeinRow(arr);
            Console.WriteLine("\n(d) Dong co nhieu so nguyen to nhat:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
               int count = 0;
               for (int j = 0; j < arr.GetLength(1); j++)
                {
                   if (isPrime(arr[i, j])) count++;
                }
                   if (count == MaxCount)
                {
                    Console.WriteLine($"Dong {i} - {MaxCount} so nguyen to");
                }
                 
                }
                

        }


    }

}
