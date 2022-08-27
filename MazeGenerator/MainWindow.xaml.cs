using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


        int buf = 1;

        int MapX = 15 * scale; //Ширина лабиринат
        int MapY = 15 * scale; //Высота лабиринта

        int ConnectingPointX; //Колличество точек соединения по Х
        int ConnectingPointY; //Колличество точек соединения по Y

        int BufX = 0;
        int BufY = 0;

        int StartPointX = 0; // Стартовая позиция начал лабиринта
        int StartPointY = 0; // Стартовая позиция начал лабиринта

        int[,] Point = new int[1444, 1444];

        int[][] Dvizh = {
            new int[] { +1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, +1 },
            new int[] { 0, -1 }
        };  //Массив для выполнения движения действий в одном из анправлений

        int DvizhBuf;   //Просто буфер

        public MainWindow()
        {
            InitializeComponent();



        }

        public void MazeGenerate()
        {
            for (int i = 0; i < MapX; i = i + scale)
            {
                for (int j = 0; j < MapY; j = j + scale)
                {
                    Rectangle rectangle = CreateRectangel(new Point(i, j), Brushes.DarkGreen);
                    MainCanvas.Children.Add(rectangle);
                }
            } //Рисует квадрат заданных размеров

            for (int i = 0; i < MapX / scale; i++)
            {
                for (int j = 0; j < MapY / scale; j++)
                {
                    if (i % 2 == 1 && j % 2 == 1)
                    {
                        Rectangle rectangle1 = CreateRectangel(new Point(scale * i, scale * j), Brushes.Bisque);
                        MainCanvas.Children.Add(rectangle1);

                        
                    }
                }
            }   //Распологает на поле точки соединения лабиринта

            for (int i = 1; i < MapX; i += 2) 
            {
                for (int j = 1; j < MapY; j += 2) 
                {
                    Point[i, j] = 1;
                }
            }   //Распологает на поле точки соединения лабиринта

            StartPointX = 5;
            StartPointY = 5;

            Point[StartPointX, StartPointY] = 3;

            Rectangle rectangle2 = CreateRectangel(new Point(StartPointX * scale, StartPointY * scale), Brushes.RosyBrown);
            MainCanvas.Children.Add(rectangle2);

            for (int j = 0; j < 4; j++)
            {
                if (StartPointX + (Dvizh[j][0] * 2) <= 0 || StartPointY + (Dvizh[j][1] * 2) <= 0)
                {

                }

                else
                {
                    Point[StartPointX + (Dvizh[j][0] * 2), StartPointY + (Dvizh[j][1] * 2)] = 2;                  
                }
            }

        }
        public void MazeFrame()
        {
            for (int i = 0; i < MapX - scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(i, 0), Brushes.DarkGreen);
                MainCanvas.Children.Add(rectangle);
            }//Верхняя стенка

            for (int i = 0; i < MapX + scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(i, MapY - scale), Brushes.DarkGreen);
                MainCanvas.Children.Add(rectangle);
            }//Нижняя стенка

            for (int i = 0; i < MapX + scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(i, MapY), Brushes.White);
                MainCanvas.Children.Add(rectangle);
            }//Нижняя белая стенка

            for (int i = 0; i < MapY - scale; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(0, i), Brushes.DarkGreen);
                MainCanvas.Children.Add(rectangle);
            }//Левая строчка            

            for (int i = 0; i < MapY; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(MapX - scale, i), Brushes.DarkGreen);
                MainCanvas.Children.Add(rectangle);
            }//Правая стенка

            for (int i = 0; i < MapY; i = i + scale)
            {
                Rectangle rectangle = CreateRectangel(new Point(MapX, i), Brushes.White);
                MainCanvas.Children.Add(rectangle);
            }//Правая белая стенка
        }       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MazeGenerate();
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

            Rectangle rectangle3 = new Rectangle();
            rectangle3.Width = scale;
            rectangle3.Height = scale;
            rectangle3.Fill = brush;
            Canvas.SetLeft(rectangle2, point.X);
            Canvas.SetTop(rectangle2, point.Y);

            return rectangle3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            
            for (int i = 0; i < 100; i++)
            {
                BufX = random.Next(1, MapX / scale);
                BufY = random.Next(1, MapY / scale);

                if (Point[BufX, BufY] == 2)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (BufX + (Dvizh[j][0] * 2) <= 0 || BufY + (Dvizh[j][1] * 2) <= 0)
                        {

                        }

                        else
                        {
                            if (Point[BufX + (Dvizh[j][0] * 2), BufY + (Dvizh[j][1] * 2)] == 2 || Point[BufX + (Dvizh[j][0] * 2), BufY + (Dvizh[j][1] * 2)] == 1)
                            {
                                Point[BufX + (Dvizh[j][0] * 2), BufY + (Dvizh[j][1] * 2)] = 2;

                                Rectangle rectangle2 = CreateRectangel(new Point((BufX + Dvizh[j][0] * 2) * scale, (BufY + Dvizh[j][1] * 2) * scale), Brushes.RosyBrown);
                                MainCanvas.Children.Add(rectangle2);
                            }

                            if (Point[BufX + (Dvizh[j][0] * 2), BufY + (Dvizh[j][1] * 2)] == 3)
                            {
                                Point[BufX + (Dvizh[j][0] * 2), BufY + (Dvizh[j][1] * 2)] = 3;

                                Rectangle rectangle2 = CreateRectangel(new Point((BufX + Dvizh[j][0] * 2) * scale, (BufY + Dvizh[j][1] * 2) * scale), Brushes.RosyBrown);
                                MainCanvas.Children.Add(rectangle2);

                                Rectangle rectangle3 = CreateRectangel(new Point((BufX + Dvizh[j][0]) * scale, (BufY + Dvizh[j][1]) * scale), Brushes.RosyBrown);
                                MainCanvas.Children.Add(rectangle3);

                            }
                        }

                        
                    }
                }

                if (Point[BufX, BufY] == 2)
                {

                }
            }





            /*for (int i = 0; i < 10; i++)
            {
                DvizhBuf = random.Next(0, 4); //Записывает случайное действие из массива

                Rectangle rectangle = CreateRectangel(new Point(BufX, BufY), Brushes.RosyBrown);
                MainCanvas.Children.Add(rectangle);

                Rectangle rectangle1 = CreateRectangel(new Point(BufX + Dvizh[DvizhBuf][0], BufY + Dvizh[DvizhBuf][1]), Brushes.RosyBrown);
                MainCanvas.Children.Add(rectangle1);

                Rectangle rectangle2 = CreateRectangel(new Point(BufX + Dvizh[DvizhBuf][0] * 2, BufY + Dvizh[DvizhBuf][1] * 2), Brushes.RosyBrown);
                MainCanvas.Children.Add(rectangle2);
            }*/

            MazeFrame();


            /*if(FreePoint[0, StartPointX + Dvizh[i][0
                ]] == StartPointX + Dvizh[i][0] * 2 && FreePoint[1, StartPointX + Dvizh[i][1]] == StartPointX + Dvizh[i][1] * 2)
            {
                 AvailablePoint[0, StartPointX + Dvizh[i][0]] = 0;
                 AvailablePoint[1, StartPointX + Dvizh[i][1]] = 0;
                 FreePoint[0, StartPointX + Dvizh[i][0]] = 0;
                 FreePoint[1, StartPointX + Dvizh[i][1]] = 0;
            }
             Rectangle rectangle = CreateRectangel(new Point(StartPointX + Dvizh[i][0]*2, StartPointY + Dvizh[i][1]*2), Brushes.Blue);
             MainCanvas.Children.Add(rectangle);*/



        }
    }
}