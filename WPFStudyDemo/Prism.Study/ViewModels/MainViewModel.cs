using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DryIoc;
using ImTools;
using Prism.Commands;
using Prism.Mvvm;

namespace Prism.Study.ViewModels
{
    public class MainViewModel: BindableBase, INotifyDataErrorInfo
    {
        #region INotifyDataErrorInfo
        private ErrorsContainer<string> _errors;

        public ErrorsContainer<string> Errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new ErrorsContainer<string>(RaiseErrorsChanged);
                }
                return _errors;
            }
        }

        private void RaiseErrorsChanged(string args)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(args));
        }
        public IEnumerable GetErrors(string propertyName)
        {
            return Errors.GetErrors(propertyName);
        }

        protected void AddError(string propertyName, string error)
        {
            if (propertyName == null)
            {
                return;
            }

            if (Errors.GetErrors(propertyName) == null)
            {
                Errors.SetErrors(propertyName,new []{error});
            }
        }
        public bool HasErrors { get => Errors.HasErrors; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion
        #region BindableBase与命令
        public MainViewModel()
        {
            AddTextCommand = new DelegateCommand(ExecuteAddTextCommand, CanAddTextCheck);
            // 监听某个属性变化，变化时执行CanExecuteCheck
            AddTextCommand.ObservesProperty(() => TextValue);
            ClearTextCommand = new DelegateCommand(ExecuteClearCommand,CanClearTextCheck);
            // 优先级高于ObservesProperty，需要手动调用更新监听停的值HasText
            ClearTextCommand.ObservesCanExecute(() => HasText);
            ClearTextCommand.ObservesProperty(() => TextValue);
            SelectionCommand = new DelegateCommand<object>(ExecuteSelectionCommand);
            
        }
        private string _textValue;

        public string TextValue
        {
            get { return _textValue; }
            set { SetProperty(ref _textValue, value); }
        }

        public void ExecuteClearCommand()
        {
            TextValue = string.Empty;
            
            HasText = false;
        }
        
        public void ExecuteAddTextCommand()
        {
            TextValue = new Random().Next(9999,10000).ToString();
            HasText = true;
        }

        public bool CanAddTextCheck()
        {
            return string.IsNullOrEmpty(TextValue);
        }

        public bool CanClearTextCheck()
        {
            return !string.IsNullOrEmpty(TextValue);
        }
        public DelegateCommand AddTextCommand { get;}
        public DelegateCommand ClearTextCommand { get;}

        private bool _hasText;

        public bool HasText
        {
            get
            {   
                return !string.IsNullOrEmpty(TextValue);
            }
            set
            {
                SetProperty(ref _hasText, value);
            }
        }
        
        
        public DelegateCommand<object> SelectionCommand { get; }
        /// <summary>
        /// 默认是eventArg
        /// 在xaml中指定接收TriggerParameterPath="Handled"，参数就就直接收eventArg的Handled属性
        /// </summary>
        /// <param name="arg"></param>
        public void ExecuteSelectionCommand(object arg)
        {
            
        }
        #endregion
    }
}