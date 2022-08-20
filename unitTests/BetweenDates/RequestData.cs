namespace unitTests.BetweenDates
{
    public class RequestData
    {
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? dateFormat { get; set; }

        public RequestData(string startDate, string endDate, string dateFormat)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.dateFormat = dateFormat;
        }
    }
}