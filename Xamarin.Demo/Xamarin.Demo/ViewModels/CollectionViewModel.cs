using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Demo.ViewModels
{
    public class CollectionViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<string> PickerItems { get; set; } = new List<string>();
        public CollectionViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                string name = null;
                if (i % 2 == 0)
                {
                    name = "tom.jpg";
                }
                else
                {
                    name = "temp.jpg";
                }

                string des = $"item-{i + 1} -xcvzxcvasdf";
                PickerItems.Add(des);
                Items.Add(new Item()
                {
                    Name = name,
                    Description = des
                });
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}