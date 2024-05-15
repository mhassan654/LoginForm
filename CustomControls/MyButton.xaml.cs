using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoginForm.CustomControls
{
    public partial class MyButton : UserControl
    {
        public MyButton()
        {
            InitializeComponent();
        }
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MyButton));
        
        public FontAwesome.Sharp.IconChar Icon
        {
            get => (FontAwesome.Sharp.IconChar)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(MyButton));
        
        public Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(MyButton));
    }
}