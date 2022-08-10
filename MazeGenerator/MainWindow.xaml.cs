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

namespace MazeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int scale = 10;

        int MapX = 10 * scale;
        int MapY = 10 * scale;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            for (int i = 0; i < MapX + scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(i + scale, 0), Brushes.Green);
                MainCanvas.Children.Add(rectangle);
            }//Верхняя стенка

            for (int i = 0; i < MapX + scale * 2; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(i, MapY + scale), Brushes.Green);
                MainCanvas.Children.Add(rectangle);
            }//Нижняя стенка

            for (int i = 0; i < MapY + scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(0, i), Brushes.Green);
                MainCanvas.Children.Add(rectangle);
            }//Левая строчка            

            for (int i = 0; i < MapY + scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(MapX + scale, i), Brushes.Green);
                MainCanvas.Children.Add(rectangle);
            }//Правая стенка
        }

        private Rectangle CreateRectangel(Point point, Brush brush)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = scale;
            rectangle.Height = scale;
            rectangle.Fill = brush;
            Canvas.SetLeft(rectangle, point.X);
            Canvas.SetTop(rectangle, point.Y);

            return rectangle;
        }   
    }
}
