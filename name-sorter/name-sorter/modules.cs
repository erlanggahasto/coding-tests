using common_tools;
using core_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public static class modules
    {
        public static string sort(isorter sorter, string sourceFilePath, string targetFilePath)
        {
            string message = "";

            var list = filetext.read(sourceFilePath);
            var sortedList = sorter.sort(list);
            if (filetext.write(sortedList, targetFilePath))
            {
                message = "SUCCESS : the result has been saved in file " + targetFilePath;
            }
            else
            {
                message = "ERROR : failed to proceed";
            }

            return message;
        }
    }
}
