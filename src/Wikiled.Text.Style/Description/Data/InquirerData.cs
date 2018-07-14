namespace Wikiled.Text.Style.Description.Data
{
    public class InquirerData : INLPDataItem
    {
        public object Clone()
        {
            return new InquirerData
            {
                Categories = Categories
            };
        }

        public string[] Categories { get; set; }
    }
}
