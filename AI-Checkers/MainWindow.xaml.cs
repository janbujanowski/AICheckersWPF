using AI_Checkers.AI;
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
        Move currentMove;
        IAI AI;
        public MainWindow()
        {
            InitializeComponent();
            this.game = new Game();
            this.DataContext = game;
            this.AI = new AIRandom();
            InitBoardUI();
        }

        private void InitBoardUI()
        {
            for (int i = 0; i < game.Board.Length; i++)
            {
                for (int j = 0; j < game.Board.Length; j++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if ((i + j) % 2 == 0)
                    {
                        stackPanel.Background = (SolidColorBrush)(Application.Current.Resources["WhiteField"]); 
                    }
                    else
                    {
                        stackPanel.Background = (SolidColorBrush)(Application.Current.Resources["BlackField"]);
                    }
                    Grid.SetColumn(stackPanel, i);
                    Grid.SetRow(stackPanel, j);
                    BoardHolder.Children.Add(stackPanel);

                    Button butt = new Button
                    {
                        Style = (Style)Application.Current.Resources["RoundCorner"]
                    };
                    butt.Click += clicker_Click;

                    Binding buttBind = new Binding
                    {
                        Source = this.game,
                        Path = new PropertyPath($"Board[{i}][{j}].CheckerColor"),
                        Mode = BindingMode.OneWay
                    };

                    Grid.SetColumn(butt, i);
                    Grid.SetRow(butt, j);
                    BindingOperations.SetBinding(butt, Button.BackgroundProperty, buttBind);
                    BoardHolder.Children.Add(butt);
                }
            }
        }

        private void clicker_Click(object sender, RoutedEventArgs e)
        {

            var butt = (Button)sender;
            var col = Grid.GetColumn(butt);
            var row = Grid.GetRow(butt);
            if (currentMove == null)
            {
                currentMove = new Move(col, row, -1, -1);
            }
            else if (currentMove.X_Start == col && currentMove.Y_Start == row)
            {
                //do nothing - start/end position are the same
            }
            else
            {
                currentMove = new Move(currentMove.X_Start, currentMove.Y_Start, col, row);
                try
                {
                    game.MakeMove(currentMove);
                    //Move AIMove = AI.GetNextMove(game.Board);
                    //game.MakeMove(AIMove);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Internal game problem : " + ex.Message);
                }
                finally
                {
                    currentMove = null;
                }
            }
            
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
