namespace CSharp_Practice.Codility
{
    public class Seat
    {
        private readonly int _rowNumber;
        private readonly char _label;
        private bool _isReserved;


        public Seat(int rowNumber, char Label)
        {
            _rowNumber = rowNumber;
            _label = Label;
            _isReserved = false;
        }

        public int RowNumber { get { return _rowNumber; } }
        public char Label { get { return _label; } }

        public bool IsReserved { get { return _isReserved; } }

        public void Reserve()
        {
            _isReserved = true;
        }

        public override string ToString()
        {            
            var seatinfo = RowNumber + "" + Label;
            if (_isReserved)
            {
                return "[" + seatinfo + "]";
            }
            else
            {
                return " " + seatinfo + " ";
            }
        }
    }
}
