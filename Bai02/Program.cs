using System;
using System.Globalization;
using System.IO;
using System.Runtime;

namespace BTH2_Bai02
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = RightPathInput();     
            DisplayDirectory(path);
        }

        //Nhập địa chỉ
        static string RightPathInput()
        {
            Console.Write("Nhap dia chi thu muc: ");
            string path = Console.ReadLine() ;
            while (!Directory.Exists(path))
            {
                Console.Write("Thu muc khong ton tai! \nNhap lai dia chi thu muc: ");
                path = Console.ReadLine() ;
            }
            return path;
        }
        //Xuất thư mục và file như lệnh dir
        static void DisplayDirectory (string path)
        {
            Console.WriteLine("\nDirectory of " + path);
            string[] items = Directory.GetFileSystemEntries(path);
            foreach (string item in items)
            {
               
                if (Directory.Exists(item))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(item);
                    if ((directoryInfo.Attributes & FileAttributes.System) == FileAttributes.System
                     || (directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        continue;
                    Console.WriteLine("{0,19}  {1,-5}{2,15}  {3}", directoryInfo.LastAccessTime.ToString("dd/MM/yyyy hh:mm tt"), "<DIR>", "", directoryInfo.Name);             
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(item);
                    if ((fileInfo.Attributes & FileAttributes.System) == FileAttributes.System
                    || (fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        continue;
                    Console.WriteLine("{0,19}  {1,-5}{2,15:N0}  {3}", fileInfo.LastAccessTime.ToString("dd/MM/yyyy hh:mm tt"), "", fileInfo.Length, fileInfo.Name);              
                }
            }
            DriveInfo drive = new DriveInfo(Path.GetPathRoot(path));
            long freeBytes = drive.AvailableFreeSpace;
            Console.WriteLine("{0,15}{1,-15}{2,-15:N0} {3}"," ",$"{CountFiles(path)} Files(s)",SumByteinFies(path), "bytes");
            Console.WriteLine("{0,15}{1,-15}{2,-15:N0} {3}"," ", $"{CountFolders(path)} Dir(s)",freeBytes, "bytes free");
        }

        //Đếm tổng số bytes của file
        static long SumByteinFies(string Path)
        {
            long total = 0;
            string[] Files = Directory.GetFiles(Path);
            foreach(string File in Files)
            {
                FileInfo fileInfo = new FileInfo(File);
                if ((fileInfo.Attributes & FileAttributes.System) == FileAttributes.System
                 || (fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                total += fileInfo.Length;
            }    
            return total;
        }

      

        //Đếm số File 
        static int CountFiles(string Path)
        {
            int total = 0;
            string[] Files = Directory.GetFiles(Path);
            foreach (string File in Files)
            {
                FileInfo FileInfo = new FileInfo(File);
                if ((FileInfo.Attributes & FileAttributes.System) == FileAttributes.System
                 || (FileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                total++;
            }
            return total;
        }

        //Đếm số Thư mục con không  phải thư mục hệ thống
        static int CountFolders(string Path)
        {
            int total = 0;
            string[] Folders = Directory.GetDirectories(Path);
            foreach (string Folder in Folders) 
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(Folder);
                    if ((directoryInfo.Attributes & FileAttributes.System) == FileAttributes.System
                     || (directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                total++;
                }
                return total;
        }
    }
}
