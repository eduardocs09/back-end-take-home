namespace Routes.API.ViewModels
{
    public class ConnectionViewModel
    {
        public AirlineViewModel Airline { get; set; }
        public AirportViewModel Origin { get; set; }
        public AirportViewModel Destination { get; set; }
    }
}
