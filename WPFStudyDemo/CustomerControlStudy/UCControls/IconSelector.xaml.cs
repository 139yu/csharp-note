using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace CustomerControlStudy.UCControls
{
    public partial class IconSelector : UserControl,INotifyPropertyChanged
    {
        public IconSelector()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        public List<string> Items { get; set; } =
            new List<string>()
            {
                "111", "222", "333", "444", "555", "666"
            };

        private bool _isChecked = false;

        public bool IsChecked
        {
            get => _isChecked;
            set => SetField(ref _isChecked, value);
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get => _selectedItem;
            set => SetField(ref _selectedItem, value);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}