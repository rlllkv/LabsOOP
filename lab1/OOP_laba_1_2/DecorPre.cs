using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba_1_2
{
    internal class DecorPre : IDateTimeFormatter
    {
        private IDateTimeFormatter date;
        public DecorPre(IDateTimeFormatter a)
        {
            date = a;
        }
        public string FormatDateTime()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Roz");
            sb.Append(date.FormatDateTime());
            return sb.ToString();
        }
    }
}
