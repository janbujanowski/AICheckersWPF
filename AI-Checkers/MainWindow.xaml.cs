using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace AI_Checkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            this.game = new Game();
            this.DataContext = game;
            InitBoardUI();
        }

        private void InitBoardUI()
        {
            for (int i = 0; i < game.board.Length; i++)
            {
                for (int j = 0; j < game.board.Length; j++)
                {
                    StackPanel sp = new StackPanel();
                    if ((i + j) % 2 == 0)
                    {
                        sp.Background = (SolidColorBrush)(Application.Current.Resources["WhiteField"]); 
                    }
                    else
                    {
                        sp.Background = (SolidColorBrush)(Application.Current.Resources["BlackField"]);
                    }
                    TextBlock tb = new TextBlock();
                    Binding nb = new Binding();
                    nb.Source = this.game;
                    nb.Path = new PropertyPath($"Board[{i}][{j}].Status");
                    nb.Mode = BindingMode.OneWay;
                    nb.Converter = new EnumToStringConverter();
                    Grid.SetColumn(tb, i);
                    Grid.SetRow(tb, j);
                    Grid.SetColumn(sp, i);
                    Grid.SetRow(sp, j);
                    BindingOperations.SetBinding(tb, TextBlock.TextProperty, nb);
                    sp.Children.Add(tb);
                    BoardHolder.Children.Add(sp);
                }
            }
        }

        private void clicker_Click(object sender, RoutedEventArgs e)
        {
            game.Board[0][0].Status = FieldStatus.Player1Queen;
            game.Name = "test";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
