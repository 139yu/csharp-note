using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataBindStudy.Base;

namespace DataBindStudy.Models
{
    public class EmployeeModel:  NotifyPropertyChangedBase,INotifyDataErrorInfo
    {
        private string _empName;

        public string EmpName
        {
            get { return _empName; }
            set
            {
                _empName = value;
                OnPropertyChanged("EmpName");
                ClearErrors("EmpName");
                ValidateEmpName();
            }
        }
        
        // 保存每个字段的错误信息   
        private readonly Dictionary<string, ObservableCollection<string>> _errors = new Dictionary<string, ObservableCollection<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return Enumerable.Empty<string>();
        }

        public bool HasErrors => _errors.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors[propertyName].Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        private void AddError(string propertyName, ObservableCollection<string> error)
        {
            _errors[propertyName] = error;
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private void ValidateEmpName()
        {
            ObservableCollection<string> errors = new ObservableCollection<string>();
            if (string.IsNullOrEmpty(_empName))
            {
                errors.Add("Name cannot be empty");
                return;
            }

            if (EmpName.Length < 3)
            {
                errors.Add( "Name length must be at least 3 characters");
            }

            if (EmpName.StartsWith("_"))
            {
                errors.Add($"Name cannot start with '_'");
            }
            AddError(nameof(EmpName), errors);
            //其他逻辑校验
        }
    }
}