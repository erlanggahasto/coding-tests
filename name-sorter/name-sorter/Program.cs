using common_tools;
using core_business;
using core_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    class Program
    {
        const string FILE_PATH_TARGET_DEFAULT = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            var sorter = new sorter_bylastname1st();
            sorter.TheResultIsAboutToBeSaved += c_TheResultIsAboutToBeSaved;

            string message = "";

            if(args.Length > 0)
            {
                string filePath = args[0];

                message = sorter.sort(filePath, FILE_PATH_TARGET_DEFAULT);
            }
            else
            {
                message = "ERROR : please provide the source file name";
            }

            Console.WriteLine(message);
            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        static void c_TheResultIsAboutToBeSaved(object sender, TheResultIsAboutToBeSavedEventArgs e)
        {
            foreach (var name in e.SortedList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
