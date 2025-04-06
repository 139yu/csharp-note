using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataBindStudy.Models;

namespace DataBindStudy.Base;

public class BaseAttach
{
    public static readonly DependencyProperty ItemSourceProperty = DependencyProperty
        .RegisterAttached("ItemSource",
            typeof(ObservableCollection<ViewModel02>),
            typeof(BaseAttach), 
            new PropertyMetadata(null,OnPropertyChangedCallback));

    public static ObservableCollection<ViewModel02> GetItemSource(UIElement uiElement)
    {
        return (ObservableCollection<ViewModel02>)uiElement.GetValue(ItemSourceProperty);
    }

    public static void SetItemSource(UIElement uiElement,ObservableCollection<ViewModel02> value)
    {
        uiElement.SetValue(ItemSourceProperty,value);        
    }

    public static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        Console.WriteLine("changed");
        var p = d as WrapPanel;
        ObservableCollection<ViewModel02> list = e.NewValue as ObservableCollection<ViewModel02>;
        BindValue(p, list);
        // 监听集合变化
        list.CollectionChanged += ((sender, args) =>
        {
            BindValue(p, list);
        });
    }

    static void BindValue(WrapPanel parent, ObservableCollection<ViewModel02> list)
    {
        parent.Children.Clear();
        foreach (var item in list)
        {
            // item.Value2值变化不触发UI更新
            // TextBox t = new TextBox()
            // {
            //     Text = item.Value02,
            //     Margin = new Thickness(10, 0, 10, 0)
            // };
            // p.Children.Add(t);
            
            // 触发UI更新
            TextBlock tb = new TextBlock();
            tb.Margin = new Thickness(10, 0, 10, 0);
            Binding binding = new Binding("Value02");
            binding.Source = item;
            BindingOperations.SetBinding(tb, TextBlock.TextProperty, binding);
            parent.Children.Add(tb);
        }
    }
}