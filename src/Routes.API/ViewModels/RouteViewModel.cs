using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Routes.API.ViewModels
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RouteViewModel
    {
        public List<ConnectionViewModel> Connections { get; set; }

        public string Message { get; private set; }

        public RouteViewModel()
        { }

        public RouteViewModel(string message)
        {
            Message = message;
        }
    }
}
