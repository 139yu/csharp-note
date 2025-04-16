using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Mvvmlight.Framework.ViewModel
{
    public class SubViewModel : ViewModelBase
    {
        /// <summary>
        /// 释放资源，需要手动调用
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            // 释放资源逻辑
        }
    }
}