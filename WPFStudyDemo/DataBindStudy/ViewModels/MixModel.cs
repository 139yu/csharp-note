using DataBindStudy.Models;

namespace DataBindStudy.ViewModels
{
    public class MixModel
    {
        public EmployeeModel Employee { get; set; } =new EmployeeModel();
        public UserViewModel User { get; set; } = new UserViewModel();
    }
}