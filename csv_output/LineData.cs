using System;
using System.Web;

namespace csv_output
{
    public abstract class LineData
    {
        public LineData() { }

        public abstract void SetDataFrom(string[] s);
    }
}
