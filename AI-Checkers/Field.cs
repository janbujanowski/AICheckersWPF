using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private bool isQueenField;
        

        public bool IsQueenField
        {
            get { return isQueenField; }
            set { isQueenField = value; }
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

        public FieldStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
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