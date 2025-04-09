using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using DataBindStudy.Attributes;

namespace DataBindStudy.Models
{
    public class UserViewModel : IDataErrorInfo
    {
        private string _username = "root";
        
        [CustomerStringLength(minLength:2,maxLength:20)]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        
        private int _age = 0;
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                _age = value;
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                var propertyInfo = this.GetType().GetProperty(columnName);
                if (propertyInfo != null && propertyInfo.IsDefined(typeof(CustomerStringLength),false))
                {
                    CustomerStringLength stringLength = (CustomerStringLength)propertyInfo.GetCustomAttribute(typeof(CustomerStringLength));
                    var stringLengthMinLength = stringLength.MinLength;
                    var stringLengthMaxLength = stringLength.MaxLength;
                    var value = propertyInfo.GetValue(this, null) as string;
                    if (value != null && !(value.Length > stringLengthMinLength && value.Length < stringLengthMaxLength))
                    {
                        return $"{columnName} length must be between {stringLengthMinLength} and {stringLengthMaxLength}.";
                    }
                }
                return null;
            }
        }
    }
}