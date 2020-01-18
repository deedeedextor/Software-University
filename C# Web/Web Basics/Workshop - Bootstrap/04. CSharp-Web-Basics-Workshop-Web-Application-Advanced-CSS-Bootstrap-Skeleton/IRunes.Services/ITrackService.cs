using IRunes.Models;
using System.Collections.Generic;

namespace IRunes.Services
{
    public interface ITrackService
    {
        Track GetTrackById(string id);
    }
}
