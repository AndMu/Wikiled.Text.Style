namespace Wikiled.Text.Style.Description.Data
{
    public class ObscrunityData : INLPDataItem
    {
        public ObscrunityData()
        {
            Top100Words = 0;
            Top500Words = 0;
            Top1000Words = 0;
            Top5000Words = 0;
            Top10000Words = 0;
            Top50000Words = 0;
            Top100000Words = 0;
            Top200000Words = 0;
            Top300000Words = 0;
        }

        public double Top100Words { get; set; }

        public double Top500Words { get; set; }

        public double Top1000Words { get; set; }

        public double Top5000Words { get; set; }

        public double Top10000Words { get; set; }

        public double Top50000Words { get; set; }

        public double Top100000Words { get; set; }

        public double Top200000Words { get; set; }

        public double Top300000Words { get; set; }

        public object Clone()
        {
            return new ObscrunityData
            {
                Top100000Words = Top100000Words,
                Top10000Words = Top10000Words,
                Top1000Words = Top1000Words,
                Top100Words = Top100Words,
                Top200000Words = Top200000Words,
                Top300000Words = Top300000Words,
                Top50000Words = Top50000Words,
                Top5000Words = Top5000Words,
                Top500Words = Top500Words
            };
        }
    }
}
