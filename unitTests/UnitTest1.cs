using unitTests.BetweenDates;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async void SendEmptyData()
    {
        //Prepare
        RequestData data = new RequestData("", "", "");
        BetweenDatesAPI api = new BetweenDatesAPI();

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal("endDate parameter is mandatory", response?.message);
    }

    [Fact]
    public async void TestDefaultStartDate()
    {
        //Prepare
        String sameDayNextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
        RequestData data = new RequestData("", sameDayNextWeek, "days");
        BetweenDatesAPI api = new BetweenDatesAPI();

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(6, response?.days);
    }

    [Fact]
    public async void TestDefaultStartDateAndDateFormat()
    {
        //Prepare
        String sameDayNextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
        RequestData data = new RequestData("", sameDayNextWeek, "");
        BetweenDatesAPI api = new BetweenDatesAPI();

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(6, response?.days);
    }

    [Fact]
    public async void TestResultsInSeconds()
    {
        //Prepare
        String sameDayNextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
        RequestData data = new RequestData("", sameDayNextWeek, "seconds");
        BetweenDatesAPI api = new BetweenDatesAPI();
        int secondsInSixDays = 6 * 24 * 60 * 60;

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(secondsInSixDays, response?.seconds);
    }

    [Fact]
    public async void TestResultsInMinutes()
    {
        //Prepare
        String sameDayNextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
        RequestData data = new RequestData("", sameDayNextWeek, "minutes");
        BetweenDatesAPI api = new BetweenDatesAPI();
        int minutesInSixDays = 6 * 24 * 60;

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(minutesInSixDays, response?.minutes);
    }

    [Fact]
    public async void TestResultsInHours()
    {
        //Prepare
        String sameDayNextWeek = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
        RequestData data = new RequestData("", sameDayNextWeek, "hours");
        BetweenDatesAPI api = new BetweenDatesAPI();
        int hoursInSixDays = 6 * 24;

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(hoursInSixDays, response?.hours);
    }
}