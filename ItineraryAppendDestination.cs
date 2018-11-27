using System;

namespace Trip
{
    /// <summary>
    ///     Destinations itinerary decorator
    /// </summary>
    public class ItineraryAppendDestinations : ItineraryDecorator
    {
        public ItineraryAppendDestinations(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "PACKAGES" + Environment.NewLine;
            toOutput += Environment.NewLine;
            for (var destination = 0; destination < Trip.Destinations.Count; destination++)
                toOutput += $"{destination + 1,2}. {Trip.Destinations[destination]}" + Environment.NewLine;
            return toOutput;
        }
    }
}