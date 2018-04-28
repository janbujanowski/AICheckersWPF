﻿using System;
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
                    StackPanel stackPanel = new StackPanel();
                    if ((i + j) % 2 == 0)
                    {
                        stackPanel.Background = (SolidColorBrush)(Application.Current.Resources["WhiteField"]); 
                    }
                    else
                    {
                        stackPanel.Background = (SolidColorBrush)(Application.Current.Resources["BlackField"]);
                    }

                    Button butt = new Button();
                    butt.Click += clicker_Click;
                    butt.Background = Brushes.Transparent;

                    Binding binding = new Binding();
                    binding.Source = this.game;
                    binding.Path = new PropertyPath($"Board[{i}][{j}].Status");
                    binding.Mode = BindingMode.OneWay;
                    binding.Converter = new EnumToStringConverter();

                    TextBlock textBlock = new TextBlock();
                    BindingOperations.SetBinding(textBlock, TextBlock.TextProperty, binding);

                    Grid.SetColumn(stackPanel, i);
                    Grid.SetRow(stackPanel, j);
                    Grid.SetColumn(butt, i);
                    Grid.SetRow(butt, j);
                    
                    stackPanel.Children.Add(textBlock);
                    BoardHolder.Children.Add(stackPanel);
                    BoardHolder.Children.Add(butt);
                }
            }
        }

        private void clicker_Click(object sender, RoutedEventArgs e)
        {

            var butt = (Button)sender;
            var col = Grid.GetColumn(butt);
            var row = Grid.GetRow(butt);
            game.board[row][col].Status = FieldStatus.Player1Queen;
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
