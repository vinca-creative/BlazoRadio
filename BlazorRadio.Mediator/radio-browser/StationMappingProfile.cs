using AutoMapper;
using BlazorRadio.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRadio.Mediator.radio_browser
{
    internal class StationMappingProfile : Profile
    {
        public StationMappingProfile()
        {
            CreateMap<JObject, Station>()
                 .ForMember(d => d.Name, s => s.MapFrom(t => t["name"]))
                 .ForMember(d => d.IconURL, s => s.MapFrom(t => t["favicon"]))
                 .ForMember(d => d.ResolveURL, s => s.MapFrom(t => t["url_resolved"]))
                 .ForMember(d => d.StationUUID, s => s.MapFrom(t => t["stationuuid"]));

        }

    }
}
