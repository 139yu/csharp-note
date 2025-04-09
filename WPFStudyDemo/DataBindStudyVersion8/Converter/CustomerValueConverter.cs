using System.Globalization;
using System.Windows.Data;

namespace DataBindStudyVersion8.Converter;

public class CustomerValueConverter: IValueConverter
{   
    /// <summary>
    /// 将绑定源的值转换为适合绑定目标属性的类型
    /// </summary>
    /// <param name="value">从绑定源获取的值</param>
    /// <param name="targetType">绑定目标属性所期望的数据类型</param>
    /// <param name="parameter">这是一个可选参数，可以在 XAML 绑定中通过 ConverterParameter 属性设置</param>
    /// <param name="culture">用于提供与文化相关的信息，例如日期时间格式、数字格式等</param>
    /// <returns>返回转换后的值，该值的类型应该与 targetType 兼容，以便可以设置到绑定目标属性上。</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// 与 Convert 方法相反，当数据从绑定目标流向绑定源（例如在双向绑定中，用户在 TextBox 中输入值后，需要将该值转换为适合绑定源属性的类型）时，会调用此方法
    /// </summary>
    /// <param name="value">从绑定目标获取的值，其类型取决于绑定目标属性的类型</param>
    /// <param name="targetType">绑定源属性所期望的数据类型</param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns>返回转换后的值，该值的类型应该与绑定源属性的类型兼容</returns>
    /// <exception cref="NotImplementedException"></exception>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}