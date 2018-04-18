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
        public FieldStatus Status;

        public Field(FieldStatus status, bool isQueenChangingField)
        {
            this.Status = status;
        }

    }
}