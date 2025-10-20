using System;
namespace BTH2_Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            string DiaDiem;
            double GiaBan;
            double DienTich;
            QuanLi ListBDS = new QuanLi();
            //(a)Nhập danh sách bất động sản
            ListBDS.NhapDS();
            //(d)Nhập thông tin khu đất muốn tìm
            Console.WriteLine("\nNhap thong tin khu dat muon tim");
            Console.Write("Nhap Dia Diem: ");
            DiaDiem = Console.ReadLine();
            Console.Write("Nhap Gia Ban: ");
            GiaBan = IsDouble();
            Console.Write("Nhap Dien Tich: ");
            DienTich = IsDouble();
            Console.WriteLine("\n(a) Danh sach Bat Dong San cua Cong Ty Dai Phat");
            ListBDS.XuatDS();
            Console.WriteLine($"(b) Tong Gia Ban Cua Khu Dat: {ListBDS.TinhTongGiaBan(1)}");
            Console.WriteLine($"(b) Tong Gia Ban Cua NhaPho: {ListBDS.TinhTongGiaBan(2)}");
            Console.WriteLine($"(b) Tong Gia Ban Cua Chung Cu: {ListBDS.TinhTongGiaBan(3)}");
            Console.WriteLine("\n(c) Danh sach khu dat hoac chung cu thoa dieu kien");
            ListBDS.XuatDSThoaDieuKien();
            Console.WriteLine($"\n(d) Danh sach tat ca cac nha pho hoac chung cu hop yeu cau (={DiaDiem},<={GiaBan},>={DienTich})");
            ListBDS.TimKiem(DiaDiem, GiaBan, DienTich);
        }
        public static double IsDouble()
        {
            double temp;
            while (!double.TryParse(Console.ReadLine(), out temp) || temp <= 0)
            {
                Console.Write("Nhap khong dung, hay nhap lai: ");
            }
            return temp;
        }
        public static int IsYear()
        {
            int temp;
            while (!int.TryParse(Console.ReadLine(), out temp) || temp <= 0)
            {
                Console.Write("Nhap khong dung, hay nhap lai: ");
            }
            return temp;
        }
        public static byte IsByte()
        {
            byte temp;
            while (!byte.TryParse(Console.ReadLine(), out temp) || temp < 0)
            {
                Console.Write("Nhap khong dung, hay nhap lai: ");
            }
            return temp;
        }
        public static byte Loai()
        {
            byte temp;
            while (!byte.TryParse(Console.ReadLine(), out temp) || (temp <= 0) || (temp >= 4))
            {
                Console.Write("Nhap khong dung, hay nhap lai (1,2,3): ");
            }
            return temp;
        }
    }

    class QuanLi
    {
        private List<KhuDat> DanhSachBDS = new List<KhuDat>();
        public void NhapDS()
        {
            Console.Write("Nhap so bat dong san trong danh sach: ");
            int n = int.Parse(Console.ReadLine());
            byte Loai;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap loai (1,2,3): ");
                Loai = Program.Loai();
                Console.WriteLine($"Nhap Thong tin Bat Dong San thu {i + 1}");
                switch (Loai)
                {
                    case 1:
                        {
                            Console.WriteLine("Nhap thong tin Khu Dat");
                            DanhSachBDS.Add(new KhuDat());
                            DanhSachBDS[i].Nhap();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Nhap thong tin Nha Pho");
                            DanhSachBDS.Add(new NhaPho());
                            DanhSachBDS[i].Nhap();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Nhap thong tin Chung Cu");
                            DanhSachBDS.Add(new ChungCu());
                            DanhSachBDS[i].Nhap();
                            break;
                        }
                }
            }

        }
        public void XuatDS()
        {
            for (int i = 0; i < DanhSachBDS.Count; i++)
            {
                Console.WriteLine($"Bat Dong San thu {i + 1}");
                DanhSachBDS[i].Xuat();
                Console.WriteLine();
            }
        }
        public double TinhTongGiaBan(byte Loai)
        {
            double sumGiaBan = 0;

            if (Loai == 1)
            {
                foreach (var BDS in DanhSachBDS)
                {
                    if (BDS.GetType() == typeof(KhuDat))
                    {
                        sumGiaBan += BDS.GetGiaBan();
                    }
                }
            }
            else if (Loai == 2)
            {
                foreach (var BDS in DanhSachBDS)
                {
                    if (BDS is NhaPho)
                    {
                        sumGiaBan += BDS.GetGiaBan();
                    }
                }
            }
            else
            {
                foreach (var BDS in DanhSachBDS)
                {
                    if (BDS is ChungCu)
                    {
                        sumGiaBan += BDS.GetGiaBan();
                    }
                }
            }
            return sumGiaBan;
        }
        public void XuatDSThoaDieuKien()
        {
            byte temp = 0;
            foreach (var bds in DanhSachBDS)
            {
                if (bds.GetType() == typeof(KhuDat))
                {
                    if (bds.GetDienTich() > 100)
                    {
                        bds.Xuat();
                        Console.WriteLine();
                        temp++;
                    }
                }
                else if (bds is NhaPho nhapho)
                {
                    if (nhapho.GetDienTich() > 60 && nhapho.GetNamXayDung() >= 2019)
                    {
                        nhapho.Xuat();
                        Console.WriteLine();
                        temp++;
                    }
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("Khong co khu dat va nha pho nao thoa dieu kien");
            }

        }
        public void TimKiem(string diaDiem, double giaBan, double dienTich)
        {
            diaDiem = diaDiem.ToLower();
            byte temp = 0;
            foreach (var bds in DanhSachBDS)
            {
                if (bds is NhaPho || bds is ChungCu)
                {
                    if ((bds.GetDiaDiem().ToLower() == diaDiem)
                            && (bds.GetGiaBan() <= giaBan)
                            && (bds.GetDienTich() >= dienTich))
                    {
                        if (bds is NhaPho nhapho)
                        {
                            nhapho.Xuat();
                            Console.WriteLine();
                        }
                        else if (bds is ChungCu chungCu)
                        {
                            chungCu.Xuat();
                            Console.WriteLine();
                        }
                        temp++;
                    }
                    
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("Khong co nha pho hoac chung cu phu hop yeu cau");
            }
        }

    }
    class KhuDat
    {
        public string DiaDiem;
        public double GiaBan;
        public double DienTich;
        public virtual void Nhap()
        {
            Console.Write("Nhap Dia Diem: ");
            DiaDiem = Console.ReadLine();
            Console.Write("Nhap Gia Ban: ");
            GiaBan = Program.IsDouble();
            Console.Write("Nhap Dien Tich: ");
            DienTich = Program.IsDouble();
        }
        public virtual string LoaiBDS()
        {
            return "Khu Dat";
        }
        public virtual void Xuat()
        {
            Console.WriteLine($"Loai Bat Dong San: {LoaiBDS()}");
            Console.WriteLine($"Dia Diem: {DiaDiem}");
            Console.WriteLine($"Gia Ban: {GiaBan}");
            Console.WriteLine($"Dien Tich: {DienTich}");
        }
        public double GetGiaBan()
        {
            return GiaBan;
        }
        public double GetDienTich()
        {
            return DienTich;
        }
        public string GetDiaDiem()
        {
            return DiaDiem;
        }
    }
    class NhaPho : KhuDat
    {
        private int namXayDung;
        private byte soTang;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap nam xay dung: ");
            namXayDung = Program.IsYear();
            Console.Write("Nhap so tang: ");
            soTang = Program.IsByte();
        }
        public override string LoaiBDS()
        {
            return "Nha Pho";
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Nam Xay Dung: {namXayDung}");
            Console.WriteLine($"So Tang: {soTang}");
        }
        public int GetNamXayDung()
        {
            return namXayDung;
        }

    }
    class ChungCu : KhuDat
    {
        private byte tang;
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap tang: ");
            tang = Program.IsByte();
        }
        public override string LoaiBDS()
        {
            return "Chung Cu";
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Tang: {tang}");
        }
    }
}

