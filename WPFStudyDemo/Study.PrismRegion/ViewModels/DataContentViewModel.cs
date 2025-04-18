using System;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Study.PrismRegion.ViewModels
{
    
    public class DataContentViewModel: BindableBase,IConfirmNavigationRequest
    {

        public DataContentViewModel()
        {
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand);
        }
        
        private void ExecuteGoBackCommand()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }
        private IRegionNavigationJournal _navigationJournal;
        private string _textValue;

        public string TextValue
        {
            get { return _textValue; }
            set { SetProperty(ref _textValue, value); }
        }
        public DelegateCommand GoBackCommand { get; }
        
        /// <summary>
        /// 导航到当前视图后（视图已激活）
        /// 初始化数据、加载资源、订阅事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
            // navigationContext.NavigationService.RequestNavigate();
        }
        /// <summary>
        /// 导航到当前视图前
        /// 决定是否复用现有实例（如返回 `true` 则复用，`false` 则创建新实例）
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 离开当前视图前（视图即将停用）
        /// 保存数据、释放资源、取消事件订阅
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        /// <summary>
        /// 确认是否允许导航离开
        /// </summary>
        /// <param name="navigationContext">包含导航目标、参数等信息</param>
        /// <param name="continuationCallback">回调函数，传递 `true` 允许导航，`false` 取消导航</param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // var messageBoxResult = MessageBox.Show("1234","1234", MessageBoxButton.YesNo, MessageBoxImage.Information);
            // bool flag = messageBoxResult == MessageBoxResult.Yes;
            continuationCallback.Invoke(true);
        }
    }
}