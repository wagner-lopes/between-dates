using unitTests.BetweenDates;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async void SendEmptyData()
    {
        RequestData data = new RequestData("", "", "");
        BetweenDatesAPI api = new BetweenDatesAPI();
        var response = await api.getInterval(data);
        Assert.Equal("endDate parameter is mandatory", response?.message);
    }
}