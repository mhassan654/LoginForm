using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LoginForm.CustomControls
{
    /// <summary>
    /// Interaction logic for InfoCard.xaml
    /// </summary>
    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        // title property for the dashboard card
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));
        
        // number property for the dashboard card
        public string Number
        {
            get => (string)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(InfoCard));
        
        public FontAwesome.Sharp.IconChar Icon
        {
            get => (FontAwesome.Sharp.IconChar)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(InfoCard));
        
        public Color Background1
        {
            get => (Color)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background1", typeof(Color), typeof(InfoCard));
        
        public Color Background2
        {
            get => (Color)GetValue(BackgroundProperty2);
            set => SetValue(BackgroundProperty2, value);
        }

        public static readonly DependencyProperty BackgroundProperty2 =
            DependencyProperty.Register("Background2", typeof(Color), typeof(InfoCard));
        
        public Color EllipseBackground1
        {
            get => (Color)GetValue(EllipseBackgroundProperty1);
            set => SetValue(EllipseBackgroundProperty1, value);
        }

        public static readonly DependencyProperty EllipseBackgroundProperty1 =
            DependencyProperty.Register("EllipseBackground1", typeof(Color), typeof(InfoCard));
        
        public Color EllipseBackground2
        {
            get => (Color)GetValue(EllipseBackgroundProperty2);
            set => SetValue(EllipseBackgroundProperty2, value);
        }

        public static readonly DependencyProperty EllipseBackgroundProperty2 =
            DependencyProperty.Register("EllipseBackground2", typeof(Color), typeof(InfoCard));
    }
}
