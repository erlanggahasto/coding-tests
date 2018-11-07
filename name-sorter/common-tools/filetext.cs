using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common_tools
{
    public static class filetext
    {
        public static List<string> read(string path)
        {
            var list = new List<string>();

            try
            {
                using (var file = new StreamReader(path))
                {
                    var line = string.Empty;

                    while ((line = file.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }

        public static bool write(List<string> list, string path)
        {
            bool result = false;

            try
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    foreach (string line in list)
                    {
                        file.WriteLine(line);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
