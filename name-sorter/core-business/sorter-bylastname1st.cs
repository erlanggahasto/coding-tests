﻿using common_tools;
using core_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_business
{
    //A sorter which sorts by the last name first
    public class sorter_bylastname1st : sorter_base, isorter
    {
        public override List<string> sort(List<string> list)
        {
            //Use custom sort
            list.Sort(delegate (string x, string y)
            {
                var xLastName = x.Split(' ').Last();
                var yLastName = y.Split(' ').Last();

                //If last names are not the same..
                if (xLastName != yLastName)
                {
                    //..compare by the last names
                    return xLastName.CompareTo(yLastName);
                }
                //If last names are the same..
                else
                {
                    //..compare by the rest ot the names
                    var xRestOfName = x.Replace(xLastName, "");
                    var yRestOfName = y.Replace(yLastName, "");

                    return xRestOfName.CompareTo(yRestOfName);
                }
            });

            return list;
        }

        public override string sort(string sourceFilePath, string targetFilePath)
        {
            string message = "";

            var unsortedList = filetext.read(sourceFilePath);
            if (unsortedList.Count > 0)
            {
                //Sort if there's something to sort
                var sortedList = sort(unsortedList);

                TheResultIsAboutToBeSavedEventArgs args = new TheResultIsAboutToBeSavedEventArgs();
                args.SortedList = sortedList;
                BeforeSavingTheResult(args);

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
