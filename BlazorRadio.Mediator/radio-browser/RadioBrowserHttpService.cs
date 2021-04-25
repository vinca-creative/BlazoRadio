using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.NetworkInformation;

namespace BlazorRadio.Mediator
{
    internal class RadioBrowserHttpService
    {
        public HttpClient Client { get; }
        public RadioBrowserHttpService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri($"https://{GetRadioBrowserApiUrl()}/json/")
            };
            Client.DefaultRequestHeaders.Add("User-Agent", "BlazorRadio");
        }

        private static string GetRadioBrowserApiUrl()
        {
            string searchUrl = @"de1.api.radio-browser.info"; // Fallback
            try
            {
                // Get fastest ip of dns
                string baseUrl = @"all.api.radio-browser.info";
                var ips = Dns.GetHostAddresses(baseUrl);
                long lastRoundTripTime = long.MaxValue;
                foreach (IPAddress ipAddress in ips)
                {
                    var reply = new Ping().Send(ipAddress);
                    if (reply != null &&
                        reply.RoundtripTime < lastRoundTripTime)
                    {
                        lastRoundTripTime = reply.RoundtripTime;
                        searchUrl = ipAddress.ToString();
                    }
                }

                // Get clean name
                IPHostEntry hostEntry = Dns.GetHostEntry(searchUrl);
                if (!string.IsNullOrEmpty(hostEntry.HostName))
                {
                    searchUrl = hostEntry.HostName;
                }

                return searchUrl;
            }catch(Exception ex)
            {
                return searchUrl;
            }
        }
    }
}
