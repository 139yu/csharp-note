using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.SystemModule.Enum
{
    public enum MouseLocationEnum
    {
        None,
        //在目标对象前
        TargetBefore,
        //在目标对象后
        TargetAfter,
        //在目标对象Children
        TargetChildren,

    }
}
