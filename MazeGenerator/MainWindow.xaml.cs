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

        int[,] FreePoint = new int[2, 77];      //Массив свободных клеток
        int[] FreePointID = new int[77 / 2 ];   //Номер свободных клеток

        int[,] AvailablePoint = new int[2, 77];     //Массив доступных свободных клеток
        int[] AvaillblePointId = new int[77 / 2];   //Номер доступных клеток

        int[][] Dvizh = {
            new int[] { +scale, 0 },
            new int[] { -scale, 0 },
            new int[] { 0, +scale },
            new int[] { 0, -scale }
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

                        FreePoint[0, i] = i * scale; //Записывает Х точку соеденения 
                        FreePoint[1, j] = j * scale; //Записывает Y точку соеденения 
                    }
                }
            }   //Распологает на поле точки соединения лабиринта

            for (int i = 0; i < MapX / scale; i++)
            {
                for (int j = 0; j < MapY / scale; j++)
                {
                    AvailablePoint[0, i] = i * scale;
                    AvailablePoint[1, j] = j * scale;
                }
            }

            for (int i = 0; i < (MapX / scale) / 2; i++)
            {
                FreePointID[i] = buf;
                buf += 2;
            } //Добаваляет ID свободным клеткам


            for (int i = 0; i < (MapX / scale) / 2; i++)
            {
                AvaillblePointId[i] = buf;
                buf += 2;
            } //Добаваляет ID свободным клеткам
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainCanvas.Children.Clear();

            //MazeGenerate();

            ConnectingPointX = (MapX/ scale) / 2;
            ConnectingPointY = (MapY/ scale) / 2;           

            for (int i = 0; i < 10; i++)
            {
                //StartPointX = FreePoint[0, FreePointID[random.Next(0, 7)]]; //Рандомит появление стартовой точки
                //StartPointY = FreePoint[1, FreePointID[random.Next(0, 7)]]; //Рандомит появление стартовой точки

                DvizhBuf = random.Next(0, 4); //Записывает случайное действие из массива

                //Rectangle rectangle2 = CreateRectangel(new Point(StartPointX, StartPointY), Brushes.Red); //Отрисовываем стартовую точку
                //MainCanvas.Children.Add(rectangle2);*/

                Found:

                BufX = FreePoint[0, FreePointID[random.Next(0, ConnectingPointX)]];
                BufY = FreePoint[1, FreePointID[random.Next(0, ConnectingPointY)]];

                if(BufX*10 == FreePoint[0, BufX / scale] && BufY*10 == FreePoint[1, BufY / scale])
                {
                    goto Found;
                }

                else
                {
                    Rectangle rectangle = CreateRectangel(new Point(BufX, BufY), Brushes.Bisque);
                    MainCanvas.Children.Add(rectangle);

                    Rectangle rectangle1 = CreateRectangel(new Point(BufX + Dvizh[DvizhBuf][0], BufY + Dvizh[DvizhBuf][1]), Brushes.Bisque);
                    MainCanvas.Children.Add(rectangle1);

                    Rectangle rectangle2 = CreateRectangel(new Point(BufX + Dvizh[DvizhBuf][0] * 2, BufY + Dvizh[DvizhBuf][1] * 2), Brushes.Bisque);
                    MainCanvas.Children.Add(rectangle2);
                }                

                FreePoint[0, BufX/ scale] = 0;
                FreePoint[1, BufY/ scale] = 0;
            }

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
