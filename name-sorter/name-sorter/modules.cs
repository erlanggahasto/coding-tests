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
        public static string sortIntoFile(isorter sorter, string sourceFilePath, string targetFilePath)
        {
            string message = "";

            var unsortedList = filetext.read(sourceFilePath);
            if (unsortedList.Count > 0)
            {
                //Sort if there's something to sort
                var sortedList = sorter.sort(unsortedList);
                foreach (var name in sortedList)
                {
                    Console.WriteLine(name);
                }
                if (filetext.write(sortedList, targetFilePath))
                {
                    message = "SUCCESS : the result has been saved in a file : " + targetFilePath;
                }
                else
                {
                    message = "ERROR : cannot save the result to the file : " + targetFilePath;
                }
            }
            else
            {
                message = "ERROR : nothing to sort here";
            }

            return message;
        }
    }
}
