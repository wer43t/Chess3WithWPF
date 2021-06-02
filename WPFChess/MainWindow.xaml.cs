using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FigureCore;

namespace WPFChess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[,] buttons = new Button[8, 8];
        private Figure figure;
        private bool pieceInBoard = false;
        private object prevSender;

        public MainWindow()
        {
            InitializeComponent();

            lbData.ItemsSource = FigureFab.InitFiguresData();
            chessBoard.Rows = 8;
            chessBoard.Columns = 8;



            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Click += Button_Click;
                    buttons[i, j].Name = $"Ya{i + 1}aXa{j + 1}";
                    chessBoard.Children.Add(buttons[i, j]);
                    if ((i+j)%2 == 0)
                    {
                        buttons[i, j].Background = Brushes.White;
                    }
                    else
                        buttons[i, j].Background = Brushes.Bisque;
                }
            }
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbData.SelectedItem != null)
            {
                if (!pieceInBoard)
                {
                    SetPieceOnBoard(sender);
                }
                else
                {
                    MovePieceOnBoard(sender);
                }
            }
            else
            {
                MessageBox.Show("Not selected fig");
            }
        }

        private void MovePieceOnBoard(object sender)
        {
            string[] tempXY = GetKeyAndValue(sender);
            if (figure.CanMove(Convert.ToInt32(tempXY[3]), Convert.ToInt32(tempXY[1])))
            {
                figure.X1 = Convert.ToInt32(tempXY[3]);
                figure.Y1 = Convert.ToInt32(tempXY[1]);
                Clear();
                sender.GetType().GetProperty("Content").SetValue(sender, GetFigImage((lbData.SelectedItem as FiguresData).imgURI));
                prevSender = sender;
                pieceInBoard = false;
            }
            else
            {
                MessageBox.Show("Can't move there, try again");
            }
        }

        private void SetPieceOnBoard(object sender)
        {
            Clear();
            ChangeFigData(GetKeyAndValue(sender));
            figure = FigureFab.Make(lbData.SelectedItem as FiguresData);
            sender.GetType().GetProperty("Content").SetValue(sender, GetFigImage((lbData.SelectedItem as FiguresData).imgURI));
            pieceInBoard = true;
            prevSender = sender;
        }



        private void Clear()
        {
            if (prevSender != null)
            {
                prevSender.GetType().GetProperty("Content").SetValue(prevSender, null);
                pieceInBoard = false;
            }
        }

        private StackPanel GetFigImage(Uri imgs)
        {
            Image img = new Image();
            img.Source = new BitmapImage(imgs);

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(10);
            stackPnl.Children.Add(img);
            return stackPnl;
        }

        private string[] GetKeyAndValue(object sender)
        {
            return sender.GetType().GetProperty("Name").GetValue(sender).ToString().Split('a');
        }

        private void ChangeFigData(string[] keysAndVals)
        {
            var fig = lbData.SelectedItem as FiguresData;
            for (int i = 0; i < 4; i +=2)
            {
                var key = keysAndVals[i];
                var val = keysAndVals[i + 1];
                try
                {
                    fig.Data[key] = int.Parse(val);
                }
                catch { }
            }
        }

        private void Clear_Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clear();
        }
    }
}
