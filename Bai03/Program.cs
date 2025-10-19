using System;

namespace BTH02_Bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n, k;
            //(a)
            int[,] arr = InputArr(out m, out n);
            Console.Write("Nhap phan tu muon tim: ");
            k = int.Parse(Console.ReadLine());
            //(a)
            OutArr(arr, m, n);
            //(b)
            FindItem(arr, k);
            //(c)
            OutPrimeItems(arr);
            //(d)
            MaxPrimeRow(arr);
        }


        //(a) Nhập ma trận 2 chiều các số nguyên
        static int[,] InputArr(out int m, out int n)
        {
            Console.WriteLine("(a) Nhap ma tran");
            Console.Write("Nhap so hang: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            n = int.Parse(Console.ReadLine());
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                Console.Write($"Nhap dong {i + 1}: ");
                string[] parts = Console.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                while (parts.Length != n)
                    while (parts.Length != n )
                {
                    Console.WriteLine($"Phai nhap dung {n} so!");
                    Console.Write($"Nhap lai dong {i + 1}: ");
                    parts = Console.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
                for (int j = 0; j < n; j++)
                {
                    int value;
                    while (!int.TryParse(parts[j], out value))
                    {
                        Console.Write($"Gia tri '{parts[j]}' khong hop le, nhap lai phan tu [{i},{j}]: ");
                        parts[j] = Console.ReadLine();
                    }
                    arr[i,j]= int.Parse(parts[j]);
                }
            }
            return arr;
        }

        //(a) Xuất ma trận
        static void OutArr(int[,] arr, int m, int n)
        {
            Console.WriteLine($"\n(a) Ma tran {m}x{n}");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //(b)Tìm kiếm 1 phần tử trong ma trận
        static void FindItem(int[,] arr, int item)
        {
            int temp = 0;
            Console.WriteLine($"\n(b) Phan tu {item} nam o vi tri: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == item)
                    {
                        Console.WriteLine($"({i},{j})");
                        temp++;
                    }
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("Khong tim thay!");
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
            Console.WriteLine("\n(c) Cac phan tu la so nguyen to trong mang: ");
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
            if (temp == 0) Console.WriteLine("Khong co phan tu nao la so nguyen to!");
            else Console.WriteLine();
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
            if (MaxCount == 0)
            {
                Console.WriteLine("(d) Khong co hang nao co so nguyen to");
            }
            else
            {
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
                        Console.WriteLine($"Dong {i} co nhieu so nguyen to nhat - {MaxCount} so");
                    }
                }
            }
        }
    }
}
