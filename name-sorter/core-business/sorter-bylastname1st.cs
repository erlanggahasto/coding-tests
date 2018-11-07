using common_tools;
using core_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_business
{
    public class sorter_bylastname1st : isorter
    {
        public List<string> sort(List<string> list)
        {
            list.Sort(delegate (string x, string y)
            {
                var xName = x.Split(' ').Last();
                var yName = y.Split(' ').Last();
                return xName.CompareTo(yName);
            });

            return list;
        }
    }
}
