using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFC5Test.Models
{
    public class ViewTestMode: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _value = 10;
        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(""));
            }
        }
        
        private string _textValue = "Hello World";

        public string TextValue
        {
            get{return _textValue;}
            set
            {
                if (value.Length > 10)
                {
                    throw new ArgumentException("The text value must be less than 10 characters.");
                }
                _textValue = value;
            }
        }
    }
}