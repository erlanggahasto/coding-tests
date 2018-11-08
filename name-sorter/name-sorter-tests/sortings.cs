using System;
using System.Collections.Generic;
using System.IO;
using common_tools;
using core_business;
using core_interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;

namespace name_sorter_tests
{
    [TestClass]
    public class sortings
    {
        const string FILE_PATH_SOURCE_EXISTING = "..\\..\\unsorted-names-list.txt";
        const string FILE_PATH_SOURCE_WITH_SAME_NAMES_OR_LAST_NAMES = "..\\..\\unsorted-names-list-2.txt";
        const string FILE_PATH_TARGET_MASTER = "..\\..\\master-sorted-names-list.txt";
        const string FILE_PATH_TARGET_MASTER_WITH_SAME_NAMES_OR_LAST_NAMES = "..\\..\\master-sorted-names-list-2.txt";
        const string FILE_PATH_TARGET_EXISTING = "..\\..\\sorted-names-list.txt";

        [TestMethod]
        public void sortIntoList()
        {
            isorter sorter = new sorter_bylastname1st();

            var list = filetext.read(FILE_PATH_SOURCE_EXISTING);
            var actualList = sorter.sort(list);
            var expectedList = filetext.read(FILE_PATH_TARGET_MASTER);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void sortIntoList_WithSameNamesOrLastNames()
        {
            isorter sorter = new sorter_bylastname1st();

            var list = filetext.read(FILE_PATH_SOURCE_WITH_SAME_NAMES_OR_LAST_NAMES);
            var actualList = sorter.sort(list);
            var expectedList = filetext.read(FILE_PATH_TARGET_MASTER_WITH_SAME_NAMES_OR_LAST_NAMES);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void sortIntoFile()
        {
            var sorter = new sorter_bylastname1st();
            if (File.Exists(FILE_PATH_TARGET_EXISTING)) File.Delete(FILE_PATH_TARGET_EXISTING);
            string message = modules.sortIntoFile(sorter, FILE_PATH_SOURCE_EXISTING, FILE_PATH_TARGET_EXISTING);
            Assert.AreEqual("SUCCESS", message.Split(' ')[0]);
        }
    }
}
