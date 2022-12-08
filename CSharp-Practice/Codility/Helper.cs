namespace CSharp_Practice.Codility
{
    public static class Helper
    {
        public static char GetLabel(int i)
        {
            return "ABCDEFGHJK"[i];
        }
        public static int GetSeatNumber(char label)
        {
            return "ABCDEFGHJK".IndexOf(label);
        }
        public static Seat GetSeat(string s)
        {
            char label = s.Last();
            int rowNumber = int.Parse(s.Remove(s.Length - 1));
            return new Seat(rowNumber, label);
        }
    }
}
