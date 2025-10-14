using System;

namespace BTH2_Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            int Month, Year;
            NhapThangNam(out Month, out Year);
            while (!IsValidMonthYear(Month, Year))
            {
                Console.WriteLine("Thang/Nam khong hop le, nhap lai!");
                NhapThangNam(out Month,out Year);
            }    
            XuatLich(GetDayofMonth(Month,Year),GetFirstDayofWeek(Month,Year),Month,Year);
        }
        //Đọc số nguyên
        static int ReadPositiveInt(string note)
        {
            int n;
            do
            {
                Console.Write(note);
            } while (!int.TryParse(Console.ReadLine(), out n));
            return n;
                
        }
        //Nhập Tháng Năm
        static void NhapThangNam( out int Month, out int Year)
        {
            Console.WriteLine("Moi ban nhap thang nam");
            Month = ReadPositiveInt("Nhap Thang: ");
            Year = ReadPositiveInt("Nhap Nam: ");
        }

        //Kiểm tra Tháng Năm hợp lệ
        static bool IsValidMonthYear(int Month, int Year)
        {
            if (Month <= 0 || Month > 12) return false;
            if (Year == 0 || Year <0) return false;
            return true;
        }

        //Trả về số ngày của tháng
        static int GetDayofMonth(int Month,int Year)
        {
           return DateTime.DaysInMonth(Year, Month);
        }

        //Trả về Thứ đầu tiên của ngày trong tháng
        static int GetFirstDayofWeek (int Month,int Year)
        {
            DateTime dt = new DateTime(Year, Month, 1);
            return (int)dt.DayOfWeek;
        }

        //In lịch ra màn hình
        static void XuatLich(int Days, int DayofWeek, int Month, int Year)
        {
            Console.WriteLine($"\nMonth: {Month:D2}/{Year}");
            Console.WriteLine("{0,5}{1,6}{2,6}{3,6}{4,6}{5,6}{6,6}", "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat");

            for (int i = 0; i < DayofWeek; i++)
            {
                Console.Write("{0,6}", "");
            }

            int pos = 1;
            for (int j = DayofWeek; pos <= Days; j++)
            {
                if (j == 7)
                {
                    j = 0;
                    Console.WriteLine();
                }
                Console.Write($"{pos++,5} ");
            }
            Console.WriteLine();
        }
    }
}