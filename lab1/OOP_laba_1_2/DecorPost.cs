using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba_1_2
{
    internal class DecorPost : IDateTimeFormatter
    {
        private IDateTimeFormatter date;
        public DecorPost(IDateTimeFormatter a)
        {
            date = a;
        }
        public string FormatDateTime()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(date.FormatDateTime());
            sb.Append("Max");
            return sb.ToString();
        }
    }
}
