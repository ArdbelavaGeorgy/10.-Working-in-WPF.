using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MinecraftHeightMap
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateHeightMap();
        }

        private void GenerateHeightMap()
        {
            int width = 500; // Ширина карты
            int height = 500; // Высота карты
            var random = new Random();
            var heightMap = new int[width, height];

            // Генерация высот
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMap[x, y] = random.Next(30);
                }
            }

            // Визуализация карты высот
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var rect = new Rectangle
                    {
                        Width = 20,
                        Height = 20,
                        Fill = new SolidColorBrush(Color.FromArgb(125, (byte)(heightMap[x, y] * 15), (byte)(125 - heightMap[x, y] * 15), 0))
                    };
                    Canvas.SetLeft(rect, x * 20);
                    Canvas.SetTop(rect, y * 20);
                    MainCanvas.Children.Add(rect);
                }
            }
        }
    }
}
