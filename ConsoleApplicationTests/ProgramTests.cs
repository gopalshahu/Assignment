using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetSourcePathTest()
        {
            // Arrange

            // Act
            var sourceFilePath = Program.GetSourcePath();
            const string filePath = @"C:\Project\Assignment\Assignment\Docs";

            // Assert
            Assert.IsTrue(sourceFilePath.Equals(filePath));
        }

        [TestMethod()]
        public void IsFilePathValidTest()
        {
            // Arrange

            // Act
            var filepath = Program.GetSourcePath();
            var isValid = Program.IsFilePathValid(filepath);

            // Assert
            Assert.AreEqual(isValid, true);
        }

        [TestMethod()]
        public void GetFileDataTest()
        {
            // Arrange

            // Act
            var strPath = Program.GetSourcePath();
            var lstData = Program.GetFileData(strPath);
            var listArr = new List<List<string>>()
            {
                new List<string> { "LAST1","FIRST1","MALE","GREEN","01/11/1986" },
                new List<string> { "LAST13","FIRST13","FEMALE","RED","01/01/1984" },
                new List<string> { "LAST22","FIRST22","FEMALE","BALCK","02/24/1980" }
            };
            var result = CompareList(lstData, listArr);

            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void SortByGenderLastNameTest()
        {
            // Arrange

            // Act
            var strPath = Program.GetSourcePath();
            var lstData = Program.GetFileData(strPath);
            var lstSortedData = Program.SortByGenderLastName(lstData);
            var listSortedArr = new List<List<string>>()
            {
                new List<string> { "LAST13","FIRST13","FEMALE","RED","01/01/1984" },
                new List<string> { "LAST22","FIRST22","FEMALE","BALCK","02/24/1980" },
                new List<string> { "LAST1","FIRST1","MALE","GREEN","01/11/1986" }
            };
            var result = CompareList(lstSortedData, listSortedArr);

            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void SortByBirthDateTest()
        {
            // Arrange

            // Act
            var strPath = Program.GetSourcePath();
            var lstData = Program.GetFileData(strPath);
            var lstSortedData = Program.SortByBirthDate(lstData);
            var listSortedArr = new List<List<string>>()
            {
                new List<string> { "LAST22","FIRST22","FEMALE","BALCK","02/24/1980" },
                new List<string> { "LAST13","FIRST13","FEMALE","RED","01/01/1984" },
                new List<string> { "LAST1","FIRST1","MALE","GREEN","01/11/1986" }
            };
            var result = CompareList(lstSortedData, listSortedArr);

            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod()]
        public void SortByLastNameTest()
        {
            // Arrange

            // Act
            var strPath = Program.GetSourcePath();
            var lstData = Program.GetFileData(strPath);
            var lstSortedData = Program.SortByLastName(lstData);
            var listSortedArr = new List<List<string>>()
            {
                new List<string> { "LAST22","FIRST22","FEMALE","BALCK","02/24/1980" },
                new List<string> { "LAST13","FIRST13","FEMALE","RED","01/01/1984" },
                new List<string> { "LAST1","FIRST1","MALE","GREEN","01/11/1986" }
            };
            var result = CompareList(lstSortedData, listSortedArr);

            // Assert
            Assert.AreEqual(result, true);
        }

        private static bool CompareList(List<List<string>> sList, List<List<string>> dList)
        {
            if (sList == null || dList == null)
                return false;
            if (sList.Count == 0 || dList.Count == 0)
                return false;

            for (var i = 0; i < sList.Count; i++)
            {
                //var flag = sList[i].SequenceEqual(dList[i]);
                var firstLst = sList[i].Except(dList[i]).ToList();
                var secondLst = dList[i].Except(sList[i]).ToList();
                var flag = !firstLst.Any() && !secondLst.Any();
                if (!flag)
                    return false;
            }
            return true;

        }
    }
}