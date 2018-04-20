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
        public string Name;

        public event PropertyChangedEventHandler PropertyChanged;
        Person person = new Person { Name = "Salman", Age = 26 };
        public MainWindow()
        {

            this.Name = "lol";
            InitializeComponent();
            game = new Game();
            this.DataContext = game;
            //NotifyPropertyChanged("Name");
            //TestText.DataContext = game;
            this.game = new Game();
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class Person
        {

            private string nameValue;

            public string Name
            {
                get { return nameValue; }
                set { nameValue = value; }
            }

            private double ageValue;

            public double Age
            {
                get { return ageValue; }

                set
                {
                    if (value != ageValue)
                    {
                        ageValue = value;
                    }
                }
            }

        }
    }
}
