namespace unitTests.BetweenDates
{
    public class RequestData
    {
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? format { get; set; }

        public RequestData(string startDate, string endDate, string format)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.format = format;
        }
    }
}