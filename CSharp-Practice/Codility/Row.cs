using System.Text;

namespace CSharp_Practice.Codility
{
    public class Row
    {
        public int[] Aisle = new int[2] { 3, 7 };

        private readonly List<Seat> _seats = new List<Seat>();

        public Row(int rowNumber, int rowSize)
        {
            RowNumber = rowNumber;
            RowSize = rowSize;
            InitializeSeats();
        }

        private void InitializeSeats()
        {
            for (int i = 0; i < RowSize; i++)
            {
                char label = Helper.GetLabel(i);
                _seats.Add(new Seat(RowNumber, label));
            }
        }

        public int RowNumber { get; private set; }
        public int RowSize { get; private set; }
        public List<Seat> Seats { get; private set; }

        public int GetConsectiveSeats()
        {
            var results = new List<int>();
            for (var i = 0; i < RowSize - 4; i++)
            {
                var seats = _seats.Skip(i).ToList();
                var result = GetConsectiveAvailabilityOfSeats(seats);
                results.Add(result);
            }
            return results.Count() > 1 ? results.Max() : results.FirstOrDefault();
        }

        private int GetConsectiveAvailabilityOfSeats(List<Seat> seats)
        {
            int totalAvailablespaceForFamily = 0;
            int numConsectiveEmptySeats = 0;

            foreach (var seat in seats)
            {
                int seatIndex = _seats.IndexOf(seat);

                if (seat.IsReserved)
                {
                    numConsectiveEmptySeats = 0;
                    continue;
                }
                else if (Aisle.Contains(seatIndex) && numConsectiveEmptySeats != 2)
                {
                    numConsectiveEmptySeats = 0;
                }

                numConsectiveEmptySeats++;

                if (numConsectiveEmptySeats == 4)
                {
                    numConsectiveEmptySeats = 0;
                    totalAvailablespaceForFamily++;
                }

            }

            return totalAvailablespaceForFamily;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var seat in _seats)
            {
                sb.Append(seat.ToString());
                sb.Append("  ");
            }
            var result = sb.ToString();
            return result;
        }
    }
}
