using Xunit;
using BollingerBand;
using IronXL;


namespace BollingerBandTest
{
    public class UnitTest1
    {

        [Fact]
        public void Test1Equal()
        {
            License.LicenseKey = "IRONXL.VIKRAMBUDDHI.30656-83676980F5-LUK42IZUQBZH3AVX-XXCOPJAHWMN5-47OUNABWD3OL-SDTZ3G4JQPK7-T7QTUTJRGSGT-XNJGOO-TVFMKFA7AXGHEA-DEPLOYMENT.TRIAL-MLIE74.TRIAL.EXPIRES.10.SEP.2022";
            var runObj = new Bollinger("last.csv");
            var runorders = runObj.runIntraday("2022.05.02");
            var ordertime = runObj.Checkordertime(runorders, "2022.05.02", "GUSH", "BUY");
            Assert.Equal("11:03:15", ordertime);
        }

        [Fact]
        public void Test2NotEqual()
        {
            License.LicenseKey = "IRONXL.VIKRAMBUDDHI.30656-83676980F5-LUK42IZUQBZH3AVX-XXCOPJAHWMN5-47OUNABWD3OL-SDTZ3G4JQPK7-T7QTUTJRGSGT-XNJGOO-TVFMKFA7AXGHEA-DEPLOYMENT.TRIAL-MLIE74.TRIAL.EXPIRES.10.SEP.2022";
            var runObj = new Bollinger("last.csv");
            var runorders = runObj.runIntraday("2022.05.02");
            var ordertime = runObj.Checkordertime(runorders, "2022.05.02", "AGQ", "BUY");
            Assert.NotEqual("09:30:15", ordertime);
        }

        [Theory]
        [InlineData("2022.05.05", "TMF", "BUY", "09:52:30")]
        [InlineData("2022.05.05", "UCO", "SELL", "09:30:05")]
        [InlineData("2022.05.06", "TQQQ",  "BUY", "09:57:00")]
        [InlineData("2022.05.06", "UCO", "SELL", "10:57:00")]
        public void Test3Valid(string date,string ticker, string buysell, string time)
        {
            License.LicenseKey = "IRONXL.VIKRAMBUDDHI.30656-83676980F5-LUK42IZUQBZH3AVX-XXCOPJAHWMN5-47OUNABWD3OL-SDTZ3G4JQPK7-T7QTUTJRGSGT-XNJGOO-TVFMKFA7AXGHEA-DEPLOYMENT.TRIAL-MLIE74.TRIAL.EXPIRES.10.SEP.2022";
            var runObj = new Bollinger("last.csv");
            var runorders = runObj.runIntraday(date);
            var ordertime = runObj.Checkordertime(runorders, date, ticker, buysell);
            Assert.True(ordertime.Equals(time));
        }
    }
}