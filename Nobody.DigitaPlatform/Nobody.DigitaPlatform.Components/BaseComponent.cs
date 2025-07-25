using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Nobody.DigitaPlatform.Components
{
    public class BaseComponent : UserControl
    {
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty
            .Register(nameof(DeleteCommand), typeof(ICommand), typeof(BaseComponent));

        public ICommand DeleteCommand
        {
            get => (ICommand)this.GetValue(DeleteCommandProperty);
            set => this.SetValue(DeleteCommandProperty, value);
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty
            .Register(nameof(IsSelected), typeof(bool), typeof(BaseComponent), new PropertyMetadata(false));

        public bool IsSelected
        {
            get => (bool)this.GetValue(IsSelectedProperty);
            set => this.SetValue(IsSelectedProperty, value);
        }

        public static readonly DependencyProperty DeleteParameterProperty = DependencyProperty
            .Register(nameof(DeleteParameter), typeof(object), typeof(BaseComponent));

        public object DeleteParameter
        {
            get => (object)this.GetValue(DeleteParameterProperty);
            set => this.SetValue(DeleteParameterProperty, value);
        }

        /*public static readonly DependencyProperty ShowWidthProperty = DependencyProperty
            .Register(nameof(ShowWidth), typeof(double), typeof(BaseComponent), new PropertyMetadata(0.0));

        public double ShowWidth
        {
            get => (double)this.GetValue(ShowWidthProperty);
            set => this.SetValue(ShowWidthProperty, value);
        }

        public static readonly DependencyProperty ShowHeightProperty = DependencyProperty
            .Register(nameof(ShowHeight), typeof(double), typeof(BaseComponent), new PropertyMetadata(0.0));

        public double ShowHeight
        {
            get => (double)this.GetValue(ShowHeightProperty);
            set => this.SetValue(ShowHeightProperty, value);
        }*/

        public static readonly DependencyProperty ResizeDownCommandProperty = DependencyProperty
            .Register(nameof(ResizeDownCommand), 
                typeof(ICommand), typeof(BaseComponent), 
                new PropertyMetadata(default(ICommand)));

        public ICommand ResizeDownCommand
        {
            get => (ICommand)this.GetValue(ResizeDownCommandProperty);
            set => this.SetValue(ResizeDownCommandProperty, value);
        }
        public static readonly DependencyProperty ResizeUpCommandProperty = DependencyProperty
            .Register(nameof(ResizeUpCommand),
                typeof(ICommand), typeof(BaseComponent),
                new PropertyMetadata(default(ICommand)));

        public ICommand ResizeUpCommand
        {
            get => (ICommand)this.GetValue(ResizeUpCommandProperty);
            set => this.SetValue(ResizeUpCommandProperty, value);
        }
        public static readonly DependencyProperty ResizeMoveCommandProperty = DependencyProperty
            .Register(nameof(ResizeMoveCommand),
                typeof(ICommand), typeof(BaseComponent),
                new PropertyMetadata(default(ICommand)));

        public ICommand ResizeMoveCommand
        {
            get => (ICommand)this.GetValue(ResizeMoveCommandProperty);
            set => this.SetValue(ResizeMoveCommandProperty, value);
        }

        public int RotateAngle
        {
            get => (int)GetValue(RotateAngleProperty);
            set => SetValue(RotateAngleProperty, value);
        }

        public static readonly DependencyProperty RotateAngleProperty =
            DependencyProperty.Register(nameof(RotateAngle), typeof(int), typeof(BaseComponent), new PropertyMetadata(0));
        public int FlowDirection
        {
            get { return (int)GetValue(FlowDirectionProperty); }
            set { SetValue(FlowDirectionProperty, value); }
        }
        public static readonly DependencyProperty FlowDirectionProperty =
            DependencyProperty.Register(nameof(FlowDirection), typeof(int), typeof(BaseComponent), new PropertyMetadata(0, (d, e) =>
            {
                var state = VisualStateManager.GoToState(d as BaseComponent, e.NewValue.ToString() == "1" ? "EWFlowState" : "WEFlowState", false);
            }));
        #region 缩放命令

        private Point _startPoint;
        private bool _isMoving = false;

        protected void Ellipse_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ResizeDownCommand?.Execute(e);
            // Mouse.Capture((IInputElement)sender);
            // // 获取按下鼠标相对Canva的坐标
            // var parent = GetParent(this);
            // _startPoint = e.GetPosition(parent);
            // _isMoving = true;
            // e.Handled = true;
        }

        protected void Ellipse_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResizeUpCommand?.Execute(e);
            /*_isMoving = false;
            Mouse.Capture(null);
            e.Handled = true;*/
        }

        protected void Ellipse_OnMouseMove(object sender, MouseEventArgs e)
        {
            ResizeMoveCommand?.Execute(e);
            /*if (!_isMoving)
            {
                return;
            }
            var currentPoint = e.GetPosition(GetParent(this));
            var c = (sender as Ellipse).Cursor;
            if (c == null)
            {
                return;
            }
            var width = currentPoint.X - _startPoint.X;
            var height = currentPoint.Y - _startPoint.Y;
            Debug.WriteLine($"offset width: {width},offset height: {height},Show width: {ShowWidth}, show height: {ShowHeight}");

            if (c == Cursors.SizeWE)
            {
                // 水平方向
                ShowWidth += width;
            }
            else if (c == Cursors.SizeNS)
            {
                // 垂直方向
                ShowHeight += height;
            }
            else if (c == Cursors.SizeNWSE)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    ShowWidth += width;
                    ShowHeight += height;
                }
                // 保持缩放比例
                double rate = width / height;
                ShowWidth += width;
                ShowHeight = this.ShowWidth / rate;
            }

            _startPoint = currentPoint;
            e.Handled = true;
        }

        protected Canvas GetParent(DependencyObject d)
        {
            while (d != null && !(d is Canvas))
            {
                d = VisualTreeHelper.GetParent(d);
            }
            return d as Canvas; // 可能返回null需处理*/

        }

        #endregion


        protected void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteCommand?.Execute(DeleteParameter);
        }
    }
}