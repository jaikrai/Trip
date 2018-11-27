using System;
using System.Collections.Generic;
using System.Linq;

namespace Trip
{
    /// <summary>
    ///     Example Trip container
    /// </summary>
    public class Trip
    {
        public Trip()
        {
            TripStateStatus = TripState.Status.Create;
            Destinations = new List<TripPackages>();
            Travellers = new List<string>();
        }

        /// <summary>
        ///     Holds status of Trip instance.
        ///     Do not arbitrarily change.
        ///     Must be managed by TripState machine.
        /// </summary>
        public TripState.Status TripStateStatus { get; set; }

        public String Agent{ get; set;}

        public long OrderId { get; set; }
        public DateTime BookedOn { get; set; }
        public List<TripPackages> Destinations { get; set; }
        public List<string> Travellers { get; set; }
        public string ThankYou { get; set; }
        public Payment Payment { get; set; }
        public decimal GrandTotal => Destinations.Sum(item => item.TotalPrice);
	
    }
}