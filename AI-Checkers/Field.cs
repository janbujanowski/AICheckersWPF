using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace AI_Checkers
{
    public enum FieldStatus
    {
        Empty,
        Player1,
        Player2,
        Player1Queen,
        Player2Queen
    }

    public class Field : INotifyPropertyChanged
    {
        public FieldStatus status;
        private readonly bool isQueenField;

        private Checker check;

        public Checker Check
        {
            get { return check; }
            set
            {
                check = value;
                NotifyPropertyChanged("CheckerColor");
            }
        }

        public bool IsQueenField
        {
            get { return isQueenField; }
        }

        public Brush CheckerColor
        {
            get
            {
                if (check != null)
                {
                    return check.Color;
                }
                else
                {
                    return Brushes.Transparent;
                }

            }
        }

        public Field()
        {
            this.status = FieldStatus.Empty;
            this.isQueenField = false;
        }

        public Field(FieldStatus status, bool isQueenChangingField)
        {
            this.status = status;
            this.isQueenField = isQueenChangingField;
        }
        public Field(Checker check, bool isQueenChangingField)
        {
            this.check = check;
            this.isQueenField = isQueenChangingField;
        }
        public FieldStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
                NotifyPropertyChanged("CheckerColor");
            }
        }

        //public Brush CheckerColor
        //{
        //    get
        //    {
        //        switch (status)
        //        {
        //            case FieldStatus.Empty:
        //                return Brushes.Transparent;
        //            case FieldStatus.Player1:
        //                return Brushes.Pink;
        //            case FieldStatus.Player2:
        //                return Brushes.Black;
        //            case FieldStatus.Player1Queen:
        //                return Brushes.Pink;
        //            case FieldStatus.Player2Queen:
        //                return Brushes.Black;
        //            default:
        //                return Brushes.Transparent;
        //        }
        //    }
        //}

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