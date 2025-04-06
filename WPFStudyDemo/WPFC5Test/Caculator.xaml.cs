using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFC5Test
{
    public partial class Caculator : Window
    {
        public Caculator()
        {
            InitializeComponent();
        }
        
        private double _currentValue;
        private double _storedValue;
        private string _currentOperator;
        private bool _isNewNumber = true;
         // 数字按钮点击
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var number = button.Content.ToString();

            if (_isNewNumber)
            {
                Display.Text = number;
                _isNewNumber = false;
            }
            else
            {
                Display.Text += number;
            }

            _currentValue = Convert.ToDouble(Display.Text);
        }

        // 运算符按钮点击
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _currentOperator = button.Content.ToString();
            _storedValue = _currentValue;
            _isNewNumber = true;
        }

        // 等于按钮点击
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (_currentOperator)
                {
                    case "+":
                        _currentValue = _storedValue + _currentValue;
                        break;
                    case "-":
                        _currentValue = _storedValue - _currentValue;
                        break;
                    case "×":
                        _currentValue = _storedValue * _currentValue;
                        break;
                    case "÷":
                        if (_currentValue == 0) throw new DivideByZeroException();
                        _currentValue = _storedValue / _currentValue;
                        break;
                }

                Display.Text = _currentValue.ToString();
                _isNewNumber = true;
            }
            catch (Exception ex)
            {
                Display.Text = "Error";
                _isNewNumber = true;
            }
        }

        // 清除按钮
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _currentValue = 0;
            _storedValue = 0;
            _currentOperator = null;
            _isNewNumber = true;
        }

        // 正负号按钮
        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            _currentValue *= -1;
            Display.Text = _currentValue.ToString();
        }

        // 百分比按钮
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            _currentValue /= 100;
            Display.Text = _currentValue.ToString();
            _isNewNumber = true;
        }

        // 小数点按钮
        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
                _isNewNumber = false;
            }
        }
    }
}