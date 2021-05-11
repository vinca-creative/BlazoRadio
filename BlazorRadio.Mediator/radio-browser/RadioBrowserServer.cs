using AutoMapper;
using BlazorRadio.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRadio.Mediator.radio_browser
{
    public class RadioBrowserServer : IRadioServer
    {
        readonly RadioBrowserHttpService httpClient;
        readonly IMapper mapper;
        public RadioBrowserServer()
        {
            httpClient = new RadioBrowserHttpService();
            var mapperConfiguration=new MapperConfiguration(cfg => {
                cfg.AddProfile<StationMappingProfile>();
            });
            mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<IEnumerable<Station>> GetStationByTagAsync(string tag)
        {
            var result = await httpClient.Client.GetAsync($"stations/search?tag={tag}");
            var jsonData = await result.Content.ReadAsStringAsync();
            var jsonArray = JArray.Parse(jsonData);
            return jsonArray.Select(q => mapper.Map<Station>((JObject)q));
        }
    }
}
