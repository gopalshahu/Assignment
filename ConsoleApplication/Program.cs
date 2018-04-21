using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string strPath = Path.GetFullPath(args[0]);

            Console.WriteLine("Enter files path:");
            string strPath = GetSourcePath();
            Console.WriteLine(strPath);

            if (IsFilePathValid(strPath))
            {
                ListAllFiles(strPath);
            }
            else
            {
                Console.WriteLine("Path doesn't exist.");
                return;
            }
            var lstData = GetFileData(strPath);
            Console.WriteLine("\n Sorted by gender and last name ascending:");
            lstData = SortByGenderLastName(lstData);
            DisplayData(lstData);
            Console.WriteLine("\n Sorted by birth date ascending:");
            lstData = SortByBirthDate(lstData);
            DisplayData(lstData);
            Console.WriteLine("\n Sorted by last name descending:");
            lstData = SortByLastName(lstData);
            DisplayData(lstData);

            //ProcessFileDataList(strPath);
            Console.ReadLine();
        }

        public static string GetSourcePath()
        {
            return @"C:\Project\Assignment\Assignment\Docs";
            //return Console.ReadLine();
        }

        public static bool IsFilePathValid(string sPath)
        {
            return Directory.Exists(sPath);
        }

        public static void ListAllFiles(string sPath)
        {
            var files = Directory.GetFiles(sPath);
            Console.WriteLine("\nFiles list at given path:");
            foreach (var filename in files)
            {
                Console.WriteLine(filename);
            }
        }

        public static List<List<string>> GetFileData(string strPath)
        {
            var mainList = new List<List<string>>();
            string path = Path.GetFullPath(strPath);
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                foreach (var filename in files)
                {
                    //create list of arrays 
                    var file = new StreamReader(filename);
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        var splitChar = record.Contains('|') ? '|' : ((record.Contains(',')) ? ',' : ' ');

                        var innerList = record.Split(splitChar).ToList();
                        mainList.Add(innerList);
                    }
                    file.Close();
                }
            }
            return mainList;
        }

        public static List<List<string>> SortByGenderLastName(List<List<string>> list)
        {
            var sortedGenderList = list.OrderBy(x => x[2]).ThenBy(x => x[0]).ToList();
            return sortedGenderList;
        }

        public static List<List<string>> SortByBirthDate(List<List<string>> list)
        {
            var sortedDobList = list.OrderBy(x => Convert.ToDateTime(x[4])).ToList();
            return sortedDobList;
        }

        public static List<List<string>> SortByLastName(List<List<string>> list)
        {
            var sortedLastNameList = list.OrderByDescending(x => x[0]).ToList();
            return sortedLastNameList;
        }

        public static void DisplayData(List<List<string>> list)
        {
            foreach (var lst in list)
            {
                for (int col = 0; col < lst.Count; col++)
                {
                    Console.Write((col == 4) ? Convert.ToDateTime(lst[col]).ToString("M/d/yyyy") : lst[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        //private static void ProcessFileDataList(string strPath)
        //{
        //    string line;
        //    char splitChar;
        //    String[] strArr = new String[5];
        //    List<string[]> list = new List<string[]>();
        //    string path = Path.GetFullPath(strPath);
        //    if (Directory.Exists(path))
        //    {
        //        Console.WriteLine("\nFiles list at given path:");
        //        var files = Directory.GetFiles(path);
        //        foreach (var filename in files)
        //        {
        //            //create list/array 
        //            Console.WriteLine(filename.ToString());

        //            StreamReader file = new StreamReader(filename);
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                splitChar = line.Contains('|') ? '|' : ((line.Contains(',')) ? ',' : ' ');

        //                strArr = line.Split(splitChar);
        //                list.Add(strArr);
        //            }
        //            file.Close();
        //        }

        //        Console.WriteLine("\n Sorted by gender and last name ascending:");
        //        List<string[]> sortedGenderList = list.OrderBy(x => x[2]).ThenBy(x => x[0]).ToList();
        //        foreach (var lst in sortedGenderList)
        //        {
        //            for (int col = 0; col < lst.Length; col++)
        //            {
        //                Console.Write((col==4) ? Convert.ToDateTime(lst[col]).ToString("M/d/yyyy") : lst[col] + "\t");
        //            }
        //            Console.WriteLine();
        //        }

        //        Console.WriteLine("\n Sorted by birth date ascending:");
        //        List<string[]> sortedDobList = list.OrderBy(x => Convert.ToDateTime(x[4])).ToList();
        //        foreach (var lst in sortedDobList)
        //        {
        //            for (int col = 0; col < lst.Length; col++)
        //            {
        //                Console.Write((col == 4) ? Convert.ToDateTime(lst[col]).ToString("M/d/yyyy") : lst[col] + "\t");
        //            }
        //            Console.WriteLine();
        //        }

        //        Console.WriteLine("\n Sorted by last name descending:");
        //        List<string[]> sortedLastNameList = list.OrderBy(x => x[0]).ToList();
        //        foreach (var lst in sortedLastNameList)
        //        {
        //            for (int col = 0; col < lst.Length; col++)
        //            {
        //                Console.Write((col == 4) ? Convert.ToDateTime(lst[col]).ToString("M/d/yyyy") : lst[col] + "\t");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Path doesn't exist.");
        //    }
        //}

        //private static void ProcessFileDataArray(string strPath)
        //{
        //    string line, formattedLine;
        //    char splitChar;
        //    int i = 0;
        //    String[][] strArr = new String[9][];
        //    List<String> list = new List<String>();
        //    string path = Path.GetFullPath(strPath);
        //    if (Directory.Exists(path))
        //    {
        //        Console.WriteLine("\nFiles list at given path:");
        //        var files = Directory.GetFiles(path);
        //        foreach (var filename in files)
        //        {
        //            Console.WriteLine(filename.ToString());

        //            StreamReader file = new StreamReader(filename);
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                splitChar = line.Contains('|') ? '|' : ((line.Contains(',')) ? ',' : ' ');

        //                strArr[i++] = line.Split(splitChar);

        //            }
        //            file.Close();

        //        }

        //        Console.WriteLine("\n Sorted by gender and last name ascending:");
        //        String[][] sortedGender = strArr.OrderBy(x => x[2]).ThenBy(x => x[0]).ToArray();
        //        for (int row = 0; row < sortedGender.Length; row++)
        //        {
        //            formattedLine = "";
        //            for (int col = 0; col < sortedGender[row].Length; col++)
        //            {
        //                formattedLine += sortedGender[row][col] + "\t";
        //            }
        //            Console.WriteLine(formattedLine);
        //        }

        //        Console.WriteLine("\n Sorted by birth date ascending:");
        //        String[][] sortedDob = strArr.OrderBy(x => Convert.ToDateTime(x[4])).ToArray();
        //        for (int row = 0; row < sortedDob.Length; row++)
        //        {
        //            for (int col = 0; col < sortedDob[row].Length; col++)
        //            {
        //                Console.Write(sortedDob[row][col] + "\t");
        //            }
        //            Console.WriteLine();
        //        }

        //        Console.WriteLine("\n Sorted by last name descending:");
        //        String[][] sortedLastName = strArr.OrderByDescending(x => x[0]).ToArray();
        //        for (int row = 0; row < sortedLastName.Length; row++)
        //        {
        //            for (int col = 0; col < sortedLastName[row].Length; col++)
        //            {
        //                Console.Write(sortedLastName[row][col] + "\t");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Path doesn't exist.");
        //    }
        //}
    }
}
