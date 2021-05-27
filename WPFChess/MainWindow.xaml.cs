using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFChess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[,] buttons = new Button[8, 8];
        public MainWindow()
        {
            InitializeComponent();

            chessBoard.Rows = 8;
            chessBoard.Columns = 8;



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Click += Button_Click;
                    chessBoard.Children.Add(buttons[i, j]);
                    if ((i+j)%2 == 0)
                    {
                        buttons[i, j].Background = Brushes.Black;
                    }
                    else
                        buttons[i, j].Background = Brushes.Red;
                }
            }
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("qqq");
        }
    }
}
