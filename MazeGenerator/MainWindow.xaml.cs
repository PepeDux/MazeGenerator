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
        Random random = new Random();

        const int scale = 10;

        int MapX = 15 * scale;
        int MapY = 15 * scale;

        int[,] FreePoint = new int[770, 770];

        public MainWindow()
        {
            InitializeComponent();

         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MapX; i = i + scale) 
            {
                for (int j = 0; j < MapY; j = j + scale) 
                {
                    Rectangle rectangle = CreateRectangel(new Point(i, j), Brushes.DarkGreen);
                    MainCanvas.Children.Add(rectangle);                 
                }
            }

            for (int i = 0; i < MapX / scale; i++) 
            {
                for (int j = 0; j < MapY / scale; j++)                    
                {
                    if (i % 2 == 1 && j % 2 == 1)
                    {
                        Rectangle rectangle1 = CreateRectangel(new Point(scale * i, scale * j), Brushes.Bisque);
                        MainCanvas.Children.Add(rectangle1);

                        //FreePoint[i * scale, j * scale] = i * scale;
                        //FreePoint[j * scale, i * scale] = j * scale;
                    }                   
                }
            }

            //Rectangle rectangle2 = CreateRectangel(new Point(FreePoint[150, 10], FreePoint[10, 150]), Brushes.Blue);
            //MainCanvas.Children.Add(rectangle2);





            /* for (int i = 0; i < MapX + scale; i = i + scale)
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
             }//Правая стенка*/
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

            Rectangle rectangle1 = new Rectangle();
            rectangle1.Width = scale;
            rectangle1.Height = scale;
            rectangle1.Fill = brush;
            Canvas.SetLeft(rectangle1, point.X);
            Canvas.SetTop(rectangle1, point.Y);

            return rectangle1;

            Rectangle rectangle2 = new Rectangle();
            rectangle2.Width = scale;
            rectangle2.Height = scale;
            rectangle2.Fill = brush;
            Canvas.SetLeft(rectangle2, point.X);
            Canvas.SetTop(rectangle2, point.Y);

            return rectangle2;
        }   
    }
}
