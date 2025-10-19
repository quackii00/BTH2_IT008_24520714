using System;
namespace BTH2_Bai04
{
    class Program
    {
        static void Main(string[] args)
        {
            // input (a)
            PhanSo a = new PhanSo();
            PhanSo b = new PhanSo();
            Console.WriteLine("Nhap phan so a ");
            a.Nhap();
            Console.WriteLine("Nhap phan so b ");
            b.Nhap();

            //input (b)
            MangPhanSo arr = new MangPhanSo();
            arr.NhapMang();

            //output (a)
            Console.WriteLine("(a)Ket qua tinh toan +, -, *, / giua 2 phan so");
            Console.WriteLine($"a = {a.GetTuSo()}/{a.GetMauSo()}, b = {b.GetTuSo()}/{b.GetMauSo()}");
            Console.Write("a + b = ");
            (a + b).Xuat();
            Console.Write("\na - b = ");
            (a-b).Xuat();
            Console.Write("\na * b = ");
            (a*b).Xuat();
            Console.Write("\na / b = ");
            try
            {
                (a / b).Xuat();
            }
            catch (DivideByZeroException ex)
            {
                Console.Write(ex.Message);
            }

            //output (b)
            Console.WriteLine("\n(b) Mang ban dau");
            arr.XuatMang();
            PhanSo MaxPhanSo =arr.TimPhanSoLonNhat();
            Console.Write("\nPhan so lon nhat trong mang: ");
            MaxPhanSo.Xuat();
            arr.SapXepTangDan();
            Console.WriteLine("\nMang sau khi sap xep tang dan");
            arr.XuatMang();
        }
    }

    class PhanSo
    {
        private int tuSo;
        private int mauSo;
        public PhanSo(int tuSo = 0, int mauSo = 1)
        {
            this.tuSo = tuSo;
            this.mauSo = mauSo;
            RutGon();
        }
        public int GetTuSo()
        {
            return this.tuSo;
        }
        public int GetMauSo()
        {
            return this.mauSo;
        }
        private int UCLN(int a, int b)
        {
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }
        }
        public void RutGon()
        {
            int value = UCLN(this.mauSo, this.tuSo);
            this.tuSo /= value;
            this.mauSo /= value;
            if (this.mauSo <0)
            {
                this.tuSo = -this.tuSo;
                this.mauSo = -this.mauSo;
            }    
        }
        public void Nhap()
        {
            while (true)
            {
                Console.Write("Nhap phan so co dang (a/b): ");
                string input = Console.ReadLine();
                if (input.Length == 0)
                {
                    Console.WriteLine("Khong duoc de trong. Moi nhap lai");
                    continue;

                }
                int tu;
                int mau;
                string[] parts = input.Split('/');
                if (parts.Length == 1)
                {
                    if (!int.TryParse(parts[0], out tu))
                    {

                        Console.WriteLine("Nhap khong hop le. Nhap lai!");
                        continue;
                    }
                    mau = 1;

                }
                else if (parts.Length == 2)
                {
                    bool checkTu = int.TryParse(parts[0], out tu);
                    bool checkMau = int.TryParse(parts[1], out mau);
                    if (!checkTu|| !checkMau)
                    {
                        Console.WriteLine("Nhap khong hop le. Nhap lai!");
                        continue ;
                    }    
                    if (mau ==0)
                    {
                        Console.WriteLine("Mau khong duoc bang 0. Nhap lai!");
                        continue ;
                    }    
                }
                else
                {
                    Console.WriteLine("Nhap sai dinh dang. Nhap lai!");
                    continue;
                }
                this.tuSo=tu; 
                this.mauSo=mau;
                RutGon();
                break;
            }
        }
        public void Xuat()
        {
            if (this.tuSo == 0)
            {
                Console.Write(0);
            }
            else if (this.mauSo == 1)
            {
                Console.Write(tuSo);
            }  
            else
            Console.Write($"{tuSo}/{mauSo}");
        }
        public double ToDouble()
        {
            return (double) this.tuSo / this.mauSo;
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo + a.mauSo * b.tuSo, a.mauSo * b.mauSo);
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo - a.mauSo * b.tuSo, a.mauSo * b.mauSo);
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.tuSo, a.mauSo * b.mauSo);
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.GetTuSo() ==0)
            {
                throw new DivideByZeroException("Khong the chia cho phan so co tu so = 0");
            }    
            return new PhanSo(a.tuSo * b.mauSo, a.mauSo * b.tuSo);
        }

    }
    class MangPhanSo
    {
        private PhanSo[] arrPhanSo;
        private int n;
        public MangPhanSo(int n=0)
        {
            arrPhanSo = new PhanSo[n];
            this.n = n;
        }
        public void NhapMang()
        {
            Console.Write("Nhap so phan tu cua mang: ");
            string part = Console.ReadLine();
            int temp;
            while (!int.TryParse(part, out temp) || temp <= 0)
            {
                Console.Write("Khong dung, moi nhap lai n = ");
                part = Console.ReadLine();
            }
            this.n = temp;
            arrPhanSo = new PhanSo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan so thu " + (i + 1));
                arrPhanSo[i] = new PhanSo();
                arrPhanSo[i].Nhap();
            }
        }
        public void XuatMang()
        {
            for (int i = 0; i < n; i++)
            {
                arrPhanSo[i].Xuat();
                Console.Write(" ");
            }
        }
        public PhanSo TimPhanSoLonNhat()
        {
            int tu = arrPhanSo[0].GetTuSo();
            int mau = arrPhanSo[0].GetMauSo();
            double MaxValue = arrPhanSo[0].ToDouble();
            for (int i = 1; i < n; i++)
            {
                double temp = arrPhanSo[i].ToDouble();
                if (MaxValue < temp)
                {
                    MaxValue = temp;
                    tu = arrPhanSo[i].GetTuSo();
                    mau = arrPhanSo[i].GetMauSo();
                }
            }
            return new PhanSo(tu, mau);
        }
        public void SapXepTangDan()
        {
            Array.Sort(arrPhanSo,0,n, Comparer<PhanSo>.Create((a, b) => a.ToDouble().CompareTo(b.ToDouble())));
        }
    }
}
