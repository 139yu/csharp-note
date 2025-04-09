using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BindingValidationDemo
{
    public class FormData : IDataErrorInfo
    {
        private string _appName = "unknown";

        private string _appCategory = "unknown";

        [Required]
        public string AppName
        {
            get { return _appName; }
            set { _appName = value; }
        }

        [Required]
        public string AppCategory
        {
            get { return _appCategory; }
            set { _appCategory = value; }
        }

        public string this[string columnName]
        {
            get
            {
                if (string.IsNullOrEmpty(columnName))
                {
                    return String.Empty;
                }

                Type type = this.GetType();
                PropertyInfo? prop = type.GetProperty(columnName);
                if (prop != null && prop.IsDefined(typeof(RequiredAttribute)))
                {
                    string propValue = (string)prop.GetValue(this);
                    if (string.IsNullOrEmpty(propValue))
                    {
                        return $"请填写{prop.Name}";
                    }
                }

                return string.Empty;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}