using core_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core_business
{
    public class sorter_base : isorter
    {
        public virtual List<string> sort(List<string> list)
        {
            throw new NotImplementedException();
        }

        public virtual string sort(string sourceFilePath, string targetFilePath)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<TheResultIsAboutToBeSavedEventArgs> TheResultIsAboutToBeSaved;

        protected virtual void BeforeSavingTheResult(TheResultIsAboutToBeSavedEventArgs e)
        {
            EventHandler<TheResultIsAboutToBeSavedEventArgs> handler = TheResultIsAboutToBeSaved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }

    public class TheResultIsAboutToBeSavedEventArgs : EventArgs
    {
        public List<string> SortedList { get; set; }
    }
}
