using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobody.MTHModels
{
    public class Device
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }

        public List<Group> GroupList { get; set; }

        public bool IsConnected { get; set; }
        /// <summary>
        /// 重连间隔时间
        /// </summary>
        public int ReConnectTime { get; set; } = 500;

        public RecipeInfo CurrentRecipe { get; set; }
        /// <summary>
        /// 是否重连标识
        /// </summary>
        public bool ReConnectSinge { get; set; } = false;
        public Dictionary<string,object> CurrentValue = new Dictionary<string,object>();
        public event Action<bool,Variable> AlarmTriggerEvent;
        public object this[string key]
        {
            get
            {
                if (CurrentValue.ContainsKey(key))
                {
                    return CurrentValue[key];
                }
                return null;
            }
        }
        public void UpdateVariable(Variable item)
        {
            if (CurrentValue.ContainsKey(item.VarName))
            {
                CurrentValue[item.VarName] = item.VarValue;
            }else
            {
                CurrentValue.Add(item.VarName, item.VarValue);
            }
            CheckAlarm(item);
        }

        public void CheckAlarm(Variable item)
        {
            if (item.PosAlarm)
            {
                bool currentValue = item.VarValue.ToString() == "True";
                if(currentValue == true && item.PosAlarmCache == false)
                {
                    // 警报触发
                    AlarmTriggerEvent?.Invoke(true, item);
                }
                if(currentValue == false && item.PosAlarmCache == true)
                {
                    // 警报消除
                    AlarmTriggerEvent?.Invoke(false, item);
                }
                item.PosAlarmCache = currentValue;
            }

            if (item.NegAlarm)
            {
                bool currentValue = item.VarValue.ToString() == "True";
                if (currentValue == true && item.NegAlarmCache == false)
                {
                    AlarmTriggerEvent?.Invoke(true, item);
                }
                if (currentValue == false && item.NegAlarmCache == true)
                {
                    AlarmTriggerEvent?.Invoke(false, item);
                }
                item.NegAlarmCache = currentValue;
            }
        }

    }
}
