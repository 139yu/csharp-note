using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.DigitaPlatform.DeviceAccess.Base
{
    internal enum SiemensAreaTypes
    {
        // I Area
        INPUT = 0x81,
        // Q Area
        OUTPUT = 0x82,
        // M Area
        MERKER = 0x83,
        // DB
        DATABLOCK = 0x84,
    }
}
