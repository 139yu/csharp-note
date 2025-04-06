# 常用控件

## 布局控件

### Grid

**Grid** 是 WPF 中**最强大的布局容器**，通过行列划分的网格系统，精准控制子元素的布局位置和尺寸。其灵活性和功能丰富性使其成为复杂 UI 设计的首选容器。

#### **1. Grid 的核心特性**

- **网格化布局**：通过 `行（RowDefinitions）` 和 `列（ColumnDefinitions）` 定义二维布局结构。
- **灵活尺寸控制**：支持固定值、比例分配（`*`）和自适应内容（`Auto`）。
- **单元格合并**：子控件可跨多行多列（`Grid.RowSpan`、`Grid.ColumnSpan`）。
- **对齐与边距**：通过 `HorizontalAlignment`、`VerticalAlignment` 和 `Margin` 微调控件位置。

#### **2. 基础用法**

**(1) 定义行与列**

```xaml
<Grid>
    <!-- 定义3行：固定高度、按比例分配、自适应内容 -->
    <Grid.RowDefinitions>
        <RowDefinition Height="50"/>               <!-- 固定高度 -->
        <RowDefinition Height="2*"/>               <!-- 比例分配（占剩余空间2/3） -->
        <RowDefinition Height="Auto"/>             <!-- 高度自适应内容 -->
    </Grid.RowDefinitions>

    <!-- 定义2列：按比例分配、固定宽度 -->
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="3*"/>             <!-- 宽度占剩余空间3/4 -->
        <ColumnDefinition Width="200"/>            <!-- 固定宽度 -->
    </Grid.ColumnDefinitions>
</Grid>
```

**(2) 放置控件到指定单元格**

```xaml
<Grid>
    <!-- ...（行列定义同上）... -->
    
    <!-- 放置按钮到第0行第0列 -->
    <Button Content="按钮1" Grid.Row="0" Grid.Column="0"/>

    <!-- 文本框跨两列（第1行，列0到1） -->
    <TextBox Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="2" Text="跨列示例"/>
</Grid>
```

#### **3. 关键属性与技巧**

**(1) 尺寸单位**

- **固定值**：`Height="100"`
- **比例分配**：`Width="2*"`（按比例分配剩余空间）
- **自适应内容**：`Height="Auto"`（高度由子控件决定）

```xaml
<Button 
    Grid.Row="0" 
    Grid.Column="0"
    HorizontalAlignment="Center"  <!-- 水平居中 -->
    VerticalAlignment="Bottom"   <!-- 垂直底部对齐 -->
    Margin="10"                  <!-- 外边距 -->
/>
```

**(3) 行列间距**

通过 `Grid.RowSpacing` 和 `Grid.ColumnSpacing`（WPF 4.6+）设置行列间距：

```xaml
<Grid RowSpacing="10" ColumnSpacing="5">
    <!-- 行列定义 -->
</Grid>
```

#### **3. 关键属性与技巧**

**(1) 尺寸单位**

- **固定值**：`Height="100"`
- **比例分配**：`Width="2*"`（按比例分配剩余空间）
- **自适应内容**：`Height="Auto"`（高度由子控件决定）

**(2) 对齐与边距**

```xaml
<Button 
    Grid.Row="0" 
    Grid.Column="0"
    HorizontalAlignment="Center"  <!-- 水平居中 -->
    VerticalAlignment="Bottom"   <!-- 垂直底部对齐 -->
    Margin="10"                  <!-- 外边距 -->
/>
```

**(3) 行列间距**

通过 `Grid.RowSpacing` 和 `Grid.ColumnSpacing`（WPF 4.6+）设置行列间距：

```xaml
<Grid RowSpacing="10" ColumnSpacing="5">
    <!-- 行列定义 -->
</Grid>
```

#### **4. 典型应用场景**

**(1) 表单布局**

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <TextBlock Text="用户名:" Grid.Row="0" Grid.Column="0"/>
    <TextBox Grid.Row="0" Grid.Column="1" Margin="5"/>

    <TextBlock Text="密码:" Grid.Row="1" Grid.Column="0"/>
    <PasswordBox Grid.Row="1" Grid.Column="1" Margin="5"/>

    <Button Content="登录" Grid.Row="2" Grid.ColumnSpan="2" Width="100" Margin="5"/>
</Grid>
```

**(2) 仪表盘或复杂面板**

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <ChartControl Grid.Row="0" Grid.Column="0"/>  <!-- 左上图表 -->
    <DataGrid Grid.Row="0" Grid.Column="1"/>      <!-- 右上表格 -->
    <StatusPanel Grid.Row="1" Grid.ColumnSpan="2"/><!-- 底部状态栏 -->
</Grid>
```

**(3) 响应式布局**

通过比例分配实现窗口缩放时元素自适应：

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="200"/>          <!-- 左侧导航栏固定宽度 -->
        <ColumnDefinition Width="*"/>            <!-- 右侧内容区自适应 -->
    </Grid.ColumnDefinitions>
    
    <NavigationMenu Grid.Column="0"/>
    <ContentArea Grid.Column="1"/>
</Grid>
```



### StackPanel

`StackPanel` 是一个容器控件，它可以将子元素沿**垂直方向（默认）\**或\**水平方向**依次堆叠排列。所有子元素会按添加顺序排列，且不会自动换行。如果内容超出范围，需结合 `ScrollViewer` 实现滚动。

### DockPanel

与WinForm的Dock属性类似，通过设置Dock停靠进行布局。

**主要属性**：

1. 基本属性：LastChildFill，布尔值，设置最后一个元素是否填充剩余部分
2. 附加属性：Docker.Dock，值有Left、Top、Right、Bottom，在子元素中设置

填充内容时与元素的顺序有关。

**使用场景**：主窗口功能区域划分。

示例：

```xaml
<Window x:Class="WpfStudy01.DockPanel"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="DockPanel" Height="450" Width="800">
    <Grid>
        <DockPanel>
            <Button DockPanel.Dock="Top">button1</Button>
            <Button DockPanel.Dock="Left">button2</Button>
            <Button DockPanel.Dock="Right">button3</Button>
            <Button DockPanel.Dock="Bottom">button4</Button>
            <Button>button5</Button>
        </DockPanel>
    </Grid>
</Window>

```

效果：

![image-20250330203209314](assets/image-20250330203209314.png)

### WrapPanel

唯一一个不能被Grid替代的布局控件，按行排列，尺寸不够时换行；按列排列，尺寸不够时折行。

**主要属性：**Orientation（布局方向）

**使用场景**：界面图表式布局

示例：

```xaml
<Window x:Class="WpfStudy01.WrapPanelWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        FontSize="20"
        Title="WrapPanelWin" Height="450" Width="800">
    <WrapPanel Orientation="Horizontal">
        <Button Width="150">按钮1</Button>
        <Button Width="160">按钮2</Button>
        <Button Width="180">按钮3</Button>
        <Button Width="190">按钮4</Button>
        <Button Width="200">按钮5</Button>
        <Button Width="210">按钮6</Button>
        <Button Width="220">按钮7</Button>
        <Button Width="220">按钮8</Button>
    </WrapPanel>
</Window>
```

效果：

![image-20250330204454078](assets/image-20250330204454078.png)

如果是按列排列，列宽默认为子元素最大宽度。

### UniFormGrid

另一种行列风格布局，自动生成统一一致的行列。

主要属性：Rows、Columns

**使用场景：**仪表盘、驾驶舱

经常被Grid代替

### Canvas

通过精确坐标定位放置子元素。

**主要属性**：

附加属性：Canvas.Left、Canvas.Top、Canvas.Right、Canvas.Bottom，设置距离x、y的距离

**使用场景：**编辑场景

子元素不设置定位，默认在（0,0）位置，在设置附加属性时，Canvas.Left优先于Canvas.Right，Canvas.Top优先于Canvas.Bottom

### InkCanvas

支持任意笔画输入的画布组件

**主要属性**：

基本属性：EditingModel、Stroks（获取所有笔记）、DefaultDrawingAttributes（设置笔记样式）

附加属性：InkCanvas.Left、InkCanvas.Top、InkCanvas.Right、InkCanvas.Bottom、

**使用场景：**画板

**示例**：

```xaml
<Window x:Class="WpfStudy01.InkCanvasWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="InkCanvasWin" Height="450" Width="800">
    <InkCanvas EditingMode="Ink">
        <InkCanvas.DefaultDrawingAttributes>
            <DrawingAttributes Color="Aqua" Width="10"/>
        </InkCanvas.DefaultDrawingAttributes>
    </InkCanvas>
</Window>
```

效果：

![image-20250330212456678](assets/image-20250330212456678.png)

### Border

最基础的装饰。

**主要属性：**BorderBrush、BorderThinkness、Background、CornerRadius

**使用场景：**绘制边线、背景色、圆角

### 其他控件

#### 拓展布局控件

- TabControl、TabItem、TabPanel

  TabControl同Tab选项页，TabItem为选项页的选项卡，TabPanel为TabItem的容器

- ToolBarPanel、ToolBarOverflowPanel

  ToolBarPanel：工具栏；

  ToolBarOverflowPanel：一行显示不下折行，基于StackPanel

- VirtualizingStackPanel

  虚拟化的StackPanel，呈现上同StackPanel，性能上有稍微提升；呈现在视觉区域的内容它才会加载，类似于懒加载。

#### 特殊容器

- ScrollViewer

  超出的内容提供滚动条

- GroupBox

  同WinForm

- Expander

  类似于手风琴或折叠面板，可以展开和收起内容，如菜单、子菜单。


### 层级显示

所有容器都支持通过`Panel.ZIndex`调整层级。

### 自定义Panel

代码如下：

```C#
public class CustomerWrapPanel: Panel
{
    // 子元素最大宽度
    private double maxWidth = 0;
    protected override Size MeasureOverride(Size availableSize)
    {
        double totalHeight = 0;
        foreach (FrameworkElement internalChild in this.InternalChildren)
        {
            // 测量元素所需宽高
            internalChild.Measure(availableSize);
            if (internalChild.DesiredSize.Width > maxWidth)
            {
                maxWidth = internalChild.DesiredSize.Width;
            }

            totalHeight += internalChild.DesiredSize.Height;
        }

        return availableSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        //元素坐标
        double x = 0;
        double y = 0;
        // 所在行
        int rowIndex = 1;
        // 所在列
        int columnIndex = 0;
        double currentColumnHeight = 0;
        foreach (FrameworkElement child in this.InternalChildren)
        {
            var width = child.DesiredSize.Width;
            var height = child.DesiredSize.Height;
            // 剩下高度不足以放下元素，折行
            if (currentColumnHeight + height > finalSize.Height)
            {
                columnIndex += 1;
                currentColumnHeight = height;
                rowIndex = 0;
                x = columnIndex * maxWidth;
                y = 0;
            }
            else
            {
                currentColumnHeight += height;
            }
            // 设置元素坐标，宽高
            child.Arrange(new Rect(x,y,width, height));
            y += height;
            rowIndex++;
        }

        return finalSize;
    }
}
```

```xaml
<Window x:Class="WpfStudy01.CustomerStackPanelWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="CustomerStackPanelWin" Height="450" Width="800">
    <local:CustomerWrapPanel>
        <Button Height="150" Width="200">按钮1</Button>
        <Button Height="150" Width="200">按钮2</Button>
        <Button Height="150" Width="200">按钮3</Button>
        <Button Height="150" Width="200">按钮4</Button>
        <Button Height="150" Width="200">按钮5</Button>
    </local:CustomerWrapPanel>
</Window>
```

效果：

![image-20250331105504868](assets/image-20250331105504868.png)

### WPF 窗体处理

**主要属性：**

WindowStartupLocation：窗体显示位置

WindowStyle：设置边框属性 

WindowState：最大化最小化

AllowsTransparency：区域是否支持透明度（Background为Transparent时 ）。值为true时，WindowStyle必须设置为None



默认情况下最大化会将任务栏也遮挡住，如果不想遮挡任务栏，可以在加载窗体之后再最大化。

#### WindowChrom

用于**自定义窗口的非客户区（Non-Client Area，标题栏、最大化、最小化、关闭栏）外观**，同时保留 Windows 原生窗口行为（如拖动调整大小、窗口命令等）。

**属性：**

| 属性                    | 说明                                                         |
| :---------------------- | :----------------------------------------------------------- |
| `GlassFrameThickness`   | 设置窗口边缘的“玻璃效果”区域厚度（需系统支持 Aero 效果）。   |
| `ResizeBorderThickness` | 定义窗口边缘可拖动调整大小的区域宽度。                       |
| `CaptionHeight`         | 定义标题栏的高度（用于支持双击最大化/还原的区域）。          |
| `CornerRadius`          | 设置窗口圆角半径（需结合透明背景使用）。                     |
| `UseAeroCaptionButtons` | 是否显示原生系统按钮（默认 `false`，通常隐藏以替换为自定义按钮）。 |

**示例**：

```xaml
<Window x:Class="WpfStudy01.WindowChromeWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="WindowChromeWin" Height="450" Width="800">
    <WindowChrome.WindowChrome>
        <WindowChrome UseAeroCaptionButtons="false" CornerRadius="5" />
    </WindowChrome.WindowChrome>
    <Grid>
    </Grid>
</Window>
```

#### Window.Clip

用于定义窗口（或任何 `UIElement`）的**可见区域**。通过设置该属性，可以将窗口内容限制在某个几何形状内，超出该形状的部分会被**剪切（隐藏）**

示例：

```xaml
<Window x:Class="WpfStudy01.ClipWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Background="Transparent"
        AllowsTransparency="True"
        WindowStartupLocation="CenterScreen"
        WindowStyle="None"
        Title="ClipWin" Height="450" Width="800">
    <!--裁剪成一个圆-->
    <Window.Clip>
        <EllipseGeometry Center="150,150" RadiusX="150" RadiusY="150"></EllipseGeometry>
    </Window.Clip>
    <Grid Background="Aqua">
        
    </Grid>
</Window>
```

效果：

![image-20250331131045715](assets/image-20250331131045715.png)

### 布局实际操作

代码：

```xaml
<Window x:Class="WpfStudy01.LayoutWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="LayoutWin" Height="450" Width="800">
    <DockPanel>
        <Grid DockPanel.Dock="Top" Background="Aqua" Height="30"></Grid>
        <Grid DockPanel.Dock="Bottom" Background="Yellow" Height="30"></Grid>
        <Grid Background="DarkGreen">
            <Grid.RowDefinitions>
                <RowDefinition Height="30"/>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Border Grid.Row="0" Background="Beige"></Border>
            <Grid Grid.Row="1" Background="Brown">
                <DockPanel>
                    <Border DockPanel.Dock="Right" Background="Coral" Width="150"></Border>
                    <Border DockPanel.Dock="Bottom" Height="150" Background="Cyan"></Border>
                    <ScrollViewer DockPanel.Dock="Left" Width="130" Background="Gainsboro">
                        <UniformGrid Columns="2">
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                            <Border Height="30" Width="30" Margin="5" Background="Beige"></Border>
                        </UniformGrid>
                    </ScrollViewer>
                    <Border></Border>
                </DockPanel>
            </Grid>
        </Grid>
    </DockPanel>
</Window>
```

效果：

![image-20250331135149563](assets/image-20250331135149563.png)

## 资源管理

### 文件资源管理

**复制到输出目录选项区别：**

| 选项           | 触发复制条件     | 适用场景                 | 性能影响       |
| -------------- | ---------------- | ------------------------ | -------------- |
| 不复制         | 永不复制         | 设计时使用、外部路径引用 | 无             |
| 始终复制       | 每次编译         | 频繁修改的动态资源       | 较高（大文件） |
| 如果较新则复制 | 仅当源文件更新时 | 静态资源、优化构建速度   | 较低           |

**生成操作选择资源和不选择资源区别：**

| 选项 | 优点                                                         | 缺点                                                         |
| ---- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| 资源 | 资源随程序集一起部署，无需担心文件丢失或路径问题，安全性和部署便捷性较高。同时，嵌入资源在一定程度上可以保护图片资源不被轻易修改 | 会增加程序集的大小，如果有大量或较大的图片资源，可能导致程序集体积显著增大，影响下载和启动速度 |
| 无   | 程序集大小不会因图片资源而显著增加，适用于图片资源较大或较多的情况，对程序启动和下载速度影响较小。此外，以文件形式存在便于在运行时对图片进行动态替换或修改。 | 依赖文件系统路径，部署时需要确保图片文件正确放置在相应位置，否则可能出现加载失败的问题。同时，图片文件相对容易被外部修改或误删除。 |

如果图片生成操作设置为资源（嵌入到程序集中），通常**无需复制到输出目录**，可通过 `Pack URI` 引用：

```xaml
<Image Source="pack://application:,,,/程序集名称;component/Images/photo.jpg"/>
```



在.Net Framework中，如果直接将图片复制到项目目录，默认不显示，需要点击显示所有文件，再将文件添加进项目

![image-20250331142519625](assets/image-20250331142519625.png)

![image-20250331142538075](assets/image-20250331142538075.png)

文件添加到项目，它的属性生成操作默认是资源：

![image-20250331142632154](assets/image-20250331142632154.png)

### 对象资源管理

在 WPF 中，**对象资源管理**是通过 **资源字典（Resource Dictionary）** 机制实现的，它允许你定义可重用的对象（如样式、模板、画笔、动画等），并在应用程序的不同位置共享这些资源

#### **资源的定义**

资源可以定义在以下作用域中：

- **控件级**（局部资源）：在某个控件（如 `Grid`、`Window`）的 `Resources` 属性中定义，仅该控件及其子元素可用。
- **窗口/页面级**：在 `Window` 或 `Page` 的 `Resources` 中定义，整个窗口或页面可用。
- **应用程序级**：在 `App.xaml` 的 `Application.Resources` 中定义，全局可用。
- **外部资源字典**：在独立的 XAML 文件中定义，通过合并字典引用。

```xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:sys="clr-namespace:System;assembly=System.Runtime"
                    >
    <!--导入所需要的命名空间xmlns:sys="clr-namespace:System;assembly=System.Runtime"-->
    <sys:Double x:Key="BtnWidth">100</sys:Double>
    <sys:Double x:Key="BtnHeight">30</sys:Double>
</ResourceDictionary>
```

使用：

```xaml
<Window x:Class="WpfStudy01.UseDictWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseDictWin" Height="450" Width="800">
    <!--导入资源-->
    <Window.Resources>
        <ResourceDictionary Source="pack://application:,,,/WpfStudy01;component/Res.xaml"></ResourceDictionary>
    </Window.Resources>
    <Grid>
        <Button Width="{StaticResource BtnWidth}" Height="{StaticResource BtnHeight}" Content="Click Me"></Button>
    </Grid>
</Window>

```

定义的资源类型必须有无参构造函数，C#中的所有对象都可以在资源中定义，需要在xml中引入命名空间。

如果是全局资源，可以在`App.xaml`中导入。

**资源层级**：自身资源->父级资源->。。。->窗口资源-> 应用程序资源-> 框架资源

#### 资源合并

在窗体文件中，`Window.Resources`下只能定义一个`ResourceDictionary`，如果要导入多个资源，则需要使用资源合并，如下：

```xaml
<Window x:Class="WpfStudy01.UseDictWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseDictWin" Height="450" Width="800">
    <!--导入资源-->
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WpfStudy01;component/Res.xaml"></ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <Button Width="{StaticResource BtnWidth}" Height="{StaticResource BtnHeight}" Content="Click Me"></Button>
    </Grid>
</Window>
```

`ResourceDictionary.MergedDictionaries`下可以定义多个`ResourceDictionary`，如果多个文件中定义了相同变量，则后导入的资源会覆盖前面的

#### 静态资源与动态资源

静态资源：程序编译时确定

动态资源：运行时可监听资源变化，使用`DynamicResource 变量名`来使用动态资源

#### 定义样式

代码：

```xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:sys="clr-namespace:System;assembly=System.Runtime"
                    >
    
        <!--
        TargetType：指定样式目标
        Setter：设置某个属性的值
    -->
    <Style x:Key="ButtonStyle" TargetType="Button">
        <Setter Property="Width" Value="100"/>
        <Setter Property="Height" Value="30"/>
    </Style>
</ResourceDictionary>
```

- 在Style中引入其他Style样式

```xaml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:sys="clr-namespace:System;assembly=System.Runtime"
                    >

    <Style x:Key="BaseStyle" TargetType="Button">
        <Setter Property="Background" Value="Aqua"/>
    </Style>
    <!--
        TargetType：指定样式目标
        Setter：设置某个属性的值
    -->
    <Style x:Key="ButtonStyle" TargetType="Button" BasedOn="{StaticResource BaseStyle}">
        <Setter Property="Width" Value="100"/>
        <Setter Property="Height" Value="30"/>
    </Style>
</ResourceDictionary>
```

#### 样式优先级与触发器

##### 样式优先级

样式优先级同CSS。

如果在窗体中定义了组件样式，而组件没有指定样式，将默认使用窗体文件中定义的样式：

```xaml
<Window x:Class="WpfStudy01.UseResWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseResWin" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WpfStudy01;component/Res.xaml" />
                <ResourceDictionary>
                    <Style TargetType="Button">
                        <Setter Property="Background" Value="Aquamarine"></Setter>
                    </Style>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <Button>提交</Button>
    </Grid>
</Window>
```

此窗体中的Button背景颜色将使用`Aquamarine`；如果只是外部导入，没有给目标元素指定不会应用：

```xaml
<Window x:Class="WpfStudy01.UseResWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseResWin" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WpfStudy01;component/Res.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <Button>提交</Button>
    </Grid>
</Window>
```

##### 触发器

代码如下：

```xaml
<Window x:Class="WpfStudy01.UseResWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseResWin" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <Style TargetType="CheckBox" x:Key="CheckBoxStyle">
                        <Style.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter Property="Foreground" Value="Red"></Setter>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        
    </Window.Resources>
    <Grid>
        <Button>提交</Button>
        <CheckBox Content="男" IsChecked="False" Style="{StaticResource CheckBoxStyle}"></CheckBox>
    </Grid>
</Window>
```

当CheckBox选中时，它的字体颜色就会变成红色。

**多条件触发**：

```xaml
<Window x:Class="WpfStudy01.UseResWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="UseResWin" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/WpfStudy01;component/Res.xaml" />
                <ResourceDictionary>
                    <Style TargetType="CheckBox" x:Key="CheckBoxStyle">
                        <Setter Property="Width" Value="100"></Setter>
                        <Setter Property="Height" Value="30"></Setter>
                        <Style.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter Property="Foreground" Value="Red"></Setter>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                    <Style TargetType="Button" x:Key="TriBtn">
                        <Setter Property="Width" Value="100"/>
                        <Setter Property="Height" Value="30"/>
                        <Style.Triggers>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsPressed" Value="True"/>
                                    <Condition Property="Width" Value="100"/>
                                </MultiTrigger.Conditions>
                                <MultiTrigger.Setters>
                                    <Setter Property="Foreground" Value="Chartreuse"></Setter>
                                </MultiTrigger.Setters>
                            </MultiTrigger>
                        </Style.Triggers>
                    </Style>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
        
    </Window.Resources>
    <Grid>
        <Button Style="{StaticResource TriBtn}" >提交</Button>
        <CheckBox Content="男" IsChecked="False" Style="{StaticResource CheckBoxStyle}" VerticalAlignment="Top"></CheckBox>
    </Grid>
</Window>
```

当按钮被点击并且宽度为100时，才触发，修改字体颜色。

- 事件触发器

```xaml
<Window.Triggers>
        <!--
        RoutedEvent：指定事件
        SourceName：指定元素名字
-->
        <EventTrigger RoutedEvent="Button.Click" SourceName="confirmBtn">
            <!--逻辑处理-->
        </EventTrigger>
    </Window.Triggers>
```

动画时会用到。

### 一个bug

代码：

```C#
public partial class ShowBugWin : Window
{
    public List<string> Datas { get; set; } = new List<string>();
    public ShowBugWin()
    {
        InitializeComponent();
        Datas.Add("AAA");
        Datas.Add("AAA");
        Datas.Add("AAA");
        Datas.Add("AAA");
        Datas.Add("AAA");
        this.DataContext = this;
    }
}
```



```xaml
<Window x:Class="WpfStudy01.ShowBugWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy01"
        mc:Ignorable="d"
        Title="ShowBugWin" Height="450" Width="800">
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <Style TargetType="TreeViewItem">
                        <Setter Property="Foreground" Value="GreenYellow"></Setter>
                        <Setter Property="FontSize" Value="30"></Setter>
                    </Style>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Window.Resources>
    <Grid>
        <TreeView ItemsSource="{Binding Datas}">
        </TreeView>
    </Grid>
</Window>

```

![image-20250331200032747](assets/image-20250331200032747.png)

样式放在`ResourceDictionary.MergedDictionaries`中，数据源是集合并且是动态生成的，都会有这个问题。

# 模板

## 控件模板

在 WPF 中，**控件模板（ControlTemplate）** 是定义控件**视觉外观和结构**的核心机制。它允许开发者完全重写控件的默认呈现方式，同时保留控件的原有功能（如事件、数据绑定等）。

### 1. 控件模板的核心作用

- **自定义控件外观**：打破默认样式，实现独特的视觉效果（如圆角按钮、自定义滑块轨道）。
- **分离视觉与逻辑**：保持控件的功能（点击、拖拽）不变，仅修改其视觉表现。
- **动态交互支持**：通过模板内的触发器（Triggers）实现状态变化（如鼠标悬停、选中状态）。

### **2. 控件模板的基本结构**

控件模板通过 `ControlTemplate` 类定义，通常包含以下部分：

```xaml
<ControlTemplate TargetType="{x:Type 控件类型}">
    <!-- 可视化树：定义控件的视觉结构 -->
    <Border Background="{TemplateBinding Background}"
            CornerRadius="5">
        <ContentPresenter/> <!-- 显示控件的内容 -->
    </Border>
    <!-- 触发器（可选） -->
    <ControlTemplate.Triggers>
        <Trigger Property="IsMouseOver" Value="True">
            <!-- 鼠标悬停时的效果 -->
        </Trigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
```

- **`TargetType`**：指定模板适用的控件类型（如 `Button`、`Slider`）。
- **可视化树**：通过 XAML 元素（如 `Border`、`Grid`）定义控件的视觉层次。
- **`TemplateBinding`**：将模板内元素的属性与控件的属性绑定（如背景色、字体大小）。
- **`ContentPresenter`**：占位符，用于显示控件的 `Content`（如按钮文本、图像）。

### 3. 如何使用控件模板？

#### **(1) 直接为控件指定模板**

```xaml
<Button Content="Click Me">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Border Background="LightBlue" CornerRadius="10" Padding="10">
                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
            </Border>
        </ControlTemplate>
    </Button.Template>
</Button>
```

#### (2) 通过样式定义模板（推荐）

```xaml
<Window.Resources>
    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border Background="{TemplateBinding Background}"
                            CornerRadius="8"
                            BorderThickness="1"
                            BorderBrush="Gray">
                        <ContentPresenter Margin="10"/>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</Window.Resources>
```

### 4. 控件模板的关键技术

#### **(1) 模板绑定（TemplateBinding）**

- 将模板内部元素的属性与控件的属性同步。
- 示例：`Background="{TemplateBinding Background}"` 表示使用按钮的 `Background` 属性值。

#### **(2) 触发器（Triggers）**

在模板内定义交互逻辑：

```xaml
<ControlTemplate.Triggers>
    <!-- 鼠标悬停时改变背景色 -->
    <Trigger Property="IsMouseOver" Value="True">
        <Setter TargetName="border" Property="Background" Value="LightGreen"/>
    </Trigger>
    <!-- 按钮按下时缩小 -->
    <Trigger Property="IsPressed" Value="True">
        <Setter TargetName="border" Property="RenderTransform">
            <Setter.Value>
                <ScaleTransform ScaleX="0.95" ScaleY="0.95"/>
            </Setter.Value>
        </Setter>
    </Trigger>
</ControlTemplate.Triggers>
```

#### (3) 命名元素（x:Name）

```xaml
<Border x:Name="border" ...>
```

## 数据模板

**数据模板（DataTemplate）** 是一种用于定义**数据对象如何可视化呈现**的机制。它解决了数据与界面之间的“最后一公里”问题，允许开发者将抽象的数据模型（如对象、集合）转化为直观的 UI 元素。以下是其核心要点：

------

### **1. 数据模板的本质**

- **数据 → UI 的转换器**：
  将数据对象的属性（如 `Person.Name`、`Product.Price`）映射到界面元素（如 `TextBlock`、`Image`）。
- **声明式设计**：通过 XAML 定义，无需编写代码逻辑即可完成数据绑定。

------

### **2. 为什么要用数据模板？**

- **解耦数据与界面**：同一数据对象可以有不同的展示方式（如列表项、详情卡片）。
- **动态适配**：根据数据类型或状态自动切换 UI 布局（如管理员与普通用户的不同视图）。
- **简化集合控件开发**：在 `ListBox`、`ListView` 等控件中高效渲染复杂数据项。

### **3. 核心应用场景**

#### **(1) 集合控件中的项模板（ItemTemplate）**

```xaml
<ListBox ItemsSource="{Binding Employees}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel>
                <Image Source="{Binding AvatarUrl}" Width="50"/>
                <TextBlock Text="{Binding Name}" FontWeight="Bold"/>
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

- **作用**：定义列表中每一项的显示样式。

#### **(2) 内容控件中的内容模板（ContentTemplate）**

```xaml
<ContentControl Content="{Binding SelectedProduct}">
    <ContentControl.ContentTemplate>
        <DataTemplate>
            <Border Background="#FFF5E6" Padding="10">
                <TextBlock Text="{Binding Description}"/>
            </Border>
        </DataTemplate>
    </ContentControl.ContentTemplate>
</ContentControl>
```

- **作用**：定义单个对象的展示方式（如详情页）。

### **4. 关键特性**

#### **(1) 隐式数据模板（按类型自动匹配）**

- 通过 `DataType` 指定适用的数据类型，无需手动关联：

```xaml
<DataTemplate DataType="{x:Type local:Book}">
    <TextBlock Text="{Binding Title}" Foreground="DarkBlue"/>
</DataTemplate>
```

- **效果**：所有绑定到 `Book` 类型对象的控件会自动应用此模板。

#### **(2) 显式数据模板（通过 Key 手动选择）**

- 定义带 `x:Key` 的模板，按需引用：

```xaml
<DataTemplate x:Key="CompactView">
    <TextBlock Text="{Binding Title}"/>
</DataTemplate>

<!-- 使用 -->
<ListBox ItemTemplate="{StaticResource CompactView}"/>
```

#### **(3) 动态模板选择（DataTemplateSelector）**

- 根据业务逻辑动态切换模板：

```c#
public class RoleTemplateSelector : DataTemplateSelector {
    public DataTemplate AdminTemplate { get; set; }
    public DataTemplate UserTemplate { get; set; }
    
    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        return (item as User).IsAdmin ? AdminTemplate : UserTemplate;
    }
}
```

### **5. 与控件模板（ControlTemplate）的区别**

| **特性**     | **数据模板（DataTemplate）**       | **控件模板（ControlTemplate）**    |
| :----------- | :--------------------------------- | :--------------------------------- |
| **作用对象** | 数据对象（如 `Person`、`Product`） | 控件本身（如 `Button`、`ListBox`） |
| **核心目的** | 数据如何显示                       | 控件外观如何绘制                   |
| **绑定方式** | 使用 `{Binding}`                   | 使用 `{TemplateBinding}`           |
| **典型场景** | 列表项展示、详情页面               | 自定义按钮形状、重写进度条样式     |

------

### **6. 数据模板的灵魂：数据绑定**

- **单向绑定**：数据 → UI（默认）

```xaml
<TextBlock Text="{Binding Price}"/>
```

- **双向绑定**：数据 ↔ UI（用于可编辑控件）

```xaml
<TextBox Text="{Binding Name, Mode=TwoWay}"/>
```

- **格式化绑定**：动态转换显示格式

```xaml
<TextBlock Text="{Binding Date, StringFormat='yyyy-MM-dd'}"/>
```

### 7.应用实例

#### 1.自定义数据模板

代码如下：

```xaml
<Window x:Class="WpfStudy02.DataTmpWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy02"
        xmlns:models="clr-namespace:WpfStudy02.Models"
        mc:Ignorable="d"
        Title="DataTmpWin" Height="450" Width="800">
    <Window.Resources>
        <ControlTemplate TargetType="ItemsControl" x:Key="ControlTemplate">
            <Border BorderBrush="Bisque" BorderThickness="1">
                <ItemsPresenter />
            </Border>
        </ControlTemplate>
        <DataTemplate DataType="{x:Type models:Person}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
                <TextBox TextAlignment="Center" Grid.Column="0" Text="{Binding Name}"></TextBox>
                <TextBox TextAlignment="Center" Grid.Column="1" Text="{Binding Age}"></TextBox>
                <TextBox TextAlignment="Center" Grid.Column="2" Text="{Binding Gender}"></TextBox>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <ItemsControl ItemsSource="{Binding Persons}">
           
        </ItemsControl>
    </Grid>
</Window>
```

```C#
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;
    public string Gender { get; set; } = "男";
}
public partial class DataTmpWin : Window
{
    public List<Person> Persons { get; set; } = new List<Person>();
    public DataTmpWin()
    {
        InitializeComponent();
        Persons.Add(new Person(){Name = "张珊",Age = 21,Gender = "男"});
        Persons.Add(new Person(){Name = "张珊",Age = 22,Gender = "女"});
        Persons.Add(new Person(){Name = "张珊",Age = 21,Gender = "男"});
        Persons.Add(new Person(){Name = "张珊",Age = 21,Gender = "男"});
        this.DataContext = this;
    }
}
```

显示效果：

![image-20250401110826164](assets/image-20250401110826164.png)

#### 2.数据模板选择

代码：

```C#
public class ListViewTmpSelector:DataTemplateSelector
{
    public DataTemplate NormalTemplate { get; set; }
    public DataTemplate FemaleTemplate { get; set; }
    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        Person person = item as Person;
        if (person.Gender == "女")
        {
            return FemaleTemplate;
        }
        return NormalTemplate;
    }
}
public partial class TmpSelectWin : Window
{
    public List<Person> Persons { get; set; } = new List<Person>();
    public TmpSelectWin()
    {
        InitializeComponent();
        Persons.Add(new Person(){Name="张居正" ,Age=21, Gender="男"});
        Persons.Add(new Person(){Name="上官婉儿", Age=21, Gender="女"});
        Persons.Add(new Person(){Name="诸葛亮", Age=23, Gender="男"});
        Persons.Add(new Person(){Name="独孤伽罗", Age=42, Gender="女"});
        Persons.Add(new Person(){Name="长孙无忌", Age=21, Gender="男"});
        Persons.Add(new Person(){Name="张三", Age=32, Gender="男"});
        DataContext = this;
    }
}
```

```xaml
<Window x:Class="WpfStudy02.TmpSelectWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:sys="clr-namespace:System.Runtime;assembly=System.Runtime"
        xmlns:local="clr-namespace:WpfStudy02"
        xmlns:models="clr-namespace:WpfStudy02.Models"
        mc:Ignorable="d"
        Title="TmpSelectWin" Height="450" Width="800">
    <Window.Resources>
        
        <DataTemplate DataType="{x:Type models:Person}" x:Key="NormalTmp">
            <StackPanel Orientation="Horizontal">
                <TextBox Text="{Binding Name}"></TextBox>
                <TextBox Text="{Binding Age}"></TextBox>
                <TextBox Text="{Binding Gender}"></TextBox>
            </StackPanel>
        </DataTemplate>
        <DataTemplate DataType="{x:Type models:Person}" x:Key="Female">
                <StackPanel Orientation="Horizontal"> 
                    <TextBox Text="{Binding Name}" Foreground="HotPink"></TextBox>
                    <TextBox Text="{Binding Age}"></TextBox>
                    <TextBox Text="{Binding Gender}"></TextBox>
                </StackPanel>
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <ListView ItemsSource="{Binding Persons}">
            <ListView.ItemTemplateSelector>
                <local:ListViewTmpSelector FemaleTemplate="{StaticResource Female}" NormalTemplate="{StaticResource NormalTmp}"></local:ListViewTmpSelector>
            </ListView.ItemTemplateSelector>
        </ListView>
    </Grid>
</Window>
```

效果：

![image-20250401151950496](assets/image-20250401151950496.png)

同理还有样式选择器。

# 依赖属性与附加属性

## 依赖属性

#### **1. 依赖属性是什么？**

依赖属性（Dependency Property）是 WPF 中一种**增强版的属性系统**，它扩展了传统的 CLR（公共语言运行时）属性功能，支持动态值分配、继承、绑定和高效资源管理。依赖属性是 WPF 实现数据驱动界面（如数据绑定、样式、动画）的核心基础。

#### **2. 依赖属性的作用**

依赖属性解决了传统属性的以下局限性，并提供了以下关键功能：

| **功能**           | **解决的问题**                                               |
| :----------------- | :----------------------------------------------------------- |
| **动态值优先级**   | 支持多个值来源（如本地值、样式、继承值），按优先级自动选择生效值。 |
| **数据绑定与动画** | 与 WPF 的绑定系统无缝集成，支持双向绑定和动画驱动的值变更。  |
| **资源优化**       | 仅存储被显式修改的值，未赋值的属性共享默认值，减少内存占用。 |
| **属性值继承**     | 子元素可继承父容器的属性值（如 `FontFamily`、`DataContext`）。 |
| **元数据扩展**     | 支持通过元数据定义默认值、值变更回调、绑定验证等高级行为。   |

------

#### **3. 依赖属性的元数据（Metadata）**

依赖属性的元数据通过 `PropertyMetadata` 或其子类（如 `FrameworkPropertyMetadata`）定义，用于描述属性的行为和特性。元数据包含以下关键信息：

##### **(1) 默认值（Default Value）**

- 定义依赖属性的初始值，当未显式赋值时生效。
- 示例：

```C#
new FrameworkPropertyMetadata("Default Text")
```

##### **(2) 属性变更回调（PropertyChangedCallback）**

- 当属性值变化时触发的回调方法，用于更新 UI 或执行逻辑。
- 示例：

```c#
new FrameworkPropertyMetadata(
    defaultValue: 0,
    propertyChangedCallback: (d, e) => 
    {
        var control = d as MyControl;
        control?.OnValueChanged(e.OldValue, e.NewValue);
    }
)
```

##### **(3) 强制值回调（CoerceValueCallback）**

- 在属性值被设置前对其进行验证或修正（如限制数值范围）。
- 示例：

```C#
new FrameworkPropertyMetadata(
    defaultValue: 0,
    coerceValueCallback: (d, value) => 
    {
        return Math.Max(0, (int)value); // 确保值不小于0
    }
)
```

##### **(4) 其他标志（Flags）**

依赖属性的元数据标志位通过 `FrameworkPropertyMetadataOptions` 枚举定义，用于控制属性的行为和交互逻辑。以下是常用标志位的说明：

| 枚举值                         | 作用                                                         | 典型场景                                                     |
| ------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| None                           | 依赖属性使用默认行为，不应用任何特殊选项。                   | 简单的、不需要特殊处理的依赖属性，例如一个用于计数且对 WPF 布局、数据绑定等无特殊影响的属性。 |
| Inherits                       | 使依赖属性的值能够从父元素传递到子元素，具有继承性。         | 如设置一个`StackPanel`的`Foreground`属性为红色，`StackPanel`内的所有文本元素（如`TextBlock`）会自动继承该红色前景色。 |
| OverridesInheritanceBehavior   | 覆盖依赖属性的继承行为，阻止该属性从父元素继承值。           | 在特定的`TextBlock`控件中，不想继承其父容器设置的`FontSize`属性，可通过此选项实现。 |
| AffectsMeasure                 | 当此依赖属性的值发生改变时，会促使元素重新进行测量，即调用`MeasureOverride`方法。 | 比如改变`Grid`中某一行的`Height`属性，会导致`Grid`重新测量其子元素以确定布局。 |
| AffectsArrange                 | 当该依赖属性值改变时，会触发元素重新进行排列，即调用`ArrangeOverride`方法。 | 若改变`Canvas`中某个元素的`Margin`属性，会影响该元素在`Canvas`中的排列位置，此时会触发重新排列。 |
| AffectsRender                  | 当依赖属性的值更改时，会引起元素重新渲染。                   | 例如修改`Rectangle`的`Fill`属性，改变其填充颜色，就需要重新渲染该矩形以显示新颜色。 |
| NotDataBindable                | 表明该依赖属性不支持数据绑定。                               | 一些仅用于控件内部逻辑，不希望通过数据绑定进行访问或修改的属性，如控件内部用于临时状态标记的属性。 |
| BindTwoWayByDefault            | 将依赖属性的默认绑定模式设定为双向绑定。                     | `Slider`的`Value`属性，用户拖动滑块改变值时，绑定的数据源值也改变；数据源值改变时，滑块位置也相应更新。 |
| Journal                        | 使依赖属性的值被记录在导航历史中，以便在导航回退时恢复到之前的值。 | 在多页面应用中，用户在某个页面设置了特定的主题颜色，导航回退时希望恢复该颜色设置的场景。 |
| SubPropertiesDoNotAffectRender | 意味着该属性的子属性发生变化时，不会导致元素重新渲染。       | 对于一个复杂的`Geometry`属性，它包含多个子属性（如点坐标等），通常子属性变化不直接触发渲染更新。 |
| DefaultValueInitialized        | 指示依赖属性的默认值已初始化，这一过程通常由系统自动处理。   | 系统内部用于标记依赖属性默认值已完成初始化，开发人员在常规开发中一般无需手动操作。 |

#### **4. 如何定义依赖属性？**

以下是一个完整的依赖属性定义示例：

```C#
public class CustomControl : Control
{
    // 1. 注册依赖属性
    public static readonly DependencyProperty TextProperty = 
        DependencyProperty.Register(
            name: "Text",                              // 属性名称
            propertyType: typeof(string),              // 属性类型
            ownerType: typeof(CustomControl),          // 所属类型
            typeMetadata: new FrameworkPropertyMetadata(
                defaultValue: "Default",               // 默认值
                flags: FrameworkPropertyMetadataOptions.AffectsRender, // 元数据标志
                propertyChangedCallback: OnTextChanged // 值变更回调
            )
        );

    // 2. 属性变更回调方法
    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (CustomControl)d;
        control.UpdateDisplay(); // 自定义逻辑
    }

    // 3. CLR 包装器（可选但推荐）
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
```

#### **5. 依赖属性的使用场景**

##### **(1) 数据绑定**

```xaml
<CustomControl Text="{Binding UserName, Mode=TwoWay}"/>
```

##### **(2) 样式与模板**

```xaml
<Style TargetType="CustomControl">
    <Setter Property="Text" Value="Hello WPF"/>
    <Style.Triggers>
        <Trigger Property="IsFocused" Value="True">
            <Setter Property="Text" Value="Focused!"/>
        </Trigger>
    </Style.Triggers>
</Style>
```

##### **(3) 动画驱动**

```xaml
<Storyboard>
    <StringAnimationUsingKeyFrames 
        Storyboard.TargetProperty="Text"
        Duration="0:0:3">
        <DiscreteStringKeyFrame Value="Loading..." KeyTime="0:0:0"/>
        <DiscreteStringKeyFrame Value="Complete!" KeyTime="0:0:3"/>
    </StringAnimationUsingKeyFrames>
</Storyboard>
```

##### **(4) 自定义控件开发**

- 为控件暴露可绑定的属性（如 `Chart.DataPoints`）。
- 支持动态资源引用和样式覆盖。

#### **6. 依赖属性的优先级链**

当多个来源为依赖属性赋值时，按以下优先级生效（从高到低）：

| **优先级层级**          | **描述**                                                 | **示例**                                                     |
| :---------------------- | :------------------------------------------------------- | :----------------------------------------------------------- |
| **1. 本地值**           | 直接在控件上设置的值（XAML 或代码）。                    | `<Button Content="OK"/>`                                     |
| **2. 活动动画**         | 正在运行的动画（如 `Storyboard`）。                      | `<DoubleAnimation Storyboard.TargetProperty="Opacity" To="0.5"/>` |
| **3. 模板触发器**       | 控件模板中的触发器（如 `ControlTemplate.Triggers`）。    | `<Trigger Property="IsMouseOver" Value="True"> ... </Trigger>` |
| **4. 隐式样式触发器**   | 通过 `Style.Triggers` 定义的触发器。                     | `<Style.Triggers><Trigger .../></Style.Triggers>`            |
| **5. 模板生成的本地值** | 由控件模板生成的默认值（如 `ContentPresenter` 的内容）。 | `<ControlTemplate><ContentPresenter/></ControlTemplate>`     |
| **6. 隐式样式**         | 通过 `TargetType` 自动应用的样式（无 `x:Key`）。         | `<Style TargetType="Button"> ... </Style>`                   |
| **7. 样式继承**         | 通过 `BasedOn` 继承自父样式。                            | `<Style TargetType="Button" BasedOn="{StaticResource BaseStyle}"/>` |
| **8. 默认值**           | 依赖属性注册时定义的默认值。                             | `new FrameworkPropertyMetadata("Default")`                   |

## 附加属性

在 WPF 中，**附加属性（Attached Properties）** 是一种特殊类型的依赖属性，允许一个类为其他类定义额外的属性。以下是附加属性的核心概念、作用及使用方式的详细说明：

### **一、附加属性的定义**

附加属性通过以下步骤定义：

1. **注册附加属性**：使用 `DependencyProperty.RegisterAttached` 方法。
2. **提供静态访问器**：定义 `Get` 和 `Set` 方法以便 XAML 和代码访问。

#### **示例：定义一个 `Angle` 附加属性**

```C#
public class CirclePanel : Panel
{
    // 1. 注册附加属性
    public static readonly DependencyProperty AngleProperty =
        DependencyProperty.RegisterAttached(
            "Angle",
            typeof(double),
            typeof(CirclePanel),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentArrange)
        );

    // 2. 静态 Get 方法
    public static double GetAngle(UIElement element)
    {
        return (double)element.GetValue(AngleProperty);
    }

    // 3. 静态 Set 方法
    public static void SetAngle(UIElement element, double value)
    {
        element.SetValue(AngleProperty, value);
    }

    // 布局逻辑（使用附加属性排列子元素）
    protected override Size ArrangeOverride(Size finalSize)
    {
        foreach (UIElement child in Children)
        {
            double angle = GetAngle(child);
            // 根据角度计算位置并排列
        }
        return finalSize;
    }
}
```

#### 2. **命名规范与目标类型限制**

- **字段命名强制规则**
  注册的静态字段名称必须为 ​**`PropertyName + "Property"`**​（如 `ShowBorderProperty`），否则运行时将无法识别属性
- **参数类型需明确具体**
  - `Get/Set` 方法的第一个参数类型应限定为具体类型（如 `UIElement`），而非宽泛的 `DependencyObject`，避免非预期对象设置属性

### **二、附加属性的核心作用**

1. **扩展元素功能**
   允许控件或布局容器为子元素添加额外的属性。
   **示例**：
   - `Grid.Row`、`Grid.Column`（Grid 布局的行列位置）
   - `Canvas.Left`、`Canvas.Top`（Canvas 布局的绝对坐标）
2. **解耦属性与元素**
   属性定义在服务类中，与目标元素无关。
   **示例**：
   - `ToolTipService.ToolTip`（工具提示服务，可附加到任何控件）
3. **支持数据绑定与动画**
   附加属性是依赖属性，天然支持 WPF 的高级特性。
   **示例**：

```xaml
<Button Canvas.Left="{Binding XPos}" Canvas.Top="{Binding YPos}"/>
```

### **三、附加属性的使用场景**

#### **1. 布局容器**

- **Grid 布局**：

```xaml
<Grid>
    <Button Grid.Row="0" Grid.Column="1" Content="OK"/>
</Grid>
```

- **Canvas 布局**：

```xaml
<Canvas>
    <Ellipse Canvas.Left="50" Canvas.Top="100" Width="50" Height="50"/>
</Canvas>
```

#### **2. 服务类**

- **工具提示服务**：

```xaml
<Button ToolTipService.ToolTip="点击提交" Content="提交"/>
```

- **拖放支持**：

```xaml
<TextBox AllowDrop="True" 
         PreviewDragOver="TextBox_PreviewDragOver"
         PreviewDrop="TextBox_PreviewDrop"/>
```

#### **3. 自定义布局或行为**

- **自定义环形布局**：

```xaml
<local:CirclePanel>
    <Button local:CirclePanel.Angle="45" Content="A"/>
    <Button local:CirclePanel.Angle="90" Content="B"/>
</local:CirclePanel>
```

### **四、附加属性与普通依赖属性的区别**

| **特性**      | **附加属性**                 | **普通依赖属性**     |
| :------------ | :--------------------------- | :------------------- |
| **定义位置**  | 在一个类中定义，供其他类使用 | 在定义它的类中使用   |
| **访问方式**  | 通过静态 `Get`/`Set` 方法    | 通过实例属性直接访问 |
| **典型应用**  | 布局、服务、扩展行为         | 控件自身的状态或外观 |
| **XAML 语法** | `附加类.属性名="值"`         | `属性名="值"`        |

------

### **五、附加属性的优先级与继承**

- **优先级链**：附加属性遵循依赖属性的优先级链（本地值 > 样式 > 继承值等）。
- **值继承**：通过 `FrameworkPropertyMetadata.Inherits` 标志实现跨层级继承。

## 类型转换器

在 WPF 中，依赖属性（Dependency Properties）和附加属性（Attached Properties）的 **类型转换器（Type Converter）** 用于在 XAML 中将字符串值转换为目标类型的对象（或反向操作）。

### **一、类型转换器的作用**

1. **XAML 字符串到对象的转换**
   将 XAML 中的字符串（如 `"Red"`）转换为对应的对象（如 `SolidColorBrush`）。
2. **设计时支持**
   在设计器（如 Visual Studio、Blend）中预览属性值。
3. **简化数据绑定**
   支持通过字符串直接绑定到复杂对象。

### **二、内置类型转换器示例**

WPF 内置了许多常用类型的转换器，例如：

- **颜色**：`"Red"` → `SolidColorBrush`（通过 `ColorConverter`）。
- **几何路径**：`"M0,0 L10,10"` → `PathGeometry`（通过 `GeometryConverter`）。
- **布局值**：`"2*"` → `GridLength`（通过 `GridLengthConverter`）。

### **三、依赖属性与类型转换器**

#### **1. 默认类型转换**

若依赖属性的类型已注册类型转换器，XAML 会自动调用它。例如：

```
// 定义依赖属性（类型为 Point）
public static readonly DependencyProperty PositionProperty = 
    DependencyProperty.Register("Position", typeof(Point), typeof(MyControl));

// XAML 中使用（自动转换字符串）
<local:MyControl Position="10,20"/>
```

- **底层逻辑**：WPF 使用 `PointConverter` 将 `"10,20"` 转换为 `Point` 对象。

#### **2. 显式指定类型转换器**

若类型未注册转换器，需通过 `TypeConverterAttribute` 标记：

```C#
[TypeConverter(typeof(MyCustomConverter))]
public class MyData
{
    public string Value { get; set; }
}

public static readonly DependencyProperty DataProperty = 
    DependencyProperty.Register("Data", typeof(MyData), typeof(MyControl));
```

### **四、附加属性与类型转换器**

附加属性的类型转换逻辑与依赖属性相同：

```
// 定义附加属性
public class MyAttachedProps
{
    public static readonly DependencyProperty TagProperty = 
        DependencyProperty.RegisterAttached("Tag", typeof(MyData), typeof(MyAttachedProps));

    public static MyData GetTag(UIElement obj) => (MyData)obj.GetValue(TagProperty);
    public static void SetTag(UIElement obj, MyData value) => obj.SetValue(TagProperty, value);
}

// XAML 中使用
<Button local:MyAttachedProps.Tag="Special"/>
```

- **转换逻辑**：若 `MyData` 已注册 `TypeConverter`，`"Special"` 会被自动转换。

### **五、自定义类型转换器**

#### **1. 实现步骤**

##### **(1) 创建转换器类**

继承 `TypeConverter`，重写关键方法：

```C#
public class Point3DConverter : TypeConverter
{
    // 支持从字符串转换
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) 
        => sourceType == typeof(string);

    // 转换逻辑
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string str)
        {
            string[] parts = str.Split(',');
            if (parts.Length == 3)
            {
                double x = double.Parse(parts[0], culture);
                double y = double.Parse(parts[1], culture);
                double z = double.Parse(parts[2], culture);
                return new Point3D(x, y, z);
            }
        }
        throw new FormatException("Invalid Point3D format.");
    }

    // 可选：支持转换到字符串（用于序列化）
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
        => destinationType == typeof(string);

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (value is Point3D point)
        {
            return $"{point.X},{point.Y},{point.Z}";
        }
        throw new NotSupportedException();
    }
}
```

##### **(2) 应用转换器**

通过 `TypeConverterAttribute` 标记目标类型：

```C#
[TypeConverter(typeof(Point3DConverter))]
public struct Point3D
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}
```

##### **(3) 在 XAML 中使用**

```xaml
<local:MyControl Position3D="10,20,30"/>
```

### **六、注意事项**

1. **文化敏感性**
   使用 `CultureInfo` 正确处理数字格式（如小数点符号）。
2. **错误处理**
   转换失败时抛出 `FormatException` 或提供默认值。
3. **设计器支持**
   确保转换器在设计时程序集中可用。



# 数据绑定

## 基础概念

#### **1. 数据绑定的核心概念**

数据绑定（Data Binding）是 WPF 中实现 **数据驱动 UI** 的核心机制，通过建立数据源（如对象、集合）与 UI 元素之间的自动同步关系，减少手动更新界面的代码量。

- **绑定方向**：控制数据流动方式（单向、双向等）。
- **绑定路径**：指定数据源中的属性或子属性。
- **数据上下文**：为 UI 元素指定默认数据源（`DataContext`）。

#### **2. 数据绑定的四大要素**

| **要素**     | **描述**                                                     |
| :----------- | :----------------------------------------------------------- |
| **数据源**   | 绑定的数据提供者（如对象、集合、数据库）。                   |
| **目标对象** | 接收数据的 UI 元素（如 `TextBox`、`ListBox`）。              |
| **绑定模式** | 控制数据流向（`OneWay`、`TwoWay`、`OneTime`、`OneWayToSource`）。 |
| **转换器**   | 处理数据在源和目标之间的格式转换（如日期格式化）。           |

------

#### **3. 绑定模式（Binding Mode）**

| **模式**           | **行为**                                                  |
| :----------------- | :-------------------------------------------------------- |
| **OneWay**         | 数据源 → 目标（默认）。适用于只读展示（如标签显示文本）。 |
| **TwoWay**         | 数据源 ↔ 目标。适用于可编辑控件（如 `TextBox`）。         |
| **OneTime**        | 仅初始时同步一次，后续不更新。适用于静态数据。            |
| **OneWayToSource** | 目标 → 数据源（反向绑定）。适用于从 UI 收集数据。         |

------

#### **4. 基础语法与实现**

##### **(1) XAML 绑定**

```xaml
<!-- 绑定到 DataContext 的 Name 属性 -->
<TextBlock Text="{Binding Name}" />

<!-- 显式指定源和路径 -->
<TextBlock Text="{Binding Source={StaticResource user}, Path=Age}" />

<!-- 双向绑定 -->
<TextBox Text="{Binding Title, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
```

##### **(2) 代码绑定**

```C#
Binding binding = new Binding("Price");
binding.Source = product;
binding.Mode = BindingMode.TwoWay;
textBox.SetBinding(TextBox.TextProperty, binding);
```

#### **5. 数据上下文（DataContext）**

- **继承机制**：子元素默认继承父容器的 `DataContext`。
- **显式设置**：

```xaml
<StackPanel DataContext="{Binding UserProfile}">
    <TextBlock Text="{Binding Name}" />  <!-- 绑定到 UserProfile.Name -->
</StackPanel>
```

#### **6. 绑定路径（Path）**

- **属性链**：支持多级属性访问（如 `Address.City`）。
- **集合索引**：绑定到集合的特定项（如 `Items[0].Name`）。
- **特殊符号**：
  - `{Binding}`：绑定整个数据源。
  - `{Binding .}`：绑定当前数据源本身。

#### **7. 高级绑定功能**

##### **(1) 数据模板（DataTemplate）**

为复杂数据类型定义可视化方式：

```xaml
<ListBox ItemsSource="{Binding Employees}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel>
                <TextBlock Text="{Binding Name}" FontWeight="Bold"/>
                <TextBlock Text="{Binding Position}"/>
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

##### **(2) 值转换器（IValueConverter）**

自定义数据格式转换逻辑：

```C#
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

// XAML 中使用
<CheckBox IsChecked="{Binding IsVisible}"/>
<TextBlock Visibility="{Binding IsVisible, Converter={StaticResource CustomerValueConverter}}"/>
```

##### **(3) 数据验证与错误处理**

通过 `ValidationRules` 或 `INotifyDataErrorInfo` 实现输入验证：

```xaml
<TextBox>
    <TextBox.Text>
        <Binding Path="Age">
            <Binding.ValidationRules>
                <local:AgeValidationRule Min="18" Max="100"/>
            </Binding.ValidationRules>
        </Binding>
    </TextBox.Text>
</TextBox>
```

#### **8. 集合绑定**

##### **(1) 绑定到 ObservableCollection**

实现动态集合更新：

```C#
public class ViewModel
{
    public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
}

// XAML 中绑定
<ListBox ItemsSource="{Binding Items}"/>
```

##### **(2) 主从视图（Master-Detail）**

```xaml
<ListBox ItemsSource="{Binding Users}" DisplayMemberPath="Name"
         SelectedItem="{Binding SelectedUser}"/>
<StackPanel DataContext="{Binding SelectedUser}">
    <TextBlock Text="{Binding Age}"/>
    <TextBlock Text="{Binding Email}"/>
</StackPanel>
```

#### **9. 命令绑定（Command Binding）**

将 UI 操作（如按钮点击）绑定到 ViewModel 中的逻辑：

```C#
public class ViewModel
{
    public ICommand SaveCommand => new RelayCommand(Save);

    private void Save()
    {
        // 保存逻辑
    }
}

// XAML 中绑定
<Button Content="保存" Command="{Binding SaveCommand}"/>
```

#### **10. 调试数据绑定**

- **输出窗口查看绑定错误**：WPF 会自动输出绑定失败信息。
- **使用转换器调试**：临时添加转换器输出中间值。
- **工具辅助**：使用第三方工具（如 Snoop、WPF Inspector）实时查看绑定状态。

------

#### **11. 性能优化**

- **虚拟化容器**：对大数据量集合使用 `VirtualizingStackPanel`。
- **延迟绑定**：通过 `IsAsync=True` 延迟加载耗时数据。
- **避免频繁更新**：合理使用 `UpdateSourceTrigger`（如设为 `LostFocus`）。

------

#### **12. 常见问题与解决**

- **绑定未生效**：检查 `DataContext` 是否正确、属性是否实现 `INotifyPropertyChanged`。
- **类型不匹配**：使用转换器处理格式差异。
- **集合更新不刷新**：使用 `ObservableCollection` 替代 `List`。

## 绑定路径

#### ** 绑定表达式的基本结构**

WPF 的绑定表达式通过 `{Binding ...}` 语法在 XAML 中声明，其核心语法如下：

```xaml
<TargetProperty="{Binding 
    Path=PropertyName, 
    Mode=TwoWay, 
    UpdateSourceTrigger=PropertyChanged,
    Converter={StaticResource MyConverter},
    RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window},
    ElementName=SomeElement,
    StringFormat='Value: {0}'
}" />
```

每个参数控制绑定的不同行为。以下是关键属性的详细说明：

------

#### **2. 核心属性解析**

##### **(1) `Path`：绑定路径**

- **作用**：指定数据源中的属性或子属性。
- **示例**：

```xaml
<!-- 绑定到当前 DataContext 的 Name 属性 -->
<TextBlock Text="{Binding Path=Name}"/>

<!-- 绑定到子属性或集合项 -->
<TextBlock Text="{Binding Path=Address.City}"/>
<TextBlock Text="{Binding Path=Items[0].Title}"/>

<!-- 绑定整个对象（用于对象属性绑定） -->
<ContentControl Content="{Binding}"/>
```

##### **(2) `Mode`：绑定模式**

- **可选值**：

  | 模式             | 描述                                                        |
  | :--------------- | :---------------------------------------------------------- |
  | `OneWay`         | 数据源 → 目标（默认），适用于只读展示（如标签）。           |
  | `TwoWay`         | 数据源 ↔ 目标，适用于可编辑控件（如 `TextBox`、`Slider`）。 |
  | `OneTime`        | 仅初始时同步一次，后续不更新（适用于静态数据）。            |
  | `OneWayToSource` | 目标 → 数据源（反向绑定，如从 UI 收集数据）。               |

- **示例**：

```xaml
<TextBox Text="{Binding Path=Age, Mode=TwoWay}"/>
```

##### **(3) `UpdateSourceTrigger`：更新触发时机**

- **可选值**：

  | 触发时机          | 描述                                                     |
  | :---------------- | :------------------------------------------------------- |
  | `PropertyChanged` | 目标属性变化时立即更新源（实时更新，适用于输入验证）。   |
  | `LostFocus`       | 目标失去焦点时更新源（默认行为，适用于大多数输入控件）。 |
  | `Explicit`        | 需手动调用 `UpdateSource()` 更新源。                     |

- **示例**：

```xaml
<TextBox Text="{Binding Path=SearchText, UpdateSourceTrigger=PropertyChanged}"/>
```

##### **(4) `Converter` 与 `ConverterParameter`：值转换器**

- **作用**：在源与目标之间转换数据格式或类型。
- **示例**：

```C#
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isVisible = (bool)value;
        return isVisible ? Visibility.Visible : Visibility.Collapsed;
    }
    // ConvertBack 略...
}
```

```xaml
<Window.Resources>
    <local:BoolToVisibilityConverter x:Key="BoolToVisibility"/>
</Window.Resources>

<CheckBox IsChecked="{Binding IsVisible}"/>
<TextBlock Visibility="{Binding IsVisible, Converter={StaticResource BoolToVisibility}}"/>
```

##### **(5) `StringFormat`：字符串格式化**

- **作用**：将数据格式化为特定字符串（类似 `String.Format`）。
- **示例**：

```xaml
<!-- 格式化数字 -->
<TextBlock Text="{Binding Price, StringFormat=C}"/> <!-- 输出：¥100.00 -->

<!-- 组合文本 -->
<TextBlock Text="{Binding Name, StringFormat='Hello, {0}!'}"/> 

<!-- 格式化日期 -->
<TextBlock Text="{Binding BirthDate, StringFormat=yyyy-MM-dd}"/>
```

##### **(6) `RelativeSource`：相对源绑定**

- **相对源**：基于绑定目标元素自身的位置和层次结构来确定源，而不是依赖于绝对的数据源引用。

- **作用**：绑定到当前元素的关联对象（如父容器、自身）。

- **常见模式**：

  | 模式              | 描述                                     | 示例                                                         |
  | :---------------- | :--------------------------------------- | :----------------------------------------------------------- |
  | `Self`            | 绑定到当前元素自身。                     | `<Slider Value="{Binding RelativeSource={RelativeSource Self}, Path=Maximum}"/>` |
  | `FindAncestor`    | 绑定到某个祖先元素。                     | `<TextBlock Text="{Binding RelativeSource={RelativeSource AncestorType=Window}, Path=Title}"/>` |
  | `TemplatedParent` | 绑定到应用模板的父元素（用于控件模板）。 | `<TextBlock Text="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content}"/>` |

- **示例**：

```xaml
<!-- 绑定到父级 StackPanel 的 Tag -->
<TextBlock Text="{Binding 
    RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=StackPanel}, 
    Path=Tag}"/>
```

##### **(7) `ElementName`：跨元素绑定**

- **作用**：直接绑定到界面中其他命名元素。
- **示例**：

```xaml
<Slider x:Name="slider" Minimum="0" Maximum="100"/>
<TextBlock Text="{Binding ElementName=slider, Path=Value}"/>
```

##### **(8) `FallbackValue` 与 `TargetNullValue`：容错处理**

- **`FallbackValue`**：当绑定路径无效时显示的默认值。
- **`TargetNullValue`**：当绑定源为 `null` 时显示的默认值。
- **示例**：

```xaml
<TextBlock Text="{Binding Path=InvalidProperty, FallbackValue='N/A'}"/>
<TextBlock Text="{Binding Path=NullableProperty, TargetNullValue='No Data'}"/>
```

#### **3. 高级绑定场景**

##### **(1) 多绑定（MultiBinding）**

- **作用**：将多个数据源合并为一个输出。
- **示例**（结合 `IMultiValueConverter`）：

```C#
public class FullNameConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return $"{values[0]} {values[1]}";
    }
    // ConvertBack 略...
}
```

```xaml
<TextBlock>
    <TextBlock.Text>
        <MultiBinding Converter="{StaticResource FullNameConverter}">
            <Binding Path="FirstName"/>
            <Binding Path="LastName"/>
        </MultiBinding>
    </TextBlock.Text>
</TextBlock>
```

##### **(2) 动态资源绑定**

- **作用**：将绑定与动态资源结合。
- **示例**：

```xaml
<TextBlock Text="{Binding Path=Title, Source={StaticResource AppStrings}}"/>
```

##### **(3) 绑定到方法**

- **限制**：WPF 原生不支持直接绑定到方法，但可通过 `ObjectDataProvider` 或转换器间接实现。
- **示例**（通过 `ObjectDataProvider`）：

```xaml
<Window.Resources>
    <ObjectDataProvider x:Key="math" ObjectType="{x:Type sys:Math}" MethodName="Sqrt">
        <ObjectDataProvider.MethodParameters>
            <sys:Double>64</sys:Double>
        </ObjectDataProvider.MethodParameters>
    </ObjectDataProvider>
</Window.Resources>

<TextBlock Text="{Binding Source={StaticResource math}}"/> <!-- 输出：8 -->
```

#### **4. 绑定表达式的最佳实践**

1. **明确数据上下文**：
   合理设置 `DataContext`，避免过度依赖隐式继承。
2. **优先使用 `OneWay` 模式**：
   仅在需要用户输入时使用 `TwoWay`，减少不必要的更新。
3. **优化性能**：
   - 对大数据量集合启用虚拟化（`VirtualizingStackPanel`）。
   - 避免频繁触发的绑定（如 `UpdateSourceTrigger=PropertyChanged` 结合复杂逻辑）。
4. **处理绑定错误**：
   - 使用 `FallbackValue` 和 `TargetNullValue` 提供友好提示。
   - 监控输出窗口的绑定错误日志。
5. **合理使用转换器**：
   将格式化、类型转换等逻辑封装到转换器中，保持 XAML 简洁。

------

#### **5. 调试绑定表达式**

- **查看输出窗口**：WPF 会输出绑定错误信息（如路径错误、类型不匹配）。
- **使用调试转换器**：临时添加转换器输出中间值。
- **工具辅助**：
  - **Snoop**：实时查看元素的数据上下文和绑定值。
  - **WPF Inspector**：检查绑定状态和可视化树。

## 示例代码

### 静态属性绑定

代码：

```xaml
<Window x:Class="WpfStudy02.StaticBindWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:WpfStudy02"
        mc:Ignorable="d"
        Title="StaticBindWin" Height="450" Width="800">
    <Grid>
        <TextBox Text="{Binding Path=(local:StaticClassTest.TestValue1)}" FontSize="20"></TextBox>
        <TextBox Text="{Binding Path=(local:StaticClassTest.TestValue2)}" FontSize="20"></TextBox>
        <TextBox Text="{Binding Path=(local:StaticClassTest.TestValue3)}" FontSize="20"></TextBox>
    </Grid>
</Window>
```

```C#
public partial class StaticBindWin : Window
{
    public StaticBindWin()
    {
        InitializeComponent();
        this.Dispatcher.Invoke(() =>
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(200);
                    StaticClassTest.TestValue2 = new Random().Next(1000).ToString();
                }
            });
        });
    }
}

public class StaticClassTest
{
    
    public static event PropertyChangedEventHandler? StaticPropertyChanged;
    public static event PropertyChangedEventHandler? Test1ValueChanged;
    public static event PropertyChangedEventHandler? TestValueChanged;
    
    private static string _value1 = "1234";
    public static string TestValue1
    {
        get
        {
            return _value1;
        }
        set
        {
            _value1 = value;
            //ui界面能更新值
            Test1ValueChanged?.Invoke(null, new PropertyChangedEventArgs(""));
        }
    }

    private static string _value2 = "555";
    public static string TestValue2
    {
        get
        {
            return _value2;
        }
        set
        {
            _value2 = value;
            //ui界面能更新值
            StaticPropertyChanged?.Invoke(null,new PropertyChangedEventArgs(""));
        }
    }

    private static string _value3 = "555";
    public static string TestValue3
    {
        get
        {
            return _value3;
        }
        set
        {
            _value3 = value;
            //ui界面不能更新值
            TestValueChanged?.Invoke(null,new PropertyChangedEventArgs(""));
        }
    }
}
```

### 属性校验异常捕获

```C#
public partial class TestValidateWin : Window
{
    public TestValidateWin()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    public static readonly DependencyProperty MyContentProperty = DependencyProperty.Register("MyContent", typeof(string),
        typeof(TestValidateWin), new FrameworkPropertyMetadata("null"), OnValidateValueCallback);

    private static bool OnValidateValueCallback(object? value)
    {
        if (value == null)
        {
            return true;
        }

        string str = value as string;
        if (str.Length > 11)
        {
            return false;
        }

        return true;
    }

    public string MyContent
    {
        get => (string)this.GetValue(MyContentProperty);
        set => this.SetValue(MyContentProperty,value);
    }
}
```

```xaml
<Window x:Class="DataBindStudy.TestValidateWin"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:local="clr-namespace:DataBindStudy"
        mc:Ignorable="d"
        Title="TestValidateWin" Height="450" Width="800">
    <StackPanel Orientation="Vertical">
        <Border BorderThickness="2" BorderBrush="Chartreuse">
            <TextBox Name="tb">
                <TextBox.Text>
                    <Binding Path="MyContent" UpdateSourceTrigger="PropertyChanged">
                        <Binding.ValidationRules>
                            <!--用于捕获在绑定值转换或更新过程中抛出的异常-->
                            <ExceptionValidationRule />
                            <!--用于验证实现了 IDataErrorInfo 接口的绑定源对象-->
                            <!-- <DataErrorValidationRule/> -->
                            <!--用于验证实现了 INotifyDataErrorInfo 接口的绑定源对象-->
                            <!-- <NotifyDataErrorValidationRule/>-->
                        </Binding.ValidationRules>
                    </Binding>
                </TextBox.Text>
            </TextBox>
        </Border>
        <Border BorderThickness="2" BorderBrush="Brown">
            <TextBox Text="{Binding Path=(Validation.Errors)[0].ErrorContent, ElementName= tb}"></TextBox>
        </Border>
        <Button Content="Get Error" Click="ButtonBase_OnClick"></Button>
    </StackPanel>
</Window>
```

