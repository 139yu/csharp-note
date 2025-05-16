using System;
using System.Windows.Input;
using Prism.Mvvm;

namespace SmartParking.Client.SystemModule.Models
{
    public class UserItemModel: BindableBase
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime? Birthday { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand{ get; set; }
        public ICommand AllocateRoleCommand{ get; set; }

    }
}