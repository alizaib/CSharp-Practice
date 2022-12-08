using System.Text;

namespace CSharp_Practice.Codility
{
    public class Hall
    {
        private readonly List<Row> _rows = new List<Row>();
        public Hall(int rows, int rowSize)
        {
            for (int i = 1; i <= rows; i++)
            {
                _rows.Add(new Row(i, rowSize));
            }
        }

        public List<Row> Rows { get { return _rows; } }

        public void ReserveSeat(int rowNumber, char label)
        {
            var row = _rows[rowNumber - 1];
            var seat = row.Seats.First(x => x.Label == label);
            seat.Reserve();

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in _rows)
            {
                sb.Append(row.ToString());
                sb.AppendLine();
            }
            var result = sb.ToString();
            return result;
        }
    }
}
