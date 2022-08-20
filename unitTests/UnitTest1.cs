using unitTests.BetweenDates;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async void GetDays()
    {
        BetweenDatesAPI api = new BetweenDatesAPI();
        var response = await api.getInterval();
        Assert.Equal("endDate parameter is mandatory", response.message);
    }
}