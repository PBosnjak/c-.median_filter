using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedijanSlike_UART.helpers
{
    public static class EnumBaudRates
    {
        public static readonly List<string> SupportedBaudRates = new List<string>
        {
            "9600",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"
        };
    }
}
