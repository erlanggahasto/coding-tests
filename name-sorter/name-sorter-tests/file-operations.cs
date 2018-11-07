using System;
using System.Collections.Generic;
using System.IO;
using common_tools;
using core_interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace name_sorter_tests
{
    [TestClass]
    public class file_operations
    {
        const string FILE_PATH_SOURCE_EXISTING = "..\\..\\unsorted-names-list.txt";
        const string FILE_PATH_SOURCE_NON_EXISTING = "..\\..\\notexist-names-list.txt";
        const string FILE_PATH_SOURCE_EMPTY = "..\\..\\empty-names-list.txt";
        const string FILE_PATH_SOURCE_INVALID_TEXT_FILE = "..\\..\\jpeg-file.txt";
        const string FILE_PATH_TARGET_EXISTING = "..\\..\\sorted-names-list.txt";
        const string FILE_PATH_TARGET_NON_EXISTING = "..\\..\\notexist-names-list.txt";

        [TestMethod]
        public void readExistingFile()
        {
            var list = filetext.read(FILE_PATH_SOURCE_EXISTING);
            Assert.AreEqual(10, list.Count);
        }

        [TestMethod]
        public void readNonExistingFile()
        {
            if (File.Exists(FILE_PATH_SOURCE_NON_EXISTING)) File.Delete(FILE_PATH_SOURCE_NON_EXISTING);
            var list = filetext.read(FILE_PATH_SOURCE_NON_EXISTING);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void readEmptyFile()
        {
            var list = filetext.read(FILE_PATH_SOURCE_EMPTY);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void writeToExistingPath()
        {
            var list = filetext.read(FILE_PATH_SOURCE_EXISTING);
            bool isSuccess = filetext.write(list, FILE_PATH_TARGET_EXISTING);
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void writeToNonExistingPath()
        {
            if(File.Exists(FILE_PATH_TARGET_NON_EXISTING)) File.Delete(FILE_PATH_TARGET_NON_EXISTING);
            var list = filetext.read(FILE_PATH_SOURCE_EXISTING);
            bool isSuccess = filetext.write(list, FILE_PATH_TARGET_NON_EXISTING);
            Assert.IsTrue(isSuccess);
        }
    }
}
