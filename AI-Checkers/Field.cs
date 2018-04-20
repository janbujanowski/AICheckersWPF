using System;
using System.ComponentModel;

namespace AI_Checkers
{
    public enum FieldStatus
    {
        Empty,
        Red,
        Black,
        RedQueen,
        BlackQueen
    }

    public class Field
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
            this.status = FieldStatus.Red;
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
        }
    }
}