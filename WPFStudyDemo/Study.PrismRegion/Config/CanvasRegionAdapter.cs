using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace Study.PrismRegion.Config
{
    public class CanvasRegionAdapter: RegionAdapterBase<Canvas>
    {
        public CanvasRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, Canvas regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                if (regionTarget == null)
                    throw new ArgumentNullException(nameof (regionTarget));
                // 移除旧视图，显示添加的第一个视图
                if (e.OldItems != null && e.OldItems.Count > 0)
                {
                    foreach (UIElement eOldItem in e.OldItems)
                    {
                        regionTarget.Children.Remove(eOldItem);
                    }
                }
                if (e.NewItems != null && e.NewItems.Count > 0)
                {
                    regionTarget.Children.Add((UIElement)e.NewItems[0]);
                }
            };
            
            
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.NewItems == null || e.NewItems.Count == 0)
                {
                    return;
                }
                // 当新视图添加且无激活视图时，激活第一个视图
                if (e.Action != NotifyCollectionChangedAction.Add || region.ActiveViews.Count() != 0)
                    return;
                region.Activate(e.NewItems[0]);
            };
        }

        protected override IRegion CreateRegion()
        {
            // 保持只有一个视图处于激活状态
            return new SingleActiveRegion();
            // 保持所有视图处于激活状态
            // return new AllActiveRegion();
        }
    }
}