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
        Assert.Equal(5, response?.weekdays);
        Assert.Equal(0, response?.completeWeeks);
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
        Assert.Equal(5, response?.weekdays);
        Assert.Equal(0, response?.completeWeeks);
    }

    [Fact]
    public async void TestStartDateGreaterThanEndDate()
    {
        //Prepare
        RequestData data = new RequestData("2022-08-03", "2022-08-03", "");
        BetweenDatesAPI api = new BetweenDatesAPI();

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal("endDate needs to be greater than startDate.", response?.message);
    }

    [Fact]
    public async void TestResultsInSeconds()
    {
        //Prepare
        RequestData data = new RequestData("2022-08-03", "2022-08-18", "seconds");
        BetweenDatesAPI api = new BetweenDatesAPI();
        String weekdaysInSeconds = (10 * 24 * 60 * 60) + " seconds";
        String completeWeeksInSeconds = (7 * 24 * 60 * 60) + " seconds";
        String daysInSeconds = (14 * 24 * 60 * 60) + " seconds";

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(14, response?.days);
        Assert.Equal(10, response?.weekdays);
        Assert.Equal(1, response?.completeWeeks);
        Assert.Equal(weekdaysInSeconds, response?.weekdaysInSeconds);
        Assert.Equal(completeWeeksInSeconds, response?.completeWeeksInSeconds);
        Assert.Equal(daysInSeconds, response?.daysInSeconds);
    }

    [Fact]
    public async void TestResultsInMinutes()
    {
        //Prepare
        RequestData data = new RequestData("2022-08-03", "2022-08-18", "minutes");
        BetweenDatesAPI api = new BetweenDatesAPI();
        String weekdaysInMinutes = (10 * 24 * 60) + " minutes";
        String completeWeeksInMinutes = (7 * 24 * 60) + " minutes";
        String daysInMinutes = (14 * 24 * 60) + " minutes";

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(14, response?.days);
        Assert.Equal(10, response?.weekdays);
        Assert.Equal(1, response?.completeWeeks);
        Assert.Equal(weekdaysInMinutes, response?.weekdaysInMinutes);
        Assert.Equal(completeWeeksInMinutes, response?.completeWeeksInMinutes);
        Assert.Equal(daysInMinutes, response?.daysInMinutes);
    }

    [Fact]
    public async void TestResultsInHours()
    {
        //Prepare
        RequestData data = new RequestData("2022-08-03", "2022-08-18", "hours");
        BetweenDatesAPI api = new BetweenDatesAPI();
        String weekdaysInHours = (10 * 24) + " hours";
        String completeWeeksInHours = (7 * 24) + " hours";
        String daysInHours = (14 * 24) + " hours";

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(14, response?.days);
        Assert.Equal(10, response?.weekdays);
        Assert.Equal(1, response?.completeWeeks);
        Assert.Equal(weekdaysInHours, response?.weekdaysInHours);
        Assert.Equal(completeWeeksInHours, response?.completeWeeksInHours);
        Assert.Equal(daysInHours, response?.daysInHours);
    }

    [Fact]
    public async void TestResultsInYears()
    {
        //Prepare
        RequestData data = new RequestData("2022-08-03", "2024-08-27", "years");
        BetweenDatesAPI api = new BetweenDatesAPI();
        Double weeksPerYear = 365d / 7;
        int completeWeeks = 107;
        int weekdays = 538;
        int days = 754;
        String weekdaysInYears = Math.Round((weekdays / 365d), 2) + " years";
        String completeWeeksInYears = Math.Round((completeWeeks / weeksPerYear), 2) + " years";
        String daysInYears = Math.Round((days / 365d), 2) + " years";

        //Act
        var response = await api.getInterval(data);

        //Assert
        Assert.Equal(days, response?.days);
        Assert.Equal(weekdays, response?.weekdays);
        Assert.Equal(completeWeeks, response?.completeWeeks);
        Assert.Equal(weekdaysInYears, response?.weekdaysInYears);
        Assert.Equal(completeWeeksInYears, response?.completeWeeksInYears);
        Assert.Equal(daysInYears, response?.daysInYears);
    }
}