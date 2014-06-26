using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThudPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < ThudTile.BoardSideLength; ++i)
            {
                gameBoard.ColumnDefinitions.Add(new ColumnDefinition());
                gameBoard.RowDefinitions.Add(new RowDefinition());
            }
            ThudTile.NewBoard(gameBoard);
            ThudTile.SetPlayer(gameBoard, ThudTile.GamePiece.Dwarf);
        }

        void CommandBindingNewGame_Executed(object target, ExecutedRoutedEventArgs e)
        {
            ThudTile.NewBoard(gameBoard);
            ThudTile.SetPlayer(gameBoard, ThudTile.GamePiece.Dwarf);
        }

        void CommandBindingQuit_Executed(object target, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        void PlayerChangedHandler(Object sender, RoutedEventArgs e)
        {
            switch (ThudTile.GetPlayer(gameBoard))
            {
                case ThudTile.GamePiece.Troll: gameBoard.Background = Brushes.Navy; break;
                case ThudTile.GamePiece.Dwarf: gameBoard.Background = Brushes.Maroon; break;
                default: gameBoard.Background = Brushes.Black; break;
            }
        }
    }
}
