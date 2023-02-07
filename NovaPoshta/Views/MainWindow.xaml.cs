using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NovaPoshta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Color BackColorRed1 = (Color)ColorConverter.ConvertFromString("#67100B");
        public Color BackColorRed2 = (Color)ColorConverter.ConvertFromString("#FF392E");
        public MainWindow()
        {
            LinearGradientBrush myGradientBrush = new LinearGradientBrush();
            myGradientBrush.StartPoint = new Point(0.5, 0);
            myGradientBrush.EndPoint = new Point(0.5, 4);
            myGradientBrush.GradientStops.Add(new GradientStop(BackColorRed1, 0));
            myGradientBrush.GradientStops.Add(new GradientStop(BackColorRed2, 0.80));
            this.Background = myGradientBrush;
            InitializeComponent();
        }
    }
}
