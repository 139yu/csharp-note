using System.Collections.ObjectModel;
using DataBindStudyVersion8.Models;

namespace DataBindStudyVersion8.UIModels;

public class MainViewModel
{
    public ViewModel01 VM01 { get; set; } = new ViewModel01();
    public ViewModel02 VM02 { get; set; } = new ViewModel02();

    public List<ViewModel01> ListViewModel { get; set; } = new List<ViewModel01>()
    {
        new ViewModel01(){Value01 = "001"},
        new ViewModel01(){Value01 = "002"},
        new ViewModel01(){Value01 = "003"},
        new ViewModel01(){Value01 = "004"},
    };

  
}