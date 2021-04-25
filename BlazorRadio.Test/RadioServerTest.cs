using System;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace BlazorRadio.Test
{
    public class RadioServerTest
    {
        [Fact]
        public void ConnectToDefaultServer()
        {
            var radioServer = new Mediator.radio_browser.RadioBrowserServer();
            Assert.NotNull(radioServer);
        }

        [Fact]
        public async Task GetStationList()
        {
            var radioServer = new Mediator.radio_browser.RadioBrowserServer();
            var stationList = await radioServer.GetStationByTagAsync("jazz");

            Assert.True(stationList.Any());
        }
    }
}
