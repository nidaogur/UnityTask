namespace _Game_.Scripts
{
    public class NumberFormatter
    {
        public static string FormatNumber(int number)
        {
            return number switch
            {
                >= 1000 and < 1000000 => (number / 1000f).ToString("0.##") + "K",
                >= 1000000 => (number / 1000000f).ToString("0.##") + "M",
                _ => number.ToString()
            };
        }
    }
}