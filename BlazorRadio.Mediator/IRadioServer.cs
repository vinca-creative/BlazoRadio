using BlazorRadio.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorRadio.Mediator
{
    public interface IRadioServer
    {
        Task<IEnumerable<Station>> GetStationByTagAsync(string tag);

    }
}
